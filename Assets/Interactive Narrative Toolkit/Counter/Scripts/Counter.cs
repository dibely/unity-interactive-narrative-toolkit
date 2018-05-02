using UnityEngine;
using UnityEngine.EventSystems;

namespace InteractiveNarrativeToolkit {
    //
    // Summary:
    //     ///
    //     Increments a counter with each incoming activation message. 
    //     Once the required count has been reached it will send out an activation message to a linked object.
    //     ///
    public class Counter : MonoBehaviour, ITriggerable {
        [Tooltip("An object that will be sent an activate message once the target count has been reached.")]
        public GameObject target;

        [Tooltip("The count value between 1 and 100 to reach before sending a message to the target object.")]
        [Range(1, 100)]
        public int targetCount = 1;
        private int counter = 0;

        // Use this for initialization
        void Start() { }

        // Update is called once per frame
        void Update() { }

        // ITriggerable methods

        public void Activate() {
            counter++;
            CheckTargetCountReached();
        }

        public void Deactivate() {
            // TODO: Decrement counter?
        }

        private void CheckTargetCountReached() {
            if (counter == targetCount) {
                Debug.Log("Target count reached");

                if (target != null) {
                    // Send a message to the target object.
                    Debug.Log("Sending activate message to " + target.name);
                    ExecuteEvents.Execute<ITriggerable>(target, null, (x, y) => x.Activate());
                }
                else {
                    Debug.LogError("Invalid target specific");
                }
            }
        }
    }
}
