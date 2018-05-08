using UnityEngine;
using UnityEditor;

namespace InteractiveNarrativeToolkit {
    public class MessageRelayGizmoDrawer {

        [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
        static void DrawGizmoForMessageRelay(MessageRelay scr, GizmoType gizmoType) {
            GUIStyle textStyle = new GUIStyle();
            textStyle.normal.textColor = Color.red;

            // Draw connections to target objects
            ArrowsGizmo.DrawArrowsForUnityEvents(scr.gameObject, scr.messages, textStyle);
        }
    }
}