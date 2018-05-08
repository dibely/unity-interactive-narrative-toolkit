using UnityEngine;

namespace InteractiveNarrativeToolkit {
    public class LoadScene : MonoBehaviour {
        public string sceneName;
        public bool setSceneActive = false;
        private ILoadSceneController loadSceneController = new LoadSceneController();
        public ILoadSceneController LoadSceneController {
            get {
                return loadSceneController;
            }
        }

        public void Load() {
            loadSceneController.LoadScene(sceneName, setSceneActive, this);
        }
    }
}
