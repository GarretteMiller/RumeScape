using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Doors : MonoBehaviour
{
    [SerializeField]
    private GameObject Boundaries;
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject DoorLp;
    [SerializeField]
    private GameObject DoorRp;
    [SerializeField]
    private GameObject DoorLc;
    [SerializeField]
    private GameObject DoorRc;
    private Animator animator;
    public bool doorLocked;
    public bool levelClear;
    public bool Key1inUI;
    public bool Key2inUI;
    public bool doorLockedChildScript;
    public bool levelClearChildScript;

    void Start()
    {
        doorLockedChildScript = true;
        doorLocked = false;
        animator = GetComponent<Animator>();
        Key1inUI = false;
        Key2inUI = false;
        levelClear = false;

    }
    private void Update()
    {
//        levelClearChildScript = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorClose>().levelClearChildScript;
 //       doorLockedChildScript = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorClose>().levelClearChildScript;

        tester();
        if(doorLocked==true)
        {
            DoorOpenOnLevelClear();
        }

    }

    void tester() {
        if (Input.GetMouseButtonDown(0))
        {
            Key1inUI = true;
            Debug.Log("Trueeeeeee");
        }
    }

    void DoorOpenOnLevelClear()
    {
        if (Key1inUI == true || Key2inUI == true)
        {

            //DoorControl("Open");
            animator.SetTrigger("Open");
            /*
            DoorLp.SetActive(false);
            DoorRp.SetActive(false);
            DoorLc.SetActive(true);
            DoorLc.SetActive(true);
            levelClear = true;
            */
        }
    }
    void OnTriggerEnter(Collider col)
    {
        
      if(col.gameObject.tag== "Player")
        {
            if(doorLockedChildScript==false)
            {
                doorLocked = false;
                levelClear = false;
            }
            Debug.Log("It is getting here!");
            if (doorLocked == false)
            {
                animator.SetTrigger("Open");
                DoorLc.SetActive(false);
                DoorRc.SetActive(false);
                DoorLp.SetActive(true);
                DoorRp.SetActive(true);
                Debug.Log("This works");
                animator.SetTrigger("Close");
                doorLocked = true;
                Boundaries.SetActive(true);
                UI.SetActive(true);



            }

            
        }

    }

    }
