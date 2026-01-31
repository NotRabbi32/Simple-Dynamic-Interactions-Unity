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
        [SerializeField] private UnityEvent onInteractStarted;
        [SerializeField] private UnityEvent onInteractPreformed;
        [SerializeField] private UnityEvent onInteractCanceled;

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
                onInteractStarted.Invoke();
            }

            if (ctx.performed)
            {
                onInteractPreformed.Invoke();
            }

            if (ctx.canceled)
            {
                onInteractCanceled.Invoke();
            }
        }

        public void OnLookAt()
        {
            _outline.enabled = true;
        }

        public void OnLookAway()
        {
            _outline.enabled = false;
        }
    }
}