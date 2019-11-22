
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private Vector2 touchPosition = default;
    GameObject item;
    GameObject Orb;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable)
                {
                    if (hit.transform.tag == "Orb")
                    {
                        Orb = hit.collider.gameObject;
                        Orb.GetComponent<ToggleOrb>().LightOrb(Orb);
                    }
                    else
                    {
                        item = hit.collider.gameObject;
                        Debug.Log("got here" + item.name);
                        if (item != null)
                            item.GetComponent<ItemPickup>().PickUp(item);
                    }
                }
            }
        }
    }
}
