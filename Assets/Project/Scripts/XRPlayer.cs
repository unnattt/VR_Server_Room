using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRPlayer : MonoBehaviour
{
    public static XRPlayer instance;
    private Transform xrCameraTransform;

    private void Awake()
    {
        instance = this;
        xrCameraTransform = Camera.main.transform;
    }

    public void TeleportPlayer(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }

    public void SetObjectInPlayerCameraForward(Transform objectToSet, float distanceFromPlayer = 0.5f)
    {
        Vector3 cameraForward = xrCameraTransform.forward;
        cameraForward.y = 0;
        Vector3 newPosition = xrCameraTransform.position + cameraForward * distanceFromPlayer;
        objectToSet.SetPositionAndRotation(newPosition, Quaternion.LookRotation(cameraForward));
    }

}
