using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveVR : MonoBehaviour
{
    MeshRenderer _renderer;

    void Start()
    {
        _renderer = this.gameObject.GetComponent<MeshRenderer>();
    }

    
    void Update()
    {         
        float intensity = 3.0f;        
        Color final = Color.yellow * Mathf.GammaToLinearSpace(intensity);        
        _renderer.material.SetColor("_EmissionColor", final);
        Debug.Log("rendu:" +_renderer + final);
        DynamicGI.SetEmissive(_renderer, final);       
    }  
}
