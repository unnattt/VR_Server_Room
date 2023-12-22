using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Toggle : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable interactable;

    private bool isObjectActive;
    public UnityEvent OnObjectEnable;
    //public UnityEvent OnObjectDisable;

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(ToggleObject);
    }

    [ContextMenu("ToggleObject")]
    public void ToggleObject(SelectEnterEventArgs arg0)
    {
        //if (isObjectActive)
        //{
        //    //OnObjectDisable?.Invoke();
        //    isObjectActive = false;
        //}
        //else
        //{
        Debug.Log("is Working");
            OnObjectEnable?.Invoke();
            //isObjectActive = true;
        //}
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(ToggleObject);
    }
}
