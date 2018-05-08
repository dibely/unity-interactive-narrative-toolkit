using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InteractiveNarrativeToolkit {
    public class UnloadSceneController : IUnloadSceneController {

        #region IUnloadSceneController methods

        // Entry point for unloading a scene
        // sceneName The name of the scene to unload
        // behaviour The behaviour to use for starting a coroutine
        public void UnloadScene(string sceneName, MonoBehaviour behaviour) {
            if (string.IsNullOrEmpty(sceneName)) {
                Debug.LogError("Invalid scene name specified");
                return;
            }

            Scene scene = SceneManager.GetSceneByName(sceneName);

            if (scene.isLoaded) {
                behaviour.StartCoroutine(DoUnloadScene(scene));
            }
            else {
                Debug.LogWarning("Scene " + sceneName + " is not loaded yet when trying to unload");
            }
        }

        #endregion

        // Async operation handler for unloading a scene
        // scene The scene to unload
        IEnumerator DoUnloadScene(Scene scene) {
            Debug.Log("Unloading scene " + scene.name);

            // Unload scene
            AsyncOperation sceneAsyncOperation = SceneManager.UnloadSceneAsync(scene);

            while (!sceneAsyncOperation.isDone) {
                Debug.Log("Waiting for scene " + scene.name + " to unload");
                yield return new WaitForSeconds(.1f);
            }

            Debug.Log("Scene " + scene.name + " unloaded");
        }
    }
}
