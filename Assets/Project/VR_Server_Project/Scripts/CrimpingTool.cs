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
        //private BoxCollider boxCollider;
        private Vector3 lastGrabbedPosition;
        private Quaternion lastGrabbedRotation;
        //[SerializeField] private bool isScrewResetable;

        private void Awake()
        {
            isUsedFirstTime = true;
            lastGrabbedPosition = transform.position;
            lastGrabbedRotation = transform.rotation;
            //isScrewResetable = false;
            //boxCollider = GetComponent<BoxCollider>();
            //boxCollider.isTrigger = false;
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

        //private void Update()
        //{
        //    //if (isScrewResetable)
        //    //    Invoke(nameof(ResetScrewDriver), 0.5f);
        //}

        private void OnLeaving(SelectExitEventArgs arg0)
        {
            //boxCollider.isTrigger = false;
            //ResetScrewDriver();
            MoveToInitialLocation();
        }

        private void OnGrab(SelectEnterEventArgs arg0)
        {
            //boxCollider.isTrigger = true;
        }

        //private void OnTriggerEnter(Collider other)
        //{

        //    if (other.gameObject.CompareTag("TightenRj_45"))
        //    {
        //        EndAnchor cutter = other.gameObject.GetComponent<EndAnchor>();
        //        if (cutter)
        //        {
        //            //cutter.ChangeModelOnTriggerCutCable();
        //            cutter.OnTriggerTimerPlugTighten(this.gameObject);
        //            //SetButtonOnOfStep8(cutter);
        //        }
        //    }

            //if(other.gameObject.CompareTag("RealPlug"))
            //{
            //    EndAnchor plug = other.gameObject.GetComponent<EndAnchor>();
            //    if (plug)
            //    {
            //        plug.ChangeModelOnTiggerPlug();
            //    }
            //}
        //}

        public void MoveToInitialLocation()
        {
            transform.position = lastGrabbedPosition;
            transform.rotation = lastGrabbedRotation;
        }

        public async void SetScrewDriver()
        {
            xrGrabInteractable.enabled = false;
            await System.Threading.Tasks.Task.Delay(1000);
            xrGrabInteractable.enabled = true;
        }


        //private void ResetScrewDriver()
        //{
        //    Debug.Log("Is Reset screw");
        //    transform.SetPositionAndRotation(initialPos, initialRot);
        //    isScrewResetable = false;
        //}
    }
}
