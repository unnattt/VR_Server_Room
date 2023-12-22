using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolkitFuctionality : MonoBehaviour
{
    [SerializeField] private Transform crimping_Tool, rj_45_Model;

    private void Start()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RealPlug"))
        {
            other.gameObject.transform.position = rj_45_Model.position;
            //collision.gameObject.transform.position = Vector3.zero;
        }

        if (other.gameObject.CompareTag("CutCable"))
        {
            //collision.gameObject.transform.SetParent(this.gameObject.transform);
            other.gameObject.transform.position = crimping_Tool.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("RealPlug"))
        {
            collision.gameObject.transform.position = rj_45_Model.position;            
            //collision.gameObject.transform.position = Vector3.zero;
        }

        if (collision.gameObject.CompareTag("CutCable"))
        {
            //collision.gameObject.transform.SetParent(this.gameObject.transform);
            collision.gameObject.transform.position = crimping_Tool.position;
        }
    }    
}
