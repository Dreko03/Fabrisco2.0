using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SarbacaneBall : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(gameObject.transform.forward * speed);
        print(gameObject.transform.forward * speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            Destroy(collision.gameObject);
        }
    }
}
