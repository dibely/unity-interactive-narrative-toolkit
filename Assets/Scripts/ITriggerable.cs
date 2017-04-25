using UnityEngine.EventSystems;

//
// Summary:
//     ///
//     Provides a common interface for activation and deactivation messaging between objects.
//     ///
public interface ITriggerable : IEventSystemHandler {

    void Activate();

    void Deactivate();
}
