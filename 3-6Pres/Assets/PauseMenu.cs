using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pm;
    [SerializeField]
    private GameObject pmbutton;
    public void pMenu()
    {
        if (!pm.activeSelf)
            pm.SetActive(true);
        pmbutton.SetActive(false);
    }
}
