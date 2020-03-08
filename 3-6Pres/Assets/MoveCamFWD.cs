using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamFWD : MonoBehaviour
{

    public GameObject ARCamera; //Drag your breaklight here
    public GameObject ControlUI; //Drag your breaklight here

    private bool holding;
    public float speed =3.0f;
    private void Start()
    {
        holding = false;
    }
    void Update()
    {
        /*
        if (Input.GetMouseButtonUp(0) && ControlUI.activeSelf && holding == true)
        {
            ARCamera.transform.position = new Vector3(0, speed * Time.deltaTime, 0);
        }
        */
        if (holding == true)
        {
            ARCamera.transform.position = new Vector3(0, speed * Time.deltaTime, 0);

        }
    }

    void OnMouseDown()
    {
        holding = true;
    }
    void OnMouseUp()
    {
        holding = false;
    }

}
