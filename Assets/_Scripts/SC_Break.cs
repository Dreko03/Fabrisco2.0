using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Break : MonoBehaviour
{

    Rigidbody rb;
    public GameObject ps_glass;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.y > 1f || rb.velocity.y < -1f)
        {
            Debug.Log("Velocity at Col : " + rb.velocity.y);
            Instantiate(ps_glass, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
