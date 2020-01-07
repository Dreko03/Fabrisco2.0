using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Bar : MonoBehaviour
{
    Animator an;

    private void Awake()
    {
        an = GetComponentInChildren<Animator>();
    }

    public void Change()
    {
        an.SetBool("Rise", true);
    }

    public void Unchange()
    {
        an.SetBool("Rise", false);
    }
}
