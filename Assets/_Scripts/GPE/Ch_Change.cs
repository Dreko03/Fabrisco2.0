using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Change : MonoBehaviour
{
    Animator an;

    private void Awake()
    {
        an = GetComponent<Animator>();
    }

    public void Change()
    {
        an.SetBool("Change", true);
    }

    public void Unchange()
    {
        an.SetBool("Change", false);
    }
}
