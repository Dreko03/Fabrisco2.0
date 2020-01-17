using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveVR : MonoBehaviour
{
    MeshRenderer _renderer;

    void Start()
    {       

    }

    
    void Update()
    {         
        float intensity = 3.0f;
        _renderer = this.gameObject.GetComponent<MeshRenderer>();
        Color final = Color.yellow * Mathf.GammaToLinearSpace(intensity);
        Debug.Log(final);
        _renderer.material.SetColor("_EmissionColor", final);
        DynamicGI.SetEmissive(_renderer, final);

    }
}
