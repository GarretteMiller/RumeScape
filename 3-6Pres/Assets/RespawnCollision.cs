using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RespawnCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject Building;
    [SerializeField]
    private GameObject RespawnPedParent;
    public Vector3 BuildingPos;
    public Quaternion BuildingRot;
    [SerializeField]
    private GameObject NewLevel;
    [SerializeField]
    private GameObject Arrow;
    public Vector3 RespawnPos;
    public Quaternion RespawnRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            Building.SetActive(true);
            //var RespawnB = Instantiate(NewLevel, RespawnPos, RespawnRot);
            NewLevel.transform.position = RespawnPos;
            NewLevel.transform.rotation = RespawnRot;
            this.transform.SetParent(Building.transform);
            Destroy(Building);
            //RespawnB.SetActive(true);
            NewLevel.SetActive(true);

            Arrow.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        RespawnPos = GameObject.FindGameObjectWithTag("PlaceInteract").GetComponent<PlaceBuildingInteraction>().finalBuildingPos;
        RespawnRot = GameObject.FindGameObjectWithTag("PlaceInteract").GetComponent<PlaceBuildingInteraction>().finalBuildingRot;
        //RespawnPedParent = Transform.Fin("FailMenu").GetComponent<FailMenuInteraction>().originalParent;

    }
}
