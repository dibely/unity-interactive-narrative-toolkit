using UnityEngine;
using UnityEngine.EventSystems;

//
// Summary:
//     ///
//     A timer that increments in seconds.  
//     Once the timer has finished it will send an activation message to a linked object.
//     ///
public class Timer : MonoBehaviour, ITriggerable {
    [Tooltip("An object that will be sent an activate message once the timer has finished.")]
    public GameObject target; // Can this be an object of type ITriggerable only?

    [Tooltip("The time in seconds to wait before sending an activate message to the target object.")]
    public float waitTime = 10.0f;

    private float timer = 0.0f;

    [Tooltip("Flag for the timer being active.  Enable this to have the timer start as soon as the object it is attached to is created.")]
    public bool active = false;

    /*
    private void OnValidate() {
        if(target != null) {
            ITriggerable test = (ITriggerable)target.GetComponent(typeof(ITriggerable));
            if (test == null) {
                target = null;
            }
        }
    }
    */

    // Use this for initialization
    void Start () {}

	// Update is called once per frame
	void Update () {
        if (active) {
            timer += Time.deltaTime;

            if (timer >= waitTime) {
                // Perform action
                Debug.Log("Sending activate message to " + target.name);
                ExecuteEvents.Execute<ITriggerable>(target, null, (x, y) => x.Activate());

                Deactivate();
            }
        }
    }

    // ITriggerable methods

    public void Activate() {
        active = true;
    }

    public void Deactivate() {
        // Reset
        active = false;
        timer = 0.0f;
    }
}
