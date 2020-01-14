using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Extinguisher : MonoBehaviour
{
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void isActive()
    {
        ps.Play();
    }

    public void isNOTActive()
    {
        ps.Stop();
    }
}
