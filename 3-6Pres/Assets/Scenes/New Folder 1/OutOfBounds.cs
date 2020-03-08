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
    public CountDown count;
    private bool keyinui;
    public DoorIn din;

    private Vector3 CenterPos;



    // Start is called before the first frame update

    private void Start()
    {
        privOutofBounds = false;
        ArrowActive = false;
        keyinui = false;
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
        if (!Arrow.activeSelf)
        {
            if (privOutofBounds != false)
            {
                Arrow.SetActive(true);
                ArrowActive = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (din.lvlInProg == true && din.lvlOver != true)
        {
            if (privOutofBounds == true)
            {
                if (ArrowActive == false)
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
}
