using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Physics1 : MonoBehaviour
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

    void Update()
    {
        if (ctw.isChanged && !changed)
        {
            DisablePhysics();
            Invoke("DisableAnimator", 1.1f);
            changed = true;
        }

        else if (!ctw.isChanged && !changed)
        {
            DisablePhysics();
        }

        else if (!ctw.isChanged && changed)
        {
            DisablePhysics();
            DisableAnimator();
            changed = false;
        }
    }

    public void DisableAnimator()
    {
        an.enabled = false;
    }

    public void DisablePhysics()
    {
        foreach (Rigidbody rb in rigidbodiesToDesactivate)
        {
            rb.detectCollisions = false;
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        an.enabled = true;
    }

    public void EnablePhysics()
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
