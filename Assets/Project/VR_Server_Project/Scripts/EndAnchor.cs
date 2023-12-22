using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR_Server_Room.CoreGamePlay
{
    public class EndAnchor : MonoBehaviour
    {
        [SerializeField] private GameObject realPlug , CutCable, FirstPlug;
        XRGrabInteractable xrGrabInteractable;
        Rigidbody endAnchorRb;
        [SerializeField] private GameObject FirstTip;
        [SerializeField] private GameObject SecondTip;
        //[SerializeField] private LayerMask mask;
        //[SerializeField] private Transform plugPos;
        [SerializeField] private bool isCutCableTouch;

        private void Start()
        {
            isCutCableTouch = true;
            endAnchorRb = GetComponent<Rigidbody>();
            xrGrabInteractable = GetComponent<XRGrabInteractable>();
            xrGrabInteractable.selectEntered.AddListener(OnGrabWire);
            xrGrabInteractable.selectExited.AddListener(OnLeavingWire);
        }

        private void OnLeavingWire(SelectExitEventArgs arg0)
        {
            endAnchorRb.isKinematic = false;
        }

        private void OnGrabWire(SelectEnterEventArgs arg0)
        {
            //throw new NotImplementedException();
            endAnchorRb.isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {           
            if (other.gameObject.CompareTag("RealPlug"))
            {               
               ChangeModelOnTiggerPlug();
                this.tag = "Plug";
                other.gameObject.SetActive(false);
            }

            if (other.gameObject.CompareTag("CutCable") && isCutCableTouch)
            {
                isCutCableTouch = false;
               ChangeModelOnTriggerCutCable();
                //other.gameObject.SetActive(false);
                //ResetScrewDriver();
                //gameObject.SetActive(false);
            }
        }

        public void ChangeModelOnTriggerCutCable()
        {
            FirstPlug.SetActive(false);
            CutCable.SetActive(true);
            FirstTip.SetActive(false);
        }

        public void ChangeModelOnTiggerPlug()
        {
            CutCable.SetActive(false);
            realPlug.SetActive(true);
            SecondTip.SetActive(true);
        }
    }
}
