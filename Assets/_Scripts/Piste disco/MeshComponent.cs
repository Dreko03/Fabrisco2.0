using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshComponent : MonoBehaviour
{
    public MeshRenderer thismesh;
    
    void Start()
    {
        thismesh = this.gameObject.GetComponent<MeshRenderer>();
    }  
}
