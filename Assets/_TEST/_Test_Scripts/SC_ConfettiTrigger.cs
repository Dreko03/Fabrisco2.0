using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ConfettiTrigger : MonoBehaviour
{
    public GameObject Canon;
    public ParticleSystem ps_Confetti;
    public AudioSource as_Confetti;
    bool exploded = false;
    private void Awake()
    {
        ps_Confetti = Canon.GetComponent<ParticleSystem>();
        as_Confetti = Canon.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Vector3.Distance(Canon.transform.position, transform.position) > 0.5f && exploded == false)
        {
            ConfettiExplosion();
            //exploded = true;
        }
    }

    public void ConfettiExplosion()
    {
        ps_Confetti.Play();
        as_Confetti.Play();
    }
}
