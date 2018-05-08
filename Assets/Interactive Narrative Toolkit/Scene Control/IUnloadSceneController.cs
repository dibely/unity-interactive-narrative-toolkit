using UnityEngine;

public interface IUnloadSceneController {
    void UnloadScene(string sceneName, MonoBehaviour behaviour);
}
