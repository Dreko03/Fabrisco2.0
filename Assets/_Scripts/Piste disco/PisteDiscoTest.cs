using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//décortiquer se dont j'ai besoin
//établir un plan de travail logique
//utiliser la documentation
//utiliser les debugger pour savoir dans quelle direction je vais

public class PisteDiscoTest : MonoBehaviour
{   
    public MeshRenderer[] meshes;
    public List<MeshRenderer> EmissiveMeshes = new List<MeshRenderer>();
    public Material[] materials;

    int getArrayElements;
    int getEmissivesMaterials;
    public int CubeNumbers = 0;  
    
    public float delayRandomSequence;

    void Start()
    {
        GetAllChildrenMeshes();
        TurnOffSequences();      
        StartCoroutine(SwitchSequences(delayRandomSequence));
    }
    
    //créer un tableau répertoriant tout les meshComponent (scripts) des cubes de ma piste disco
    public void GetAllChildrenMeshes()
    {
        meshes = this.gameObject.GetComponentsInChildren<MeshRenderer>();          
    }


    public void RandomSequence()
    {
        //Réinitialise ma liste (nettoyage des éléments précédents)
        EmissiveMeshes.Clear();

        //tant que le taille du tableau EmissiveMeshes est infèrieur à mon nombre de cubes emissifs voulues
        while (EmissiveMeshes.Count < CubeNumbers)
        {
            getArrayElements = Random.Range(0, meshes.Length - 1); //  prend un nombre aléatoire de la liste                    
            //Debug.Log(getArrayElements);
            //si ma liste emissiveMeshes contient déjà ma valeur aléatoire           
            if (!EmissiveMeshes.Contains(meshes[getArrayElements]))
            {
                //permet d'ajouter mes variables getArrayElements du tableau meshes dans la liste EmissiveMeshes
                EmissiveMeshes.Add(meshes[getArrayElements]);
            }
        }                               
        TurnOn();
    }      

     //permet de reset tout les materials à chaque séquence aléatoire
    public void TurnOffSequences()
    {
        for (int i = 0; i < EmissiveMeshes.Count; i++)
        {
            EmissiveMeshes[i].material = materials[0];
        }
    }

     //permet de changer de material emissif
    public void TurnOn()
    {
        foreach (MeshRenderer emissif in EmissiveMeshes)
        {           
            for (int x = 0; x < EmissiveMeshes.Count; x++)
            {
                getEmissivesMaterials = Random.Range(0, materials.Length - 1);
                emissif.material = materials[getEmissivesMaterials];                
            }
        }
    }

    IEnumerator SwitchSequences(float delay)
    {
        yield return new WaitForSeconds(delay);
        TurnOffSequences();
        RandomSequence();
        yield return new WaitForSeconds(delay);
        TurnOffSequences();
        RandomSequence();
        yield return new WaitForSeconds(delay);
        TurnOffSequences();
        RandomSequence();
        yield return new WaitForSeconds(delay);
        TurnOffSequences();
        RandomSequence();
        yield return new WaitForSeconds(delay);
        //TurnOffSequences();
        StartCoroutine(SwitchSequences(delayRandomSequence));
    }
}


