using UnityEngine;

namespace InteractiveNarrativeToolkit {
    public class UnloadScene : MonoBehaviour {
        public string sceneName;
        private IUnloadSceneController unloadSceneController = new UnloadSceneController();

        public void Unload() {
            unloadSceneController.UnloadScene(sceneName, this);
        }
    }
}
