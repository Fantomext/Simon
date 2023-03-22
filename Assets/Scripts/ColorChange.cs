using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] List<Material> colorList = new List<Material>();
    [SerializeField] SkinnedMeshRenderer selectedButton;
    int choosenMaterial = 0;
    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }


    public void ChangeColor()
    {
        renderer.material = colorList[choosenMaterial];
    }

    public void SetSelectedButton()
    {
        
    }
    
}
