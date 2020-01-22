using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_PhysicsMusee : MonoBehaviour
{
    ChangeTheWorld ctw;
    Animator an;
    bool changed = false;
    public List<Rigidbody> rigidbodiesToDesactivate;

    void Awake()
    {
        ctw = GetComponent<ChangeTheWorld>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ctw.isChanged && !changed)
        {
            foreach (Rigidbody rb in rigidbodiesToDesactivate)
            {
                rb.detectCollisions = false;
                rb.useGravity = false;
                rb.isKinematic = true;
            }

            Invoke("DisableAnimator", 1.1f);
            changed = true;
        }

        else if (!ctw.isChanged && !changed)
        {
            foreach (Rigidbody rb in rigidbodiesToDesactivate)
            {
                rb.detectCollisions = false;
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }

        else if (!ctw.isChanged && changed)
        {
            foreach (Rigidbody rb in rigidbodiesToDesactivate)
            {
                rb.detectCollisions = false;
                rb.useGravity = false;
            }
            an.enabled = true;
            changed = false;
        }
    }

    public void DisableAnimator()
    {
        foreach (Rigidbody rb in rigidbodiesToDesactivate)
        {
            rb.detectCollisions = true;
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        an.enabled = false;
    }
}