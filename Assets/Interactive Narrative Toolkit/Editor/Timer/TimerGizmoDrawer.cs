using UnityEngine;
using UnityEditor;

namespace InteractiveNarrativeToolkit {
    public class TimerGizmoDrawer {

        [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
        static void DrawGizmoForTimer(Timer scr, GizmoType gizmoType) {
            GUIStyle textStyle = new GUIStyle();
            textStyle.normal.textColor = Color.red;

            // Display current timer info
            Handles.Label(scr.gameObject.transform.position + new Vector3(0, 0.2f, 0), scr.CurrentTime.ToString("F2") + " s", textStyle);
            Handles.Label(scr.gameObject.transform.position + new Vector3(0, 0.35f, 0), scr.waitTime.ToString("F2") + " s", textStyle);

            // Draw connections to target objects
            ArrowsGizmo.DrawArrowsForUnityEvents(scr.gameObject, scr.timerCompletionEvents, textStyle);
        }
    }
}
