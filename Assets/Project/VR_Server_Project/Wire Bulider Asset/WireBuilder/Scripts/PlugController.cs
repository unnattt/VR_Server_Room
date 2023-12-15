using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlugController : MonoBehaviour
{
    public bool isConected = false;
    public UnityEvent OnWirePlugged;
    public UnityEvent OnWirePluggedOut;
    public Transform plugPosition;

    public GameObject _realPlug;
    //public ParticleSystem partical;
     //public Transform wireHolderPos;

    [HideInInspector]
    public Transform endAnchor;
    [HideInInspector]
    public Rigidbody endAnchorRB;
    [HideInInspector]
    public WireController wireController;
    public void OnPlugged()
    {
        OnWirePlugged.Invoke();
    }

    public void OnPluggedOut()
    {
        OnWirePluggedOut.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject == endAnchor.gameObject)
        {
            isConected = true;
            endAnchorRB.isKinematic = true;
            endAnchor.transform.position = plugPosition.position;
            endAnchor.transform.rotation = transform.rotation;


            OnPlugged();
        }

        //if(other.gameObject.CompareTag("errorPlug"))
        //{
        //    _realPlug.SetActive(true);
        //    gameObject.SetActive(false);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject == endAnchor.gameObject)
        {
            isConected = false;
            //endAnchorRB.isKinematic = false;

            //OnPlugged();
            OnPluggedOut();
        }
    }

    private void Update()
    {

        if (isConected)
        {
            endAnchorRB.isKinematic = true;
            endAnchor.transform.position = plugPosition.position;
            Vector3 eulerRotation = new Vector3(this.transform.eulerAngles.x + 90, this.transform.eulerAngles.y , this.transform.eulerAngles.z);
            endAnchor.transform.rotation = Quaternion.Euler(eulerRotation);
        }

        else
        {
            //endAnchorRB.isKinematic = false;
            endAnchor.transform.position = wireController.endAnchorTemp.position;
            Vector3 eulerRotation = new Vector3(wireController.endAnchorTemp.eulerAngles.x, wireController.endAnchorTemp.eulerAngles.y, wireController.endAnchorTemp.eulerAngles.z);
            endAnchor.transform.rotation = Quaternion.Euler(eulerRotation);
            //endAnchor.transform.rotation = wireController.endAnchorTemp.rotation;


        }
    }
}
