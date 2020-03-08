using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arConf : MonoBehaviour
{
    [SerializeField]
    private GameObject ARconf;
    [SerializeField]
    private GameObject ControllerConf;

    public void SetToAr()
    {
        PlayerPrefs.SetInt("Controls", 0);

        ControllerConf.SetActive(false);
        ARconf.SetActive(true);

    }

}
