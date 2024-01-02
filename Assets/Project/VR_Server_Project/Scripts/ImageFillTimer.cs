using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VR_Server_Room.UI
{
    public class ImageFillTimer : MonoBehaviour
    {
        public Canvas _timerCanvas;
        public Image fillImage;
        public float fillDuration;
        
        public void StartFillImage()
        {
            StartCoroutine(FillImageCoroutine());
        }

        private IEnumerator FillImageCoroutine()
        {
            float timer = 0f;

            while (timer < fillDuration)
            {
                float fillAmount = Mathf.Lerp(0f, 1f, timer / fillDuration);
                fillImage.fillAmount = fillAmount;

                // Increase the timer based on the time passed since the last frame
                timer += Time.deltaTime;

                yield return null; // Wait for the next frame
            }

            // Ensure that the fill amount is exactly 1 when the coroutine finishes
            fillImage.fillAmount = 1f;
            yield return new WaitForSeconds(1);
            fillImage.fillAmount = 0f;
        }
    }
}
