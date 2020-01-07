using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PisteDisco : MonoBehaviour
{    
    public Sequence[] sequences = new Sequence[2];
    
    public int currentSequence = 0;
    public float delay;

    void Start()
    {       
        StartCoroutine(SwitchSequences(delay));
    }

    public void BoucleTurnOff()
    {
        foreach (Sequence sequence in sequences)
        {
            sequence.TurnOffSequences();
        }
    }
    
    IEnumerator SwitchSequences(float delay)
    {
        yield return new WaitForSeconds(delay);
        BoucleTurnOff();
        currentSequence = 0;
        sequences[currentSequence].TurnOn();
        yield return new WaitForSeconds(delay);
        BoucleTurnOff();
        currentSequence = 1;
        sequences[currentSequence].TurnOn();
        yield return new WaitForSeconds(delay);
        BoucleTurnOff();
        currentSequence = 2;
        sequences[currentSequence].TurnOn();
        yield return new WaitForSeconds(delay);
        BoucleTurnOff();
        currentSequence = 3;
        sequences[currentSequence].TurnOn();
        yield return new WaitForSeconds(delay);
        BoucleTurnOff();
        StartCoroutine(SwitchSequences(3f));
    }

    void Update()
    {
        
    }

    [System.Serializable]
    public class Sequence
    {
        public MeshRenderer[] cells;
        public Material[] materials;

        public void TurnOffSequences()
        {
            for (int i = 0; i < cells.Length; i++)
            {                             
                cells[i].material = materials[0];              
            }
        }
        
        public void TurnOn()
        {
            foreach (MeshRenderer light in cells)
            {
                for (int x = 0; x < materials.Length; x++)
                {                                       
                    light.material = materials[x];
                }               
            }
        }    
    }
}


