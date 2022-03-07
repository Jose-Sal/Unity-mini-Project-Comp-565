using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Handler : MonoBehaviour
{
    [SerializeField]
    public Texture texture;
    Renderer ObjRenderer;

    
    public void Shape1()
    {
        ObjRenderer=GetComponent<Renderer>();
    }
    //public void ChangeMaterial()
    //{
    //    ObjRenderer.material.mainTexture = texture;
    //} 
}
