using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VR_Server_Room.Manager;
using VR_Server_Room.UI;

namespace VR_Server_Room.CoreGamePlay
{
    public class EndAnchor : MonoBehaviour
    {
        [HideInInspector]
        public XRGrabInteractable xrGrabInteractable;
        Rigidbody endAnchorRb;

        [Header("release Obj At Certain Distance")]
        [SerializeField] private float releaseDistance;
        [SerializeField] private bool isSelected;
        [SerializeField] private GameObject tempTipPlug, tempTipWire;
        private Vector3 initialPos;

        private void Awake()
        {
            endAnchorRb = GetComponent<Rigidbody>();
            xrGrabInteractable = GetComponent<XRGrabInteractable>();
        }

        private void OnEnable()
        {
            xrGrabInteractable.selectEntered.AddListener(OnGrabWire);
            xrGrabInteractable.selectExited.AddListener(OnLeavingWire);
        }

        private void OnDisable()
        {
            xrGrabInteractable.selectEntered.RemoveListener(OnGrabWire);
            xrGrabInteractable.selectExited.RemoveListener(OnLeavingWire);
        }

        private void Start()
        {
            initialPos = transform.position;
            // Example usage:
            // triggerTimerCoroutine = StartCoroutine(HandleTriggerTimerCoroutine(gameObject, ChangesOnCrimpingToolTrigger));
        }

        private void OnLeavingWire(SelectExitEventArgs arg0)
        {
            endAnchorRb.isKinematic = false;
            isSelected = false;
            if (this.gameObject.CompareTag("Plug"))
            {
                tempTipPlug.SetActive(false);
            }
        }

        private void OnGrabWire(SelectEnterEventArgs arg0)
        {
            //throw new NotImplementedException();
            endAnchorRb.isKinematic = true;
            tempTipWire.SetActive(false);
            isSelected = true;
            if (this.gameObject.CompareTag("Plug"))
            {
                tempTipPlug.SetActive(true);
            }
        }


        private void Update()
        {
            if (isSelected)
            {
                // Check the distance between the controller and the grabbed object
                float distance = Vector3.Distance(initialPos, xrGrabInteractable.transform.position);

                // If the distance exceeds the release threshold, release the object
                if (distance > releaseDistance)
                {
                    LeaveGrabbedObject();
                }
            }
        }

        public async void LeaveGrabbedObject()
        {
            xrGrabInteractable.enabled = false;
            await System.Threading.Tasks.Task.Delay(1000);
            xrGrabInteractable.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            RealPlug realPlug = other.gameObject.GetComponentInParent<RealPlug>();
            if (realPlug != null)
            {
                Debug.Log("Rj_45_Plug Trigger");
                realPlug.isPlugTriggered = true;
                realPlug.GetComponent<Rigidbody>().isKinematic = true; 
                GameController.instance.HandleTriggerTimer(realPlug.gameObject, GameController.instance.RJ_45Trigger);
            }


            CrimpingTool crimpingTool = other.GetComponentInParent<CrimpingTool>();
            if (crimpingTool != null)
            {
                //Debug.Log("Stay Crimpimng Tool");
                
                if (crimpingTool.isUsedFirstTime)
                {
                    Debug.Log("Crimpimng Tool First Time");
                    crimpingTool.isTriggered = true;
                    crimpingTool.GetComponent<Rigidbody>().isKinematic = true;
                    GameController.instance.HandleTriggerTimer(crimpingTool.gameObject, GameController.instance.CrimpingToolTriggerFirstTime);
                    //crimpingTool.isUsedFirstTime = false;
                }
                else
                {
                    Debug.Log("Crimpimng Tool Second Time");
                    crimpingTool.isTriggered = true;
                    crimpingTool.GetComponent<Rigidbody>().isKinematic = true; 
                    GameController.instance.HandleTriggerTimer(crimpingTool.gameObject, GameController.instance.CrimpingToolTriggerSecondTime);
                }

            }
        }
    }
}
