
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private Vector2 touchPosition = default;
    GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 3))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable)
                    {
                        item = hit.collider.gameObject;
                        if (item != null)
                            item.GetComponent<ItemPickup>().PickUp(item);
                    }
                }
            }
        }
    }
}
