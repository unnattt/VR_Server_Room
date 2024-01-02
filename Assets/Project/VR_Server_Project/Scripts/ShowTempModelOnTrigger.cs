using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VR_Server_Room.CoreGamePlay;

public class ShowTempModelOnTrigger : MonoBehaviour
{
    [Header("Temp Fake Tools")]
    [SerializeField] private GameObject TempCrimping;
    [SerializeField] private GameObject TempPlug;

    [Header("Real Tools And Rj_45")]
    [SerializeField] private CrimpingTool crimpingTool;
    [SerializeField] private RealPlug rj_45_Model;
    [SerializeField] private EndAnchor endAnchor;

    [Header("Pos And Rotations")]
    [SerializeField] private Transform rjPlugInWire;
    [SerializeField] private Quaternion initialRotationOfCrimpingTool;
    [SerializeField] private Quaternion initialRotationOfRj_45;

    private void Start()
    {
        if (crimpingTool != null)
        {
            initialRotationOfCrimpingTool = crimpingTool.Model.transform.localRotation;
        }

        if (rj_45_Model != null)
        {
            initialRotationOfRj_45 = rj_45_Model.Model.localRotation;
        }
    }

    private void OnDisable()
    {
        if (TempCrimping != null)
        {
            TempCrimping.SetActive(false);
            SetRotationAndPositionStop(true, endAnchor.xrGrabInteractable);
            SetRotationAndPositionStop(true, crimpingTool.xrGrabInteractable);
            crimpingTool.Model.localRotation = initialRotationOfCrimpingTool;
            crimpingTool.Model.localPosition = Vector3.zero;
        }

        if (TempPlug != null)
        {
            TempPlug.SetActive(false);
            SetRotationAndPositionStop(true, endAnchor.xrGrabInteractable);
            SetRotationAndPositionStop(true, rj_45_Model.xrGrabInteractable);
            rj_45_Model.Model.localRotation = initialRotationOfRj_45;
            rj_45_Model.Model.localPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        transform.position = rjPlugInWire.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CrimpingTool>())
        {
            if (TempCrimping == null) return;
            
            TempCrimping.SetActive(true);
            SetRotationAndPositionStop(false, endAnchor.xrGrabInteractable);
            SetRotationAndPositionStop(false, crimpingTool.xrGrabInteractable);
            crimpingTool.Model.transform.SetPositionAndRotation(TempCrimping.transform.position, TempCrimping.transform.rotation);
        }
        
        if (other.gameObject.GetComponent<RealPlug>())
        {
            if (TempPlug == null) return;
          
            TempPlug.SetActive(true);
            SetRotationAndPositionStop(false, endAnchor.xrGrabInteractable);
            SetRotationAndPositionStop(false, rj_45_Model.xrGrabInteractable);          
            rj_45_Model.Model.transform.SetPositionAndRotation(TempPlug.transform.position, TempPlug.transform.rotation);
        }
    }

    private void SetRotationAndPositionStop(bool temp, XRGrabInteractable xRGrab)
    {
        xRGrab.trackRotation = temp;
        xRGrab.trackPosition = temp;
    }        
}
