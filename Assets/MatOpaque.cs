using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatOpaque : MonoBehaviour
{
    private void Awake()
    {
        ChangeMat();
    }

    private void ChangeMat()
    {
        Transform[] childArray = GetComponentsInChildren<Transform>();
        foreach (Transform child in childArray)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                Material myMaterial = child.GetComponent<MeshRenderer>().material;
                myMaterial.SetFloat("_Mode", 0); // 0 for Opaque
                myMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                myMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                myMaterial.SetInt("_ZWrite", 1);
                myMaterial.DisableKeyword("_ALPHATEST_ON");
                myMaterial.DisableKeyword("_ALPHABLEND_ON");
                myMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                myMaterial.renderQueue = -1; // Reset the render queue
                child.GetComponent<MeshRenderer>().material = myMaterial;
            }
        }
    }
}
