using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Tableau : MonoBehaviour
{
    public Material tableau;
    public Texture[] texture;
    int init = 0;
    public int base_Image, start_Loop;

    public GameManager gm;

    private void Awake()
    {
        gm = GetComponent<GameManager>();
    }

    private void Start()
    {
        init = base_Image;
        Invoke("PaintingDisplay", 0f);
    }

    public void Tableau_Loop()
    {
        init = start_Loop;
        InvokeRepeating("PaintingDisplay", 1, 0.033f);
    }

    public void PaintingDisplay()
    {
        if (init == texture.Length)
        {
            init = start_Loop;
        }

        tableau.mainTexture = texture[init];
        init++;
    }
}
