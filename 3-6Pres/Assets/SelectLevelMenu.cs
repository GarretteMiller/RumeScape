using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject levelMenu;

    public void LevelMenu()
    {

         MainMenu.SetActive(false);
         levelMenu.SetActive(true);
    
    }
}
