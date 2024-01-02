using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR_Server_Room.CoreGamePlay
{
    public class CrimpingTool : MonoBehaviour
    {
        [HideInInspector]
        public XRGrabInteractable xrGrabInteractable;
        public Transform Model;
        public bool isUsedFirstTime;       
        private Vector3 lastGrabbedPosition;
        private Quaternion lastGrabbedRotation;

        private void Awake()
        {
            isUsedFirstTime = true;
            lastGrabbedPosition = transform.position;
            lastGrabbedRotation = transform.rotation;        
            xrGrabInteractable = GetComponent<XRGrabInteractable>();
        }

        private void OnEnable()
        {
            xrGrabInteractable.selectEntered.AddListener(OnGrab);
            xrGrabInteractable.selectExited.AddListener(OnLeaving);
        }

        private void OnDisable()
        {
            xrGrabInteractable.selectEntered.RemoveListener(OnGrab);
            xrGrabInteractable.selectExited.RemoveListener(OnLeaving);
            isUsedFirstTime = false;
            MoveToInitialLocation();
        }
    
        private void OnLeaving(SelectExitEventArgs arg0)
        {
            
        }

        private void OnGrab(SelectEnterEventArgs arg0)
        {
            
        }
        
        public void MoveToInitialLocation()
        {
            transform.position = lastGrabbedPosition;
            transform.rotation = lastGrabbedRotation;
        }           
    }
}
