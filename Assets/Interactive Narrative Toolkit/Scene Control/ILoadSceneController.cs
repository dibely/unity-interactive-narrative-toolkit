using UnityEngine;

public interface ILoadSceneController {
    float Progress();
    string ProgressPercentageString();
    void LoadScene(string sceneName, bool setActive, MonoBehaviour behaviour);
}