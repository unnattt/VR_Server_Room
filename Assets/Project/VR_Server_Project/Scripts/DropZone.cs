using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR_Server_Room.CoreGamePlay
{
    public class DropZone : XRSocketInteractor
    {
        // XRSnapInteractor is an XRSocketInteractor that filters socketable items by tag
        [Header("Filters")]
        [SerializeField] protected List<GrabInteractableObject> Dropables;
        public UnityEvent<GameObject> OnDropped;

        protected override void OnEnable()
        {
            base.OnEnable();
            selectEntered.AddListener(OnItemDropped);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            selectEntered.RemoveListener(OnItemDropped);
        }
        public void OnItemDropped(SelectEnterEventArgs args)
        {
            OnDropped?.Invoke(args.interactableObject.transform.gameObject);
        }

        public override bool CanHover(IXRHoverInteractable interactable)
        {
            bool canBaseHover = base.CanHover(interactable);
            return canBaseHover && Dropables.Exists(x => x.gameObject == interactable.transform.gameObject);
        }

        public override bool CanSelect(IXRSelectInteractable interactable)
        {
            bool canBaseHover = base.CanSelect(interactable);
            return canBaseHover && Dropables.Exists(x => x.gameObject == interactable.transform.gameObject);
        }

        public void AddDropable(GrabInteractableObject grabInteractableObject)
        {
            Dropables.Add(grabInteractableObject);
        }

        public void ToggleInteractable(bool enabled, bool forceUpdate)
        {
            if (forceUpdate)
            {
                allowHover = enabled;
                allowSelect = enabled;
            }
        }

    }

}