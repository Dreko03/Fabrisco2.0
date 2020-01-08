using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Sarbacane : MonoBehaviour
{
    public Transform embout;
    public GameObject bullet;
    GameObject lastBulletFire;
    float chronoEnd;
    public float timToWait = 2;

    // Start is called before the first frame update
    void Start()
    {
        ResetChronoStat();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Head")
        {
            if (chronoEnd < Time.time)
            {
                Shoot();
                ResetChronoStat();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, embout.position, embout.rotation);
    }

    private void ResetChronoStat()
    {
        chronoEnd = timToWait + Time.time;
    }
}
