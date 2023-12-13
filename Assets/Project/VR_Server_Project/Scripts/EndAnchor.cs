using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EndAnchor : MonoBehaviour
{
    XRGrabInteractable xrGrabInteractable;
    Rigidbody endAnchorRb;

    private void Start()
    {
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
}
