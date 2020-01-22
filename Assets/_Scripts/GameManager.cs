using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public bool discoActive;
    public AudioSource[] AudioSources;
    public Transform CamPos;
    public Collider[] viewedObjects;
    public float capsuleLength, capsuleRadius;
    public ChangeTheWorld[] GPEs;
    public float fps, timeScale;
    public Text fpstxt, timetxt;
    public PlayableDirector tml_transition;
    public float timers;
    public GameObject UI_Micro;
    public Animator UI_BlackScreen;
    public Material[] MAT_Museum;
    public GameObject m_Museum;
    public Animator[] an;
    public float animSpeed;
    public GameObject pisteDisco;

    public GameObject table;
    public Transform[] table_spawner;
    public MeshRenderer MR_Musee;
    public Material MAT_Musee_0, MAT_Musee_1;

    public bool isLate = false, isLilLate = false;
    public Animator spotLight, direcLight, planeEmissive;

    public MeshRenderer Musee, MuseeDisco;

    public bool discoActivated = false;
    public UnityEvent tableauG_Loop, tableauP_Loop, tableauG_Stop, tableauP_Stop;

    public GameObject[] lightsToActivate;

    // Start is called before the first frame update
    void Awake()
    {
        MuseeDisco.enabled = false;
        GPEs = FindObjectsOfType<ChangeTheWorld>();
        pisteDisco.SetActive(false);
        //Time.captureFramerate = 90;
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 20;
        //MAT_Museum = m_Museum.GetComponent<MeshRenderer>()
    }


    public void Activate()
    {
        if (!discoActive)
        {
            planeEmissive.SetBool("Change", true);
            tml_transition.Play();
            pisteDisco.SetActive(true);
            isLate = true;
            isLilLate = true;
            direcLight.SetBool("Desactivate", true);
            spotLight.SetBool("Activate", false);
        }
    }

    public void Desactivate()
    {
        direcLight.SetBool("Desactivate", false);
        planeEmissive.SetBool("Change", false);
        pisteDisco.SetActive(false);
        discoActive = false;
        foreach (AudioSource As in AudioSources)
        {
            As.Stop();
            As.pitch = 1f;
        }

        foreach (ChangeTheWorld reverseEvent in GPEs)
        {
            reverseEvent.isChanged = false;
            reverseEvent.RevertChanges.Invoke();
        }

        UnChange();
    }

    // Update is called once per frame
    void Update()
    {

        if(discoActive && !discoActivated)
        {
            tableauG_Loop.Invoke();
            tableauP_Loop.Invoke();
            discoActivated = true;
        }

        foreach (Animator ans in an)
        {
            ans.SetFloat("Multi", animSpeed);
        }
        Timer();
        FPScount();
        //timeScale = Time.timeScale;

        if (discoActive)
        {
            //viewedObjects = Physics.OverlapCapsule(CamPos.position, CamPos.position + new Vector3(0, 0, capsuleLength), capsuleRadius);
            viewedObjects = Physics.OverlapCapsule(CamPos.position, CamPos.position + (CamPos.forward * capsuleLength), capsuleRadius, 1024);

            foreach (Collider viewedObjectsCol in viewedObjects)
            {
                if (viewedObjectsCol.gameObject.GetComponent<ChangeTheWorld>() && !viewedObjectsCol.gameObject.GetComponent<ChangeTheWorld>().isChanged)
                {
                    ChangeTheWorld compatibleObject = viewedObjectsCol.gameObject.GetComponent<ChangeTheWorld>();
                    compatibleObject.ChangeSomething.Invoke();
                    compatibleObject.isChanged = true;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (discoActive)
        {
            Gizmos.DrawSphere(CamPos.position, capsuleRadius);
            Gizmos.DrawSphere(CamPos.position + (CamPos.forward * capsuleLength), capsuleRadius);
        }
    }

    public void FPScount()
    {
        fps = 1 / Time.deltaTime;
        fps = Mathf.Round(fps);
        timetxt.text = "" + timeScale;
        fpstxt.text = "" + fps;
        if (fps >= 80)
        {
            fpstxt.color = Color.green;
        }
        else
        {
            fpstxt.color = Color.yellow;
        }
    }

    public void Transition()
    {
        UI_BlackScreen.SetBool("BlackScreenON", true);
    }

    public void TransitionEnd()
    {
        Change();
        UI_BlackScreen.SetBool("BlackScreenON", false);
        discoActive = true;
        foreach (AudioSource As in AudioSources)
        {
            As.Play();
        }
    }

    public void Timer()
    {
        //timers += Time.deltaTime;

       isLilLate = false;

        if (Time.time > 10 && !isLilLate)
        {
            UI_Micro.GetComponent<Animator>().SetBool("isActive", true);
            isLilLate = true;
        }

        if(Time.time > 20 && !isLate)
        {
            
            direcLight.SetBool("Desactivate", true);
            spotLight.SetBool("Activate", true);
            isLate = true;
        }
    }

    public void Change()
    {
        foreach (GameObject lights in lightsToActivate)
        {
            lights.SetActive(true);
        }

        MuseeDisco.enabled = true;
        Musee.enabled = false;
    }

    public void UnChange()
    {
        foreach (GameObject lights in lightsToActivate)
        {
            lights.SetActive(false);
        }

        
        tableauG_Stop.Invoke();
        tableauP_Stop.Invoke();
        Musee.enabled = true;
        MuseeDisco.enabled = false;
        discoActivated = false; 
    }

}
