using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOrb : Interactable
{
    public Material Lit;
    public Material Unlit;

    public void LightOrb(GameObject Orb)
    {
        if (Orb.GetComponent<MeshRenderer>().sharedMaterial == Unlit)
            Orb.GetComponent<MeshRenderer>().material = Lit;
        else
            Orb.GetComponent<MeshRenderer>().material = Unlit;
    }
}