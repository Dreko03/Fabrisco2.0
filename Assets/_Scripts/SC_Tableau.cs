using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Tableau : MonoBehaviour
{
    public Material tableau;
    public Texture[] texture;
    int init = 0;

    public GameManager gm;

    private void Awake()
    {
        gm = GetComponent<GameManager>();
    }

    void Start()
    {
        init = 0;
        if (gm.discoActive)
        {
            InvokeRepeating("PaintingDisplay", 1, 0.033f);
        }
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
