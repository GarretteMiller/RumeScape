using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlConf : MonoBehaviour
{

    [SerializeField]
    private GameObject ARconf;
    [SerializeField]
    private GameObject ControllerConf;

    public void SetToCont()
    {

        ARconf.SetActive(false);
        ControllerConf.SetActive(true);
        PlayerPrefs.SetInt("Controls", 1);

    }

}
