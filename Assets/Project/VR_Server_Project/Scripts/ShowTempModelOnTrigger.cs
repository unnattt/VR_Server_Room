using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR_Server_Room.CoreGamePlay;

public class ShowTempModelOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject TempCrimping;
    [SerializeField] private GameObject TempPlug;
    [SerializeField] private CrimpingTool crimpingTool;
    [SerializeField] private RealPlug rj_45_Model;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CrimpingTool>())
        {
            if (TempCrimping == null) return;
            //TipScrimpingTool();
            TempCrimping.SetActive(true);
            crimpingTool.xrGrabInteractable.trackRotation = false;
            crimpingTool.xrGrabInteractable.trackPosition = false;
            crimpingTool.Model.transform.position = TempCrimping.transform.position;
            crimpingTool.Model.transform.rotation = TempCrimping.transform.rotation;
        }
        
        if (other.gameObject.GetComponent<RealPlug>())
        {
            if (TempPlug == null) return;
            //TipPlug();
            TempPlug.SetActive(true);
            rj_45_Model.xrGrabInteractable.trackRotation = false;
            rj_45_Model.xrGrabInteractable.trackPosition = false;
            rj_45_Model.Model.transform.position = TempPlug.transform.position;
            rj_45_Model.Model.transform.rotation = TempPlug.transform.rotation;
        }

    }


    private void Update()
    {
        transform.position = rjPlugInWire.position;
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("CutCable"))
    //    {
    //        if (TempCrimping == null) return;
    //        //TipScrimpingTool();
    //        TempCrimping.SetActive(false);
    //        crimpingTool.xrGrabInteractable.trackRotation = true;
    //        crimpingTool.Model.localRotation = initialRotationOfCrimpingTool;
    //        crimpingTool.Model.localPosition = Vector3.zero;
    //    }

    //    if (other.gameObject.CompareTag("RealPlug"))
    //    {
    //        if (TempPlug == null) return;

    //        TempPlug.SetActive(false);
    //        rj_45_Model.xrGrabInteractable.trackRotation = true;
    //        rj_45_Model.Model.localRotation = initialRotationOfRj_45;
    //        rj_45_Model.Model.localPosition = Vector3.zero;
    //    }

    //    if (other.gameObject.CompareTag("TightenRj_45"))
    //    {
    //        if (TempCrimping == null) return;

    //        TempCrimping.SetActive(false);
    //        crimpingTool.xrGrabInteractable.trackRotation = true;
    //        crimpingTool.Model.localRotation = initialRotationOfCrimpingTool;
    //        crimpingTool.Model.localPosition = Vector3.zero;
    //    }
    //}

    private void OnDisable()
    {
        if (TempCrimping != null)
        {
            TempCrimping.SetActive(false);
            crimpingTool.xrGrabInteractable.trackRotation = true;
            crimpingTool.xrGrabInteractable.trackPosition = true;
            //crimpingTool.transform.position = crimpingTool.Model.transform.localPosition;
            crimpingTool.Model.localRotation = initialRotationOfCrimpingTool;
            crimpingTool.Model.localPosition = Vector3.zero;

        }

        if (TempPlug != null)
        {
            TempPlug.SetActive(false);
            rj_45_Model.xrGrabInteractable.trackRotation = true;
            rj_45_Model.xrGrabInteractable.trackPosition = true;
            //rj_45_Model.transform.position = rj_45_Model.Model.transform.localPosition;
            rj_45_Model.Model.localRotation = initialRotationOfRj_45;
            rj_45_Model.Model.localPosition = Vector3.zero;
        }
    }
}
