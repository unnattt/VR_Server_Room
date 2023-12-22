using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

namespace VR_Server_Room.CoreGamePlay
{
    public class MeshChangeMaterial : MonoBehaviour
    {
        [SerializeField] private GameObject buttonNext;
        [SerializeField] private List<SkinnedMeshRenderer> totalMesh;
        [SerializeField] private List<Material> materials;

        public void ErrorColor()
        {
            foreach (SkinnedMeshRenderer meshRenderer in totalMesh)
            {
                meshRenderer.material = materials[0];
            }
        }

        public void CorrectColor()
        {
            foreach (SkinnedMeshRenderer meshRenderer in totalMesh)
            {
                meshRenderer.material = materials[1];
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<XRDirectInteractor>())
            {
                Debug.Log("Is GLoves Trigger");
                CorrectColor();
                buttonNext.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
