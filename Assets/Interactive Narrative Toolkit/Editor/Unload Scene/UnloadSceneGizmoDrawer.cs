using UnityEngine;
using UnityEditor;

namespace InteractiveNarrativeToolkit {
    public class UnloadSceneGizmoDrawer {

        [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
        static void DrawGizmoForUnloadScene(UnloadScene scr, GizmoType gizmoType) {
            GUIStyle textStyle = new GUIStyle();
            textStyle.normal.textColor = Color.grey;
            Handles.Label(scr.gameObject.transform.position + new Vector3(0, 0.2f, 0), scr.sceneName, textStyle);
        }
    }
}