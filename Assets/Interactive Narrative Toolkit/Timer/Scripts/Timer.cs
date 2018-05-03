using UnityEngine;
using UnityEngine.Events;

namespace InteractiveNarrativeToolkit {
    //
    // Summary:
    //     ///
    //     A timer that increments in seconds upto a pre-determined target time when active.  
    //     Once the timer has reached the target time it will stop and send messages to any connected objects.
    //     ///
    public class Timer : MonoBehaviour {
        [Tooltip("The time in seconds to wait before the timer is considered complete.")]
        public float waitTime = 10.0f;
        private float timer = 0.0f;
        public float CurrentTime {
            get {
                return timer;
            }
        }

        [Tooltip("Active state of the timer.")]
        public bool active = false;

        [Tooltip("Completion event messages to send once the target count has been reached.")]
        public UnityEvent timerCompletionEvents;

        void Update() {
            if (active) {
                timer += Time.deltaTime;

                if (timer >= waitTime) {
                    StopTimer();
                    OnTimerComplete();
                }
            }
        }

        private void OnTimerComplete() {
            timerCompletionEvents.Invoke();
        }

        #region Control methods

        public void StartTimer() {
            active = true;
        }

        public void StopTimer() {
            active = false;
        }

        public void ResetTimer() {
            StopTimer();
            timer = 0.0f;
        }

        #endregion
    }
}
