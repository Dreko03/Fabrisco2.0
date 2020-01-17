using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveVR : MonoBehaviour
{
    public MeshRenderer _renderer;

    void Start()
    {
        
    }

    
    void Update()
    {         
        float intensity = 5.0f;
        _renderer = this.gameObject.GetComponent<MeshRenderer>();
        Color final = Color.white * Mathf.LinearToGammaSpace(intensity);
        _renderer.material.SetColor("_EmissionColor", final);
        DynamicGI.SetEmissive(_renderer, final);

    }
}
