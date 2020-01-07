using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDisco : MonoBehaviour
{

    public float vitesse;  

    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.Rotate(0, vitesse *Time.deltaTime, 0);
    }
}
