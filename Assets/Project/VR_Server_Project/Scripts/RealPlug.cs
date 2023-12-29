using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
namespace VR_Server_Room.CoreGamePlay
{

    public class RealPlug : MonoBehaviour
    {
        [HideInInspector]
        public XRGrabInteractable xrGrabInteractable;      
        public Transform Model;
        private Vector3 lastGrabbedPosition;
        private Quaternion lastGrabbedRotation;

        //BoxCollider boxCollider;

        private void Awake()
        {
            lastGrabbedPosition = transform.position;
            lastGrabbedRotation = transform.rotation;
            //boxCollider = GetComponent<BoxCollider>();
            //boxCollider.isTrigger = false;
            xrGrabInteractable = GetComponent<XRGrabInteractable>();

        }

        private void OnEnable()
        {
            xrGrabInteractable.selectEntered.AddListener(OnGrabRj_45);
            xrGrabInteractable.selectExited.AddListener(OnLeavingRj_45);
        }

        private void OnDisable()
        {
            xrGrabInteractable.selectEntered.RemoveListener(OnGrabRj_45);
            xrGrabInteractable.selectExited.RemoveListener(OnLeavingRj_45);
        }

      

        private void OnLeavingRj_45(SelectExitEventArgs arg0)
        {
            //boxCollider.isTrigger = false;
            MoveToInitialLocation();
        }

        private void OnGrabRj_45(SelectEnterEventArgs arg0)
        {
            //boxCollider.isTrigger = true;
            
        }

        public void MoveToInitialLocation()
        {
            transform.position = lastGrabbedPosition;
            transform.rotation = lastGrabbedRotation;
        }

        //public async void SetScrewDriver()
        //{
        //    tempTipPlug.SetActive(true);
        //}
    }
}
