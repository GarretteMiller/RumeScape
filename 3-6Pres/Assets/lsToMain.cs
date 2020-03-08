using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lsToMain : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject levelMenu;

    public void LevelToMain()
    {

        levelMenu.SetActive(false);
        MainMenu.SetActive(true);

    }
}
