using UnityEngine;
using UnityEngine.InputSystem;

namespace Rabbi32.SimpleDynamicInteractions
{
    public interface IInteractable
    {
        Transform transform { get; }
        string DisplayName { get; }
        bool CanInteract();
        void Interact(InputAction.CallbackContext ctx);
        void OnLookAt();
        void OnLookAway();
    }
}
