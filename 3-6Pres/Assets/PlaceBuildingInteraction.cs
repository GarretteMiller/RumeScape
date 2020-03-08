using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceBuildingInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject Building;
    [SerializeField]
    private GameObject Building2;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private GameObject PlayerCube;
    [SerializeField]
    private GameObject buildUI;
    [SerializeField]
    private Button redoButton;
    [SerializeField]
    private Button dismissButton;
    private bool menuActive;
    public bool BuildingPlaced;
    private bool planesDisabled;
    private bool pointsDisabled;
    private bool placementOver;
    private Vector3 CenterPos;
    private Vector3 targetPosition;
    private Quaternion targetAngle;
    private int buildingnumber;
    private Vector2 touchPosition = default;
    private Transform oTransform;
    [SerializeField]
    private ARSessionOrigin m_SessionOrigin;
    //private ARRaycastManager arRaycastManager;
    [SerializeField]
    public Vector3 finalBuildingPos;
    public Quaternion finalBuildingRot;


    void Start()
    {
        buildUI.SetActive(false);
        menuActive = false;
        placementOver = false;
        BuildingPlaced = false;
        buildingnumber = 0;
        //arRaycastManager = GetComponent<ARRaycastManager>();
        redoButton.onClick.AddListener(redoPlacement);
        dismissButton.onClick.AddListener(placementOK);
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = Building.transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + Building.transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pos, pos + Building.transform.up);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(pos, pos + Building.transform.forward);
    }

    private void redoPlacement()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            //Vector3 placeholderPos = new Vector3(targetPosition.x, targetPosition.y + 100, targetPosition.z);
            //Building.transform.position = placeholderPos;
            Building.SetActive(false);
            BuildingPlaced = false;

            if (planesDisabled == true)
            {
                EnablePlanes();
            }
            if (pointsDisabled == true)
            {
                EnablePoints();
            }
            buildUI.SetActive(false);
            menuActive = false;
        }
        else if(PlayerPrefs.GetInt("Level")==2)
        {
            Building2.SetActive(false);
            BuildingPlaced = false;

            if (planesDisabled == true)
            {
                EnablePlanes();
            }
            if (pointsDisabled == true)
            {
                EnablePoints();
            }
            buildUI.SetActive(false);
            menuActive = false;
        }
    }
    private void placementOK()
    {
         buildUI.SetActive(false);
        //Destroy(buildUI);
        menuActive = false;
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            finalBuildingPos = Building.transform.position;
            finalBuildingRot = Building.transform.rotation;
            placementOver = true;

        } else if(PlayerPrefs.GetInt("Level") == 2)
        {
            finalBuildingPos = Building2.transform.position;
            finalBuildingRot = Building2.transform.rotation;
            placementOver = true;
        }
    }

    private void PlaceBuilding()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (m_SessionOrigin.GetComponent<ARRaycastManager>().Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            if (BuildingPlaced != true)
            {

                var hitPose = hits[0].pose;
                /*
                Building.transform.parent = Camera.current.transform;
                Building.transform.localPosition = new Vector3(-5, 0, 0);
                Quaternion trotation = Quaternion.Euler(0, 180, 0);
                Building.transform.localRotation = trotation;
                Vector3 bPlacement = Building.transform.position;
                bPlacement.y = hitPose.position.y;
                Building.transform.position = bPlacement;
                */
                //Building.SetActive(true);


                targetPosition = new Vector3(hitPose.position.x, hitPose.position.y, hitPose.position.z);
                targetAngle = new Quaternion(hitPose.rotation.x, hitPose.rotation.y, hitPose.rotation.z, hitPose.rotation.w);
                var cameraForward = Camera.current.transform.forward;
                var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
                var cameraPos = Camera.current.transform.position;
                CenterPos = cameraPos + cameraBearing * 5;
                CenterPos.y = hitPose.position.y;
                Quaternion targetRotation = Quaternion.LookRotation(cameraBearing);
                //Building.transform.position = targetPosition;
                if(PlayerPrefs.GetInt("Level", 1) == 1)
                {
                    Building.transform.position = CenterPos;
                    // Building.transform.rotation = Quaternion.FromToRotation(Building.transform.forward, -cameraBearing);
                    //Building.transform.rotation = targetAngle;
                    Building.transform.rotation = Quaternion.LookRotation(targetRotation * Vector3.right, Vector3.up);

                    DisablePlanes();
                    DisablePoints();
                    Building.SetActive(true);
                    //Building.transform.parent = null;
                    BuildingPlaced = true;
                    buildUI.SetActive(true);
                }
                else if(PlayerPrefs.GetInt("Level") == 2)
                {
                    Building2.transform.position = CenterPos;
                    // Building.transform.rotation = Quaternion.FromToRotation(Building.transform.forward, -cameraBearing);
                    //Building.transform.rotation = targetAngle;
                    Building2.transform.rotation = Quaternion.LookRotation(targetRotation * Vector3.right, Vector3.up);

                    DisablePlanes();
                    DisablePoints();
                    Building2.SetActive(true);
                    //Building.transform.parent = null;
                    BuildingPlaced = true;
                    buildUI.SetActive(true);
                }

            }
        }
    }
    void DisablePlanes()
    {
        ARPlaneManager planeManager = m_SessionOrigin.GetComponent<ARPlaneManager>();
        List<ARPlane> allPlanes = new List<ARPlane>();
        planeManager.enabled = false;
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        planesDisabled = true;
    }
    void DisablePoints()
    {
        ARPointCloudManager pointManager = m_SessionOrigin.GetComponent<ARPointCloudManager>();
        List<ARPointCloud> allPoints = new List<ARPointCloud>();
        pointManager.enabled = false;
        foreach (var point in pointManager.trackables)
        {
            point.gameObject.SetActive(false);
        }
        pointsDisabled = true;
    }
    void EnablePlanes()
    {
        ARPlaneManager planeManager = m_SessionOrigin.GetComponent<ARPlaneManager>();
        List<ARPlane> allPlanes = new List<ARPlane>();
        planeManager.enabled = true;
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }
        planesDisabled = false;
    }
    void EnablePoints()
    {
        ARPointCloudManager pointManager = m_SessionOrigin.GetComponent<ARPointCloudManager>();
        List<ARPointCloud> allPoints = new List<ARPointCloud>();
        pointManager.enabled = true;
        foreach (var point in pointManager.trackables)
        {
            point.gameObject.SetActive(true);
        }
        pointsDisabled = false;
    }
    void Update()
    {
        if (placementOver != false)
            return;
        if (menuActive != false)
            return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                PlaceBuilding();
            }
        }
    }
    
}