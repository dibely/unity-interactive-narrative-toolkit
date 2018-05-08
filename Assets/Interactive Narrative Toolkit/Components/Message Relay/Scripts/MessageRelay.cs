using UnityEngine;
using UnityEngine.Events;

namespace InteractiveNarrativeToolkit {
    //
    // Summary:
    //     ///
    //     Provides a mechanism for relaying messages to other objects.
    //     ///
    public class MessageRelay : MonoBehaviour {
        [Tooltip("Messages to relay.")]
        public UnityEvent messages;

        public void RelayMessages() {
            messages.Invoke();
        }
    }
}
