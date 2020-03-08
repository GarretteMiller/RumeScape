using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("Controls", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
