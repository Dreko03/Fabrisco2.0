using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Balloon : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, force, 0));
    }
}
