using UnityEngine;
using UnityEditor;

namespace InteractiveNarrativeToolkit {
    public class LoadSceneGizmoDrawer {

        [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
        static void DrawGizmoForLoadScene(LoadScene scr, GizmoType gizmoType) {
            GUIStyle textStyle = new GUIStyle();

            float progress = scr.LoadSceneController.Progress();
            if (progress > 0.0f) {
                textStyle.normal.textColor = Color.blue;
                Handles.Label(scr.gameObject.transform.position + new Vector3(0, 0.2f, 0), "Loading " + scr.sceneName + ": " + scr.LoadSceneController.ProgressPercentageString(), textStyle);
            }
            else {
                textStyle.normal.textColor = Color.grey;
                Handles.Label(scr.gameObject.transform.position + new Vector3(0, 0.2f, 0), scr.sceneName, textStyle);
            }
        }
    }
}
