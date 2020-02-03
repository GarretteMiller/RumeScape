using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DoorClose : MonoBehaviour
{

    private Animator animator;
    private bool doorOpen;
    public bool doorLocked;
    public bool levelClear;
    public bool Key1inUI;
    public bool Key2inUI;
    [SerializeField]
    private GameObject DoorLp;
    [SerializeField]
    private GameObject DoorRp;
    [SerializeField]
    private GameObject DoorLc;
    [SerializeField]
    private GameObject DoorRc;
    [SerializeField]
    private GameObject Puzzle1;
    [SerializeField]
    private GameObject Puzzle2;
    [SerializeField]
    private GameObject Boundaries;
    public bool doorLockedChildScript;
    public bool levelClearChildScript;

    private void Update()
    {
        levelClear = GameObject.FindGameObjectWithTag("Door").GetComponent<Doors>().levelClear;
        doorLocked = GameObject.FindGameObjectWithTag("Door").GetComponent<Doors>().doorLocked;
        doorLockedChildScript = doorLocked;
        levelClearChildScript = levelClear;
    }

    void Awake()
    {
        Key1inUI = false;
        Key2inUI = false;
        doorOpen = false;
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            
            if (levelClear == true)
            {
                DoorLp.SetActive(false);
                DoorRp.SetActive(false);
                DoorLc.SetActive(true);
                DoorRc.SetActive(true);
                Boundaries.SetActive(false);
                animator.SetTrigger("Close");
                if (Key1inUI == true)
                {
                    Puzzle1.SetActive(false);
                    Puzzle2.SetActive(true);
                }
                doorOpen = false;
                levelClear = false;
                doorLocked = false;
            }
            
            if (doorOpen != true)
            {
                if (doorLocked != true)
                {
                    doorOpen = true;
                    Debug.Log("This works");
                    animator.SetTrigger("Open");
                    //DoorControl("Open");
                }
            }
        }
    }    
}
