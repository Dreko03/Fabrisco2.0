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

    // Start is called before the first frame update
    void Awake()
    {
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
            tml_transition.Play();
            pisteDisco.SetActive(true);
        }
    }

    public void Desactivate()
    {
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
        foreach (Animator ans in an)
        {
            ans.SetFloat("Multi", animSpeed);
        }
        Timer();
        FPScount();
        timeScale = Time.timeScale;

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

        bool premier = false;
        bool deuxieme = false;

        //if (timers > 10 && !premier)
        //{
        //    UI_Micro.GetComponent<Animator>().SetBool("isActive", true);
        //    premier = true;
        //}
        if (Time.time > 10 && !premier)
        {
            UI_Micro.GetComponent<Animator>().SetBool("isActive", true);
            premier = true;
        }

        if(Time.time > 30 && !deuxieme)
        {
            deuxieme = true;
        }
    }

    public void Change()
    {
        MR_Musee.materials[5] = Resources.Load<Material>("MAT_Wall_2_Disco");
        print("Change Material");
    }

    public void UnChange()
    {
        MR_Musee.materials[5] = MAT_Musee_0;
    }

    public void InstantiationBlackOut()
    {
        print("JE MARCHE !!!");
    }

}
