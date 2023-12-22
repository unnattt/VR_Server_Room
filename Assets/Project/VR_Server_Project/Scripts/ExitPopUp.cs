using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace VR_Server_Room.UI
{
    public class ExitPopUp : MonoBehaviour
    {
        public InputActionReference menuButtonReference;
        private Canvas canvas;
        //private TrackedDeviceGraphicRaycaster graphicsRaycaster;

        private void Awake()
        {
            //DontDestroyOnLoad(gameObject);
            canvas = GetComponent<Canvas>();
            //graphicsRaycaster = GetComponent<TrackedDeviceGraphicRaycaster>();
        }
        private void OnEnable()
        {
            menuButtonReference.action.performed += OnMenuButtonPressed;
        }
        private void OnDisable()
        {
            menuButtonReference.action.performed -= OnMenuButtonPressed;
        }
        private void Start()
        {
            Hide();
        }

        private void OnMenuButtonPressed(InputAction.CallbackContext obj)
        {
            Debug.Log("OnMenuPressed");
            if (XRPlayer.instance != null)
            {
                XRPlayer.instance.SetObjectInPlayerCameraForward(transform);
                Show();
            }
        }

        public void OnGameOver()
        {
            XRPlayer.instance.SetObjectInPlayerCameraForward(transform);
            Show();
        }

        public void OnYesClicked()
        {
            SceneManager.LoadScene(0);
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

    }
}
