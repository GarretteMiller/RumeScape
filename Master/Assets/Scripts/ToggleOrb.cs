using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOrbLight : MonoBehaviour
{
    //Switch between two materials, one for the Orb being lit, another for it being unlit.
    public Material Lit;
    public Material Unlit;
    GameObject Orb;
    [SerializeField]
    private Camera arCamera;
    private Vector2 touchPosition = default;

    void Start()
    {
        
    }


    void Update()
    {
        //Look for touch screen input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                //Use raycast for based on what the camera is facing and where you touched(mousePoistion works for some reason)
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //If object is an Orb
                    if (hit.transform.tag == "Orb")
                    {
                        Orb = hit.collider.gameObject;
                        if (Orb.GetComponent<MeshRenderer>().sharedMaterial == Unlit)
                            Orb.GetComponent<MeshRenderer>().material = Lit;
                        else
                            Orb.GetComponent<MeshRenderer>().material = Unlit;
                    }
                }
            }
        }
    }
}
