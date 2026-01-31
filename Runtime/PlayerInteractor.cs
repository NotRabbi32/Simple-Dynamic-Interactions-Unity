using UnityEngine;
using UnityEngine.InputSystem;

namespace Rabbi32.SimpleDynamicInteractions
{
    public class PlayerInteractor : MonoBehaviour
    {
        public Transform interactorSource;
        public float interactRange;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private InteractionPrompt prompt;
        [SerializeField] private InputActionReference interactReference;

        private IInteractable _lookingAt;

        private void OnEnable()
        {
            interactReference.action.Enable();
            interactReference.action.started += Interact;
            interactReference.action.performed += Interact;
            interactReference.action.canceled += Interact;
        }

        private void OnDisable()
        {
            interactReference.action.Disable();
            interactReference.action.started -= Interact;
            interactReference.action.performed -= Interact;
            interactReference.action.canceled -= Interact;
        }


        private void Update()
        {
            IInteractable interactable = GetInteractable();
            UpdateLookAt(interactable);
        }

        private IInteractable GetInteractable()
        {
            Ray ray = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObject))
                {
                    return interactableObject;
                }
            }

            return null;
        }

        private void UpdateLookAt(IInteractable interactable)
        {
            if (ReferenceEquals(_lookingAt, interactable)) return;
            _lookingAt?.OnLookAway();
            _lookingAt = interactable;
            if (_lookingAt != null)
            {
                _lookingAt.OnLookAt();
                prompt.Show(_lookingAt);
            }
            else
            {
                prompt.Hide();
            }
        }

        void Interact(InputAction.CallbackContext ctx)
        {
            if (_lookingAt != null)
            {
                if (!_lookingAt.CanInteract()) return;
                _lookingAt.Interact(ctx);
            }
        }
        
        private void OnDrawGizmos()
        {
            if (interactorSource == null)
                return;

            Ray ray = new Ray(interactorSource.position, interactorSource.forward);

            // Draw full ray
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * interactRange);

            // Raycast for hit
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
            {
                // Draw hit ray
                Gizmos.color = Color.green;
                Gizmos.DrawRay(ray.origin, ray.direction * hitInfo.distance);

                // Draw hit point sphere
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(hitInfo.point, 0.05f);
            }
        }
    }
}
