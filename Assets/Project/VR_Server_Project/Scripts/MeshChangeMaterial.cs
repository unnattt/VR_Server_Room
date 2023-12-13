using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChangeMaterial : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> totalMesh;
    [SerializeField] private List<Material> materials;
  
    public void ErrorColor()
    {
        foreach (MeshRenderer meshRenderer in totalMesh)
        {
            meshRenderer.material = materials[0];
        }
    }

    public void CorrectColor()
    {
        foreach (MeshRenderer meshRenderer in totalMesh)
        {
            meshRenderer.material = materials[1];
        }
    }
}
