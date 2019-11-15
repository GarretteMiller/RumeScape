using UnityEngine;

public class ItemPickup : Interactable
{
    private Inventory inventory;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("canvas").GetComponent<Inventory>();
    }

    public Item item;

    public void PickUp(GameObject gameobject)
    {
        Debug.Log("Picking up item.");
        Destroy(gameobject);
        inventory.AddItem(item);
    }
}
