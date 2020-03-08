using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DoorIn : MonoBehaviour
{
    [SerializeField]
    private GameObject Boundaries;
    [SerializeField]
    private GameObject CountDown;
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject Dooranim;
    private Animator animator;
    public bool doorLocked;
    public bool KeyinUI;
    public CountDown count;

    public bool lvlInProg;
    public bool lvlOver;

    public bool coundownActive;

    void Start()
    {
        lvlOver = false;
        lvlInProg = false;
        doorLocked = false;
        animator = Dooranim.GetComponent<Animator>();
        KeyinUI = false;

    }
    private void Update()
    {

        //KeyinUI = GameObject.FindGameObjectWithTag("Something").GetComponent<Something>().something;
        if(count.levelFail==true)
        {
            KeyinUI = true;
        }
        if(KeyinUI == true)
        {
            lvlOver = true;
        }

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (lvlInProg == false)
            {
                Boundaries.SetActive(true);
                CountDown.SetActive(true);
                coundownActive = true;
                UI.SetActive(true);
                doorLocked = true;
                animator.SetTrigger("Close");
                lvlInProg = true;
            }
            if(KeyinUI==true)
            {
                animator.SetTrigger("Open");

            }
        }
    }


}