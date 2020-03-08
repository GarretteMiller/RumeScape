using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    private GameObject pm;
    [SerializeField]
    private GameObject pmbutton;
    public void Unpause()
    {
        pm.SetActive(false);
        pmbutton.SetActive(true);
    }
}
