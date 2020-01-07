using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Destroy : MonoBehaviour
{
    public float delai;

    private void Start()
    {
        Invoke("Destroy", delai);
    }
    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
