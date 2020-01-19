using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Sarbacane : MonoBehaviour
{
    public Transform embout;
    public GameObject bullet;
    GameObject lastBulletFire;
    float chronoEnd;
    public float timeToWait = 2;
    public float speed;

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
        GameObject bulletFired = Instantiate(bullet, embout.position, embout.rotation);
        bulletFired.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * -speed);
    }

    private void ResetChronoStat()
    {
        chronoEnd = timeToWait + Time.time;
    }
}
