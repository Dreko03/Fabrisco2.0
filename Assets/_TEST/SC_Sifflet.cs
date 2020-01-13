using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Sifflet : MonoBehaviour
{
    public AudioSource audio;
    public Animator an;

    // Start is called before the first frame update
    void Awake()
    {
        an = GetComponentInParent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Head")
        {
            an.SetBool("isWhistling", true);
            audio.Play();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Head")
        {
            an.SetBool("isWhistling", false);
        }
    }
}
