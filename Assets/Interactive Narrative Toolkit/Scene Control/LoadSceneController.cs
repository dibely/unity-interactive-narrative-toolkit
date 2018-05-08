using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InteractiveNarrativeToolkit {
    public class LoadSceneController : ILoadSceneController {
        private static float PROGRESS_COMPLETE_THRESHOLD = 0.9f;
        private float progress = 0.0f;

        #region ILoadSceneController methods

        public float Progress() {
            return progress;
        }

        public string ProgressPercentageString() {
            return (progress * 100).ToString("F0") + "%";
        }


        // Entry point for starting a scene load
        // sceneName The name of the scene to load
        // setActive Option for whether to set the scene as the main 'active' scene or not once it has been loaded
        // behaviour The behaviour to use for starting a coroutine
        public void LoadScene(string sceneName, bool setActive, MonoBehaviour behaviour) {
            progress = 0.0f;
            if (string.IsNullOrEmpty(sceneName)) {
                Debug.LogError("Invalid scene name specified");
                return;
            }

            Scene scene = SceneManager.GetSceneByName(sceneName);

            if (!scene.isLoaded) {
                behaviour.StartCoroutine(DoLoadSceneAndSetActive(sceneName, setActive));
            }
            else {
                Debug.LogWarning("Scene " + sceneName + " is already loaded.");
                if (setActive && (SceneManager.GetActiveScene() != scene)) {
                    SetSceneActive(scene);
                }
            }
        }
        #endregion

        // Loads a scene asynchronously and once complete will set the scene active if necessary
        // sceneName The name of the scene to load
        // setActive Option for whether to set the scene as the main 'active' scene or not once it has been loaded
        IEnumerator DoLoadSceneAndSetActive(string sceneName, bool setActive) {
            Debug.Log("Loading scene " + sceneName);

            AsyncOperation sceneAsyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            sceneAsyncOperation.allowSceneActivation = false;

            while (!sceneAsyncOperation.isDone) {
                progress = Mathf.Clamp01(sceneAsyncOperation.progress / PROGRESS_COMPLETE_THRESHOLD);
                Debug.Log("Loading progress: " + ProgressPercentageString());

                // NOTE: The progress of a scene load finishes at 0.9 (for some reason?) so use this as the threshold for the scene being loaded
                if (sceneAsyncOperation.progress >= PROGRESS_COMPLETE_THRESHOLD) {
                    Debug.Log("Scene " + sceneName + " loaded");
                    sceneAsyncOperation.allowSceneActivation = true;
                }

                yield return new WaitForSeconds(.1f);
            }

            if (setActive) {
                SetSceneActive(SceneManager.GetSceneByName(sceneName));
            }
        }

        // Sets the specified scene as the main 'active' scene
        // scene The scene to set as active
        private void SetSceneActive(Scene scene) {
            Debug.Log("Setting scene " + scene.name + " active");
            SceneManager.SetActiveScene(scene);
        }
    }
}
