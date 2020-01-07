using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Dancefloor : MonoBehaviour
{
    Animator an;

    private void Awake()
    {
        an = GetComponent<Animator>();
    }

    public void Change()
    {
        an.SetBool("rotateDancefloor", true);
    }

    public void Unchange()
    {
        an.SetBool("rotateDancefloor", false);
    }
}
