using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_TableChairs : MonoBehaviour
{
    public GameObject table;
    public Transform spawnTransform;
    
    public void InstantiateTable()
    {
         Instantiate(table, spawnTransform.position, Quaternion.identity);
    }
}
