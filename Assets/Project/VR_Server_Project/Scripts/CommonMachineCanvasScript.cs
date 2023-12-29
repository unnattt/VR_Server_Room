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
     
        public Image targetImage;        
        public float fadeDuration = 2f;
        public float pauseDuration = 1f;

        private void Start()
        {
            StartCoroutine(FadeInOutLoop());
        }

        private IEnumerator FadeInOutLoop()
        {
            while (true)
            {
                yield return StartCoroutine(Fade(1f, 0f)); // Fade In
                yield return new WaitForSeconds(pauseDuration); // Pause
                yield return StartCoroutine(Fade(0f, 1f)); // Fade Out
                yield return new WaitForSeconds(pauseDuration); // Pause
            }
        }

        private IEnumerator Fade(float startAlpha, float targetAlpha)
        {
            float elapsedTime = 0f;
            Color originalColor = targetImage.color;
            Color originalColor1 = imageOfErrorComp.color;
            Color originalColor2 = imageOfError.color;
            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
                targetImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                imageOfErrorComp.color = new Color(originalColor1.r, originalColor1.g, originalColor1.b, alpha);
                imageOfError.color = new Color(originalColor2.r, originalColor2.g, originalColor2.b, alpha);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the final alpha value is exactly the target alpha
            targetImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
        }

      
    }


}
