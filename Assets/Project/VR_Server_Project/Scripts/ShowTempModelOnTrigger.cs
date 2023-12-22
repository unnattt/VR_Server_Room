using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTempModelOnTrigger : MonoBehaviour
{
    [SerializeField] GameObject TempCrimping;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CutCable"))
        {
            Tip();
        }
    }

    public async void Tip()
    {
        TempCrimping.SetActive(true);
        await System.Threading.Tasks.Task.Delay(3000);
        TempCrimping.SetActive(false);

    }
}
