using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Tableaux : MonoBehaviour
{
    Animator an;

    private void Awake()
    {
        an = GetComponent<Animator>();
    }

    public void Change()
    {
        an.SetBool("rotateTab", true);
    }

    public void Unchange()
    {
        an.SetBool("rotateTab", false);
    }
}
