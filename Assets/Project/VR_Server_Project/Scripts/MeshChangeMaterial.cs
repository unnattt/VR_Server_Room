using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR_Server_Room.CoreGamePlay
{
    public class MeshChangeMaterial : MonoBehaviour
    {
        [SerializeField] private VR_Server_Room.UI.ServerRoomPopUp step3,step4;        
        [SerializeField] private List<SkinnedMeshRenderer> totalMesh;
        [SerializeField] private MeshRenderer mesh;
        [SerializeField] private Material[] materials;

        private void Start()
        {
            //MachineWorking();
        }

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

        public void MachineWorking()
        {
            //mesh.materials[0].color = materials[1];

            //Material[] materials = mesh.materials;

            // Create a new array to store modified materials
            Material[] newMaterials = new Material[mesh.materials.Length];

            newMaterials[0] = materials[1];
            newMaterials[1] = mesh.materials[1];
            newMaterials[2] = mesh.materials[2];
            mesh.materials = newMaterials;

            //Debug.Log(mesh.materials[0].name + "It Change Color" + materials[1].name);
        }


        //         if (meshRenderer != null && newMaterial != null)
        //        {
        //            // Get the current material instances
        //            Material[] materials = meshRenderer.materials;

        //        // Create a new array to store modified materials
        //        Material[] newMaterials = new Material[materials.Length];

        //            // Modify the instances in the new array
        //            for (int i = 0; i<materials.Length; i++)
        //            {
        //                newMaterials[i] = newMaterial; // You can perform more complex modifications here if needed
        //            }

        //    // Assign the updated materials array back to the meshRenderer
        //    meshRenderer.materials = newMaterials;
        //        }
        //        else
        //{
        //    Debug.LogError("MeshRenderer or newMaterial is null. Make sure to assign them in the inspector.");
        //}
        public void MachineNotWorking()
        {
            Material[] newMaterials = new Material[mesh.materials.Length];

            newMaterials[0] = materials[0];
            newMaterials[1] = mesh.materials[1];
            newMaterials[2] = mesh.materials[2];
            mesh.materials = newMaterials;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<XRDirectInteractor>())
            {
                Debug.Log("Is GLoves Trigger");
                CorrectColor();
                step3.Hide();
                step4.Show();
                this.gameObject.SetActive(false);
            }
        }
    }
}
