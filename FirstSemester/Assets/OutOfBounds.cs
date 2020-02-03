using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OutOfBounds : MonoBehaviour
{
	[SerializeField]
	public GameObject Arrow;
	[SerializeField]
	public Transform CenterCube;
    private bool ArrowActive;
	private bool privOutofBounds;
	public bool OutofBounds;    
    [SerializeField]
    private float offsetForward;
    [SerializeField]
    private float offsetVertical;
    public float speed = 1.0f;

    private Vector3 CenterPos;



    // Start is called before the first frame update

    private void Awake()
    {
        privOutofBounds = false;
        ArrowActive = false;
    }

    void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			privOutofBounds = true;
		}
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && Arrow.activeSelf)
        {
            Arrow.SetActive(false);
            ArrowActive = false;
            privOutofBounds = false;
        }
    }
    void RotateArrow()
    {
        /*
        var cameraForward = Camera.current.transform.forward;
        //var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        var centerCubeForward = CenterCube.transform.forward;
        var centerCubeBearing = new Vector3(centerCubeForward.x, 0, centerCubeForward.z).normalized;

        //var cameraPos = Camera.current.transform.position;
        //CenterPos = cameraPos + cameraBearing * offsetForward;
        //CenterPos.y = CenterPos.y - offsetVertical;
        Quaternion targetRotation = Quaternion.LookRotation(centerCubeBearing);
        //Arrow.transform.position = CenterPos;
        Arrow.transform.rotation = Quaternion.LookRotation(targetRotation * Vector3.right, Vector3.up);
        */
        Vector3 targetDirection = Vector3.Normalize(CenterCube.position - Arrow.transform.position);
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(Arrow.transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(CenterCube.transform.position, targetDirection, Color.red);
        Arrow.transform.rotation = Quaternion.LookRotation(targetDirection) * Quaternion.Euler(0, 90, 0);
        Vector3 arrowAngles = Arrow.transform.rotation.eulerAngles;
        arrowAngles.z = 0;
        arrowAngles.x = 0;
        Arrow.transform.rotation = Quaternion.Euler(arrowAngles);

    }
    void spawnArrow()
    {
        if(!Arrow.activeSelf)
        {
            Arrow.SetActive(true);
            ArrowActive = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(privOutofBounds==true)
		{
            if(ArrowActive==false)
            {
                spawnArrow();
            }
            else
            {
                RotateArrow();
            }

        }
    }
}
