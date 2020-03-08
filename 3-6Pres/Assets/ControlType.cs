using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlType : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseUI;
    [SerializeField]
    private GameObject ControlUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseUI.activeSelf)
        {
            ControlUI.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Controls") == 0)
            ControlUI.SetActive(false);
        else if (!PauseUI.activeSelf && PlayerPrefs.GetInt("Controls") == 1)
            ControlUI.SetActive(true);
        
    }
}
