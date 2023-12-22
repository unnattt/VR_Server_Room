using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR_Server_Room.UI
{
    public class ServerRoomPopUp : MonoBehaviour
    {
        private Canvas canvas;
        //private TrackedDeviceGraphicRaycaster graphicsRaycaster;

        private void Awake()
        {
            //DontDestroyOnLoad(gameObject);
            canvas = GetComponent<Canvas>();
            //graphicsRaycaster = GetComponent<TrackedDeviceGraphicRaycaster>();
        }

        private void Start()
        {
            //Hide();
        }

        public void OnNoClicked()
        {
            Hide();
        }

        public void Show()
        {
            canvas.enabled = true;
            //graphicsRaycaster.enabled = true;
        }
        public void Hide()
        {
            canvas.enabled = false;
            //graphicsRaycaster.enabled = false;
        }


        public void QuitRoom()
        {
            Application.Quit();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
