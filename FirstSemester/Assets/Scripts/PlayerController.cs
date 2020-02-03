using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    private Vector2 touchPosition = default;
    GameObject item;
    GameObject Orb;

    private bool isHoldingItem = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (isHoldingItem)
            {
                item.GetComponent<HoldItem>().ItemInteraction(item);
                isHoldingItem = false;
            }
            else if (Physics.Raycast(ray, out hit, 5))
            {
                //Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (hit.transform.tag == "Orb")
                {
                    Orb = hit.collider.gameObject;
                    Orb.GetComponent<ToggleOrb>().LightOrb(Orb);
                }
                else if (hit.collider.gameObject.GetComponent<HoldItem>() != null)
                {
                    item = hit.collider.gameObject;
                    item.GetComponent<HoldItem>().ItemInteraction(item);
                    isHoldingItem = true;
                }
                else
                { 
                    item = hit.collider.gameObject;
                    //Debug.Log("got here" + item.name);
                    if (item != null)
                        item.GetComponent<ItemPickup>().PickUp(item);
                }
            }   
        }
    }
}
