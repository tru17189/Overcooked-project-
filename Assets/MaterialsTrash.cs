using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MaterialsTrash : MonoBehaviour
{
    private Material original;
    public Material resaltado;
    private Material[] materials;
    private Renderer Newrenderer;
    // Start is called before the first frame update
    void Start()
    {
        Newrenderer = GetComponentInChildren<Renderer>();
        materials = Newrenderer.materials;
        original = materials[0];
    }


    public void Highlight()
    {
        materials[0] = resaltado;
        Newrenderer.materials = materials;
    }

    public void RemoveHighlight()
    {
        materials[0] = original;
        Newrenderer.materials = materials;
    }

}
