using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VR_Server_Room.UI
{
    public class ServerRoomPopUp : MonoBehaviour
    {
        private Canvas canvas;
       
        private void Awake()
        {            
            canvas = GetComponent<Canvas>();            
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
        }

        public void Hide()
        {
            canvas.enabled = false;        
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
