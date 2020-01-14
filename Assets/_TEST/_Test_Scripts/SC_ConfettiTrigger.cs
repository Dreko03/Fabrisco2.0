using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ConfettiTrigger : MonoBehaviour
{
    public GameObject Canon;
    public ParticleSystem ps_Confetti;
    public AudioSource as_Confetti;

    private void Awake()
    {
        ps_Confetti = Canon.GetComponent<ParticleSystem>();
        as_Confetti = Canon.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void OnJointBreak(float breakForce)
    {
        ConfettiExplosion();
    }

    public void ConfettiExplosion()
    {
        ps_Confetti.Play();
        as_Confetti.Play();
    }
}
