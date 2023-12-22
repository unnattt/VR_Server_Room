using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace VR_Server_Room.UI
{
    public class CommonMachineCanvasScript : MonoBehaviour
    {
        [SerializeField] private List<Sprite> images;
        [SerializeField] private string errorMsg;
        [SerializeField] private string workingMsg;
        [SerializeField] private TMP_Text _textOfCanvas;
        [SerializeField] private Image imageOfError;
        [SerializeField] private Image imageOfErrorComp;


        public void ErrorMethod()
        {
            imageOfError.sprite = images[0];
            imageOfErrorComp.sprite = images[0];
            _textOfCanvas.text = errorMsg;
            _textOfCanvas.color = new Color(255, 0, 0, 255);
        }

        public void WorkingMethod()
        {
            imageOfError.sprite = images[1];
            imageOfErrorComp.sprite = images[1];
            _textOfCanvas.text = workingMsg;
            _textOfCanvas.color = new Color(0, 235, 25, 255);
        }
    }
}
