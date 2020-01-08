using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Balloon : MonoBehaviour
{
    public float force;
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rb.isKinematic)
        {
            rb.AddForce(new Vector3(0, force, 0), ForceMode.Acceleration);
        }
    }

    public void OnDestroy()
    {
        
    }

}
