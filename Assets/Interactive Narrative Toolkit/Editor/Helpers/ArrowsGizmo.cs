using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class ArrowsGizmo {

	public static void DrawArrowsForUnityEvents(GameObject gameObject, UnityEvent events, GUIStyle textStyle) {
		int eventCount = events.GetPersistentEventCount();
		for (int index = 0; index < eventCount; index++) {
			Object targetObject = events.GetPersistentTarget(index);

			GameObject targetGameObject = targetObject as GameObject;

			if (targetGameObject == null) {
				Component component = targetObject as Component;

				if (component != null) {
					targetGameObject = component.gameObject;
				}
			}

			// Draw arrows and method references if the target object is valid and not the object we are drawing from
			if (targetGameObject != null &&
				targetGameObject != gameObject) {
				Vector3 targetPosition = targetGameObject.transform.position;
				Vector3 direction = targetGameObject.transform.position - gameObject.transform.position;

				// Draw method name text between this object and target
				string methodName = events.GetPersistentMethodName(index);
				Handles.Label(gameObject.transform.position + (direction * 0.5f), methodName, textStyle);

				// Draw arrows
				Handles.color = Color.blue;
				float distance = direction.magnitude;
				if (distance > 0.6f) {
					Vector3 arrowStartPoint = targetPosition - ((direction.normalized * 1.15f) / 2);
					Handles.DrawLine(gameObject.transform.position, arrowStartPoint);
					Handles.ArrowHandleCap(0, arrowStartPoint, Quaternion.LookRotation(direction), 0.5f, EventType.Repaint);
				}
				else {
					Handles.ArrowHandleCap(0, gameObject.transform.position, Quaternion.LookRotation(direction), distance * 0.875f, EventType.Repaint);
				}
			}
		}
	}
}