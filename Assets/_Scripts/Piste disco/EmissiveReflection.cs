using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EmissiveReflection : MonoBehaviour
{
    //create new gameObject
    GameObject probeGameObject = new GameObject("The Reflection Probe");

    void Start()
    {
        // Add the reflection probe component
        ReflectionProbe probeComponent = probeGameObject.AddComponent<ReflectionProbe>() as ReflectionProbe;
        // Set texture resolution
        probeComponent.resolution = 256;  
    }


    void Update()
    {
        
    }
}
