using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerTiggerPopUp : MonoBehaviour
{
    [SerializeField] private GameObject imageText;
    [SerializeField] private GameObject xrPlayer;
   

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == xrPlayer)
        {
            imageText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == xrPlayer)
        {
            imageText.SetActive(false);
        }
    }
}
