using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOrb : MonoBehaviour
{
    public Material Lit;
    public Material Unlit;
    private bool itemLit;
    public float radius;
    Renderer m_Renderer;
    Material temp;
    public Material newMaterial;
    public float dist;
    Camera cam;
    private bool isSolved = false;

    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerController>().cam;
    }

    private void Update()
    {
         dist = Vector3.Distance(cam.transform.position, transform.position);
         TriggerOutline();
        isSolved = GameObject.FindGameObjectWithTag("Screen").GetComponent<ChangeScreen>().checkIfSolved();
    }

    void TriggerOutline()
    {
        if (!itemLit)
        {
            if (dist <= radius && !isSolved)
            {
                m_Renderer.material = newMaterial;
            }
            else
            {
               m_Renderer.material = Unlit;
            }
        }
    }

    public void LightOrb(GameObject Orb)
    {
        if (dist <= radius && !isSolved)
        {
            if (Orb.GetComponent<MeshRenderer>().sharedMaterial == newMaterial)
            {
                Orb.GetComponent<MeshRenderer>().material = Lit;
                itemLit = true;
            }
            else
            {
                Orb.GetComponent<MeshRenderer>().material = Unlit;
                itemLit = false;
            }
        }
    }
}
