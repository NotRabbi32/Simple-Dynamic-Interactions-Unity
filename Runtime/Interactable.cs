using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Rabbi32.SimpleDynamicInteractions
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [Header("Interact Settings")] 
        [SerializeField] private string displayName = "Interact";
        [SerializeField] private bool isEnabled = true;

        [Space(10)] [Header("Outline Settings")] 
        [SerializeField] private Color outlineColor = Color.black;
        [SerializeField] private float outlineWidth = 7f;

        [Space(10)] 
        [Header("Interaction Events")] 
        [Tooltip("Called when Interact button is pressed")]
        [SerializeField] private UnityEvent onInteractStarted;
        [Tooltip("Called when Interact button is held")]
        [SerializeField] private UnityEvent onInteractPreformed;
        [Tooltip("Called after Interact button is released")]
        [SerializeField] private UnityEvent onInteractCanceled;
        [Tooltip("Called when looking at interactable")]
        [SerializeField] private UnityEvent onLookAt;
        [Tooltip("Called when looking away from interactable")]
        [SerializeField] private UnityEvent onLookAway;

        public string DisplayName => displayName;

        public bool CanInteract() => isEnabled;
        private Outline _outline;
        
        private void Start()
        {
            _outline = gameObject.AddComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineVisible;
            _outline.OutlineColor = outlineColor;
            _outline.OutlineWidth = outlineWidth;
            _outline.enabled = false;
        }

        public void Interact(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                onInteractStarted?.Invoke();
            }

            if (ctx.performed)
            {
                onInteractPreformed?.Invoke();
            }

            if (ctx.canceled)
            {
                onInteractCanceled?.Invoke();
            }
        }

        public void OnLookAt()
        {
            onLookAt?.Invoke();
            _outline.enabled = true;
        }

        public void OnLookAway()
        {
            onLookAway?.Invoke();
            _outline.enabled = false;
        }
    }
}