using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SarbacaneBall : MonoBehaviour
{
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            Destroy(collision.gameObject);
            audio.Play();
            Invoke("Destroyage", 10f);
        }
    }

    void Destroyage()
    {
        Destroy(gameObject);
    }
}
