using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SC_Disc : MonoBehaviour
{
    public AudioSource[] AudioSources;
    public Animator[] ans, ansss;
    public List<Animator> anss;
    public AnimationState anims;
    public CircularDrive circularDrive;
    public Interactable interactComponent;
    public LinearMapping linearMapping;
    public float outAngle;
    public float rotationValue;
    public float linearMapValue;
    public float globalMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        AudioSources = FindObjectOfType<GameManager>().AudioSources;
        ans = FindObjectsOfType<Animator>();
        circularDrive = GetComponent<CircularDrive>();
        interactComponent = GetComponent<Interactable>();
        outAngle = circularDrive.outAngle;
    }

    void Start()
    {

        linearMapping = GetComponent<LinearMapping>();

        foreach (Animator ani in ans)
        {
            if(ani.gameObject.tag == "reversable")
            {
                anss.Add(ani);
            }
        }

        ansss = anss.ToArray();
    }

    public void Update()
    {


        transform.Rotate(0, rotationValue * Time.deltaTime, 0, Space.World);
        if (linearMapping.value > linearMapValue)
        {
            Accelerate(linearMapping.value - linearMapValue);
        }
        else if (linearMapping.value < linearMapValue)
        {
            Decelerate(linearMapValue - linearMapping.value);
        }
        else
        {
            Reset();
        }
        linearMapValue = linearMapping.value;
    }

    // Update is called once per frame
    public void Accelerate(float multiplier)
    {
        foreach (AudioSource As in AudioSources)
        {
            As.pitch += multiplier * globalMultiplier;
        }

        foreach (Animator an in ansss)
        {
            an.SetFloat("Multiplier", 1 + (multiplier * globalMultiplier));
        }
    }

    public void Decelerate(float multiplier)
    {
        foreach (AudioSource As in AudioSources)
        {
            if(As.pitch <= -1)
            {
                As.pitch = -1;
            }
            else
            {
                As.pitch -= multiplier * globalMultiplier;
            }
        }
        foreach (Animator an in ansss)
        {
            an.SetFloat("Multiplier", -1 - (multiplier * globalMultiplier));
        }
    }

    public void Reset()
    {
        foreach (AudioSource As in AudioSources)
        {
            As.pitch = 1f;
        }
        foreach (Animator an in ansss)
        {
            an.SetFloat("Multiplier", 1f);
        }
    }
}
