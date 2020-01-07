using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Leak : MonoBehaviour
{
    public ParticleSystem ps_leak;
    public GameObject ps_glass;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ps_leak = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {

        if (rb.isKinematic)
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.21f, 0), transform.up);
            Ray ray = new Ray(transform.position + new Vector3(0, 0.21f, 0), transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 9))
            {
                if (!ps_leak.isPlaying)
                {
                    ps_leak.Play();
                }
            }
            else
            {
                if (ps_leak.isPlaying)
                    ps_leak.Stop();
            }
        }
        else
        {
            ps_leak.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(rb.velocity.y > 1f || rb.velocity.y < -1f)
        {
            Debug.Log("Velocity at Col : " + rb.velocity.y);
            Instantiate(ps_glass, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
