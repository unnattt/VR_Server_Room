using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR_Server_Room.UI;

namespace VR_Server_Room.Manager
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        [Header("All Steps")]
        [SerializeField] private ServerRoomPopUp step5, step6, step7, step8, step9, step10;

        [Header("All Reference Of Equipments")]
        [SerializeField] private GameObject crimpingTool, real_Rj_45, spwan_Rj_45, CutCable, defaultWire, wireHiderRj_45, _mainEndAnchor;

        [Header("All trigger Area")]
        [SerializeField] private GameObject FirstTip, SecondTip, ThirdTip;
        [SerializeField] private ImageFillTimer timer;

        [Header("scale change Area")]
        [SerializeField] private Vector3 defaultScale;
        [SerializeField] private Vector3 finalScale;
        private bool isDoorOpenFirstTime;
        
        private void Awake()
        {
            instance = this;
            isDoorOpenFirstTime = true;
        }

        public void OnDoorExit()
        {
            if (isDoorOpenFirstTime)
            {
                step5.Hide();
                step6.Show();
                crimpingTool.SetActive(true);
                isDoorOpenFirstTime = false;
            }
        }

        public void OnPlugConnected()
        {
            step9.Hide();
            step10.Show();
        }

        public void CrimpingToolTriggerFirstTime()
        {
            defaultWire.SetActive(false);
            CutCable.SetActive(true);
            FirstTip.SetActive(false);
            SecondTip.SetActive(true);            
            step6.Hide();
            step7.Show();
            real_Rj_45.SetActive(true);
        }

        public void RJ_45Trigger()
        {
            CutCable.SetActive(false);
            spwan_Rj_45.SetActive(true);
            SecondTip.SetActive(false);
            ThirdTip.SetActive(true);
            _mainEndAnchor.tag = "TightenRj_45";
            step7.Hide();
            step8.Show();
            crimpingTool.SetActive(true);
        }

        public void CrimpingToolTriggerSecondTime()
        {
            ThirdTip.SetActive(false);
            _mainEndAnchor.tag = "Plug";
            wireHiderRj_45.transform.localScale = finalScale;
            step8.Hide();
            step9.Show();            
        }


        public async void HandleTriggerTimer(GameObject obj, Action triggerAction)
        {
            timer._timerCanvas.enabled = true;
            timer.StartFillImage();
            await System.Threading.Tasks.Task.Delay(2000);
            timer._timerCanvas.enabled = false;
            triggerAction();
            obj.SetActive(false);            
        }
    }
}
