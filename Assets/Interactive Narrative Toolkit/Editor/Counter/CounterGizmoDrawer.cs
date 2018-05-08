using UnityEngine;
using UnityEditor;

namespace InteractiveNarrativeToolkit {
    public class CounterGizmoDrawer {

        [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
        static void DrawGizmoForTimer(Counter scr, GizmoType gizmoType) {
            GUIStyle textStyle = new GUIStyle();
            textStyle.normal.textColor = Color.red;

            // Display current timer info
            Handles.Label(scr.gameObject.transform.position + new Vector3(0, 0.2f, 0), scr.CurrentCount.ToString(), textStyle);
            Handles.Label(scr.gameObject.transform.position + new Vector3(0, 0.35f, 0), scr.targetCount.ToString(), textStyle);

            // Draw connections to target objects
            ArrowsGizmo.DrawArrowsForUnityEvents(scr.gameObject, scr.counterCompletionEvents, textStyle);
        }
    }
}
