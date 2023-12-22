using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR_Server_Room.CoreGamePlay
{
    public class ScrewDriver : MonoBehaviour
    {
        XRGrabInteractable xrGrabInteractable;
        Vector3 initialPos;
        Quaternion initialRot;
        BoxCollider boxCollider;

        [SerializeField] private bool isScrewResetable;

        private void Awake()
        {
            initialPos = transform.position;
            initialRot = transform.rotation;
            isScrewResetable = false;
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = false;
            xrGrabInteractable = GetComponent<XRGrabInteractable>();

        }

        private void OnEnable()
        {
            xrGrabInteractable.selectEntered.AddListener(OnGrabScrewDriver);
            xrGrabInteractable.selectExited.AddListener(OnLeavingScrewDriver);
        }

        private void OnDisable()
        {
            xrGrabInteractable.selectEntered.RemoveListener(OnGrabScrewDriver);
            xrGrabInteractable.selectExited.RemoveListener(OnLeavingScrewDriver);
        }

        private void Update()
        {
            if (isScrewResetable)
                Invoke(nameof(ResetScrewDriver), 0.5f);
        }

        private void OnLeavingScrewDriver(SelectExitEventArgs arg0)
        {
            boxCollider.isTrigger = false;
            ResetScrewDriver();

        }

        private void OnGrabScrewDriver(SelectEnterEventArgs arg0)
        {
            boxCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.CompareTag("errorPlug"))
            //{
            //    PlugController plug = other.gameObject.GetComponent<PlugController>();
            //    if (!plug.isConected)
            //    {
            //        plug._realPlug.SetActive(true);
            //        other.gameObject.SetActive(false);
            //        //plug.partical.Stop();
            //        isScrewResetable = true;
            //        SetScrewDriver();
            //    }
            //    //ResetScrewDriver();
            //    //gameObject.SetActive(false);
            //}
            if (other.gameObject.CompareTag("CutCable"))
            {
                EndAnchor cutter = other.gameObject.GetComponent<EndAnchor>();
                if (cutter)
                {
                    cutter.ChangeModelOnTriggerCutCable();
                }
                //ResetScrewDriver();
                //gameObject.SetActive(false);
            }

            if(other.gameObject.CompareTag("RealPlug"))
            {
                EndAnchor plug = other.gameObject.GetComponent<EndAnchor>();
                if (plug)
                {
                    plug.ChangeModelOnTiggerPlug();
                }
            }
        }

        public async void SetScrewDriver()
        {
            xrGrabInteractable.enabled = false;
            await System.Threading.Tasks.Task.Delay(1000);
            xrGrabInteractable.enabled = true;
        }
        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("errorPlug"))
        //    {
        //        PlugController plug = collision.gameObject.GetComponent<PlugController>();
        //        plug._realPlug.SetActive(true);
        //        collision.gameObject.SetActive(false);
        //        //plug.partical.Stop();
        //        //isScrewResetable = true;
        //        //ResetScrewDriver();
        //        //gameObject.SetActive(false);
        //    }
        //}

        private void ResetScrewDriver()
        {
            Debug.Log("Is Reset screw");
            transform.SetPositionAndRotation(initialPos, initialRot);
            isScrewResetable = false;
        }
    }
}
