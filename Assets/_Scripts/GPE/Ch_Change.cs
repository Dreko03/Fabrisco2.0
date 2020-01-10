using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Change : MonoBehaviour
{
    Animator an;
    public float Anim_Multiplier = 1;

    private void Awake()
    {
        an = GetComponent<Animator>();
    }

    public void Change()
    {
        an.SetBool("Change", true);
        an.SetFloat("Multi", Anim_Multiplier);
    }

    public void Unchange()
    {
        an.SetBool("Change", false);
        an.SetFloat("Multi", Anim_Multiplier);
    }
}
