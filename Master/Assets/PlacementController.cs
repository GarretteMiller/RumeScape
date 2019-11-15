using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{

    [SerializeField]
    private GameObject placedPrefab;
    [SerializeField]
    public Camera arCamera;
    [SerializeField]
    private GameObject buildUI;
    [SerializeField]
    private Button redoButton;
    [SerializeField]
    private Button dismissButton;
    public GameObject building;
    public bool menuActive;
    public bool BuildingPlaced;
    public bool planesDisabled;
    public bool pointsDisabled;
    public bool placementOver;
    private int buildingnumber; 
    private Vector2 touchPosition = default;
    private Transform oTransform;
    ARSessionOrigin m_SessionOrigin;
    private ARRaycastManager arRaycastManager;

    void Awake()
    {
        buildUI.SetActive(false);
        menuActive = false;
        placementOver = false;
        BuildingPlaced = false;
        buildingnumber = 0;
        arRaycastManager = GetComponent<ARRaycastManager>();
        oTransform = transform;
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
        redoButton.onClick.AddListener(redoPlacement);
        dismissButton.onClick.AddListener(placementOK);
    }

    private void redoPlacement()
    {
        
        if (building != null)
        {
            Destroy(building);
            BuildingPlaced = false;
        }
        if (planesDisabled == true)
        {
            EnablePlanes();
        }
        if (pointsDisabled == true)
        {
            EnablePoints();
        }
        /*
        if (BuildingPlaced != false)
        {
            building.SetActive(false);
            BuildingPlaced = false;
        }
        */
        buildUI.SetActive(false);
        menuActive = false;
    }
    private void placementOK()
    {
        //       buildUI.SetActive(false);
        Destroy(buildUI);
        menuActive = false;
        placementOver = true;
    }

    private void PlaceBuilding()
    {
          if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
           {
            if (BuildingPlaced != true)
            {
                var hitPose = hits[0].pose;
                Vector3 targetPosition = new Vector3(hitPose.position.x + 5, hitPose.position.y, hitPose.position.z);
                Quaternion targetAngle = new Quaternion(hitPose.rotation.x, hitPose.rotation.y + 90, hitPose.rotation.z, hitPose.rotation.w);
                var cameraForward = Camera.current.transform.forward;
                var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
                //Quaternion targetAngle = Quaternion.LookRotation(cameraBearing);
                building = Instantiate(placedPrefab, targetPosition, targetAngle);
                DisablePlanes();
                DisablePoints();
                BuildingPlaced = true;
                buildUI.SetActive(true);

            }
        }
    }
    void DisablePlanes()
    {
        ARPlaneManager planeManager = GetComponent<ARPlaneManager>();
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
        ARPointCloudManager pointManager = GetComponent<ARPointCloudManager>();
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
        ARPlaneManager planeManager = GetComponent<ARPlaneManager>();
        List<ARPlane> allPlanes = new List<ARPlane>();
        planeManager.enabled = true;
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }
    }
    void EnablePoints()
    {
        ARPointCloudManager pointManager = GetComponent<ARPointCloudManager>();
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
        // if (buildUI.activeSelf)
        //   return;
        if (placementOver != false)
            return;
        if (menuActive != false)
            return;
        //       if (BuildingPlaced == false)
        //         if(buildingnumber>1)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                PlaceBuilding();
            }
        }
    }
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
}