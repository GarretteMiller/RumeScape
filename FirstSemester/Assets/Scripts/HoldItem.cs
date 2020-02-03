using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class HoldItem : MonoBehaviour
{
    
    
    public Transform destinationTransform;
    public Material newMaterial;
    public float dist;

    Camera cam;
    Rigidbody rb;
    private Transform originalParent;
    private bool beingHeld = false;
    Renderer m_Renderer;
    Material temp;
    private float radius = 1f;

    void Start()
    {
        originalParent = transform.parent;
        m_Renderer = GetComponent<MeshRenderer>();
        temp = m_Renderer.material;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerController>().cam;
    }


    void Update()
    {
        dist = Vector3.Distance(cam.transform.position, transform.position);
        TriggerOutline();
    }

    public void ItemInteraction(GameObject item)
    { 

        if (!beingHeld && dist <= radius)
        {
            rb = item.GetComponent<Rigidbody>();
            item.transform.position = destinationTransform.position;
            item.transform.parent = destinationTransform;
            rb.isKinematic = true;
            beingHeld = true;
        }
        else if (beingHeld)
        {
            rb.isKinematic = false;
            item.transform.parent = originalParent;
            beingHeld = false;
        }  
    }
    void TriggerOutline()
    {
        if (dist <= radius && !beingHeld)
        {
            m_Renderer.material = newMaterial;
        }
        else
        {
            m_Renderer.material = temp;
        }
    }
}
