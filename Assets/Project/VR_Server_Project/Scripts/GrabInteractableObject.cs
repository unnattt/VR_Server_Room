using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR_Server_Room.CoreGamePlay
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class GrabInteractableObject : MonoBehaviour
    {
        #region EVENTS
        #endregion

        #region PUBLIC_VARS
        #endregion

        #region PRIVATE_VARS
        private Vector3 lastGrabbedPosition;
        private Quaternion lastGrabbedRotation;
        private Transform initialParent;
        private XRGrabInteractable xRGrabInteractable;
        private InteractionLayerMask interactionMask;


        #endregion

        #region UNITY_CALLBACKS

        private void Awake()
        {
            xRGrabInteractable = GetComponent<XRGrabInteractable>();
        }
        private void Start()
        {
            initialParent= transform.parent;
            interactionMask = xRGrabInteractable.interactionLayers;
        }
        private void OnEnable()
        {
            xRGrabInteractable.selectEntered.AddListener(OnSelectEntered);
            xRGrabInteractable.selectExited.AddListener(OnSelectExited);

        }
        private void OnDisable()
        {
            xRGrabInteractable.selectEntered.RemoveListener(OnSelectEntered);
            xRGrabInteractable.selectExited.RemoveListener(OnSelectExited);
        }
        #endregion

        #region PUBLIC_METHODS

        public void OnSelectEntered(SelectEnterEventArgs arg0)
        {
            if (arg0.interactorObject is DropZone)
                return;

            lastGrabbedPosition = transform.position;
            lastGrabbedRotation = transform.rotation;

        }
        public void OnSelectExited(SelectExitEventArgs arg0)
        {
            if (arg0.interactorObject is DropZone)
                return;
            MoveToInitialLocation();
        }

        
        public void ResetInteractable()
        {
            ResetParent();
            MoveToInitialLocation();
        }
        public void ToggleInteractable(bool enabled)
        {
            if (enabled)
            {
                xRGrabInteractable.interactionLayers = interactionMask;
            }
            else
            {
                xRGrabInteractable.interactionLayers = 0;
            }

        }
        public void MoveToInitialLocation()
        {
            transform.position= lastGrabbedPosition;
            transform.rotation = lastGrabbedRotation;
        }
        public void ResetParent()
        {
            transform.parent = initialParent;
        }
        #endregion

        #region PRIVATE_METHODS
        
        #endregion
    }
}