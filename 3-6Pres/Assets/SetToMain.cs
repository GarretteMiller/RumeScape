using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToMain : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject settMenu;

    public void SetToMMenu()
    {

        settMenu.SetActive(false);
        MainMenu.SetActive(true);

    }
}
