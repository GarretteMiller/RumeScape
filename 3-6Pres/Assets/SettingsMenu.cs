using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject settMenu;
    [SerializeField]
    private GameObject arConf;
    [SerializeField]
    private GameObject contConf;

    public void SetMenu()
    {

        MainMenu.SetActive(false);
        settMenu.SetActive(true);
        arConf.SetActive(false);
        contConf.SetActive(false);
        if (PlayerPrefs.GetInt("Controls", 0) == 0)
        {
            contConf.SetActive(false);
            arConf.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Controls") == 1)
        {
            arConf.SetActive(false);
            contConf.SetActive(true);
        }
    }
}
