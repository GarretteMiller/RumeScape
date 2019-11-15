using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOrbLightPC : MonoBehaviour
{
    //Switch between two materials, one for the Orb being lit, another for it being unlit.
    public Material Lit;
    public Material Unlit;
    GameObject Orb;


    void Start()
    {
        
    }

 
    void Update()
    {
        //Look for touch screen input
        if (Input.GetMouseButtonDown (0))
        {
            //Use raycast for based on what the camera is facing and where you touched(mousePoistion works for some reason)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
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
