using UnityEngine;
using UnityEngine.Events;

namespace InteractiveNarrativeToolkit {
    //
    // Summary:
    //     ///
    //     Simple counter that can be incremented, decremented and reset. 
    //     Once the counter reaches a specified target it will send out messages to any linked objects.
    //     ///
    public class Counter : MonoBehaviour {
        [Tooltip("The counter value to reach before it is considered complete.")]
        [Range(1, 999)]
        public int targetCount = 1;
        private int counter = 0;

        [Tooltip("Completion event messages to send once the target count has been reached.")]
        public UnityEvent counterCompletionEvents;

        #region Control methods

        public void IncrementCounter() {
            counter++;
            CheckTargetCountReached();
        }

        public void DecrementCounter() {
            counter--;

            // Limit the counter to the original starting value
            if(counter < 0) {
                counter = 0;
            }
        }

        public void ResetCounter() {
            counter = 0;
        }

        #endregion

        private void CheckTargetCountReached() {
            if (counter == targetCount) {
                OnCounterComplete();
            }
        }

        private void OnCounterComplete() {
            counterCompletionEvents.Invoke();
        }
    }
}
