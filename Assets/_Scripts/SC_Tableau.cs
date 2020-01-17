using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Tableau : MonoBehaviour
{
    public Material tableau;
    public Texture[] texture;
    int init = 0;
    // Start is called before the first frame update
    void Start()
    {
        init = 0;
        InvokeRepeating("PaintingDisplay", 1, 0.05f);
    }

    public void PaintingDisplay()
    {
        if (init == texture.Length)
        {
            init = 0;
        }

        tableau.mainTexture = texture[init];
        init++;
    }
}
