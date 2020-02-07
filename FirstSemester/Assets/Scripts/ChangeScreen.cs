using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    public Material PigScreen;
    public Material KeyScreen;
    Renderer m_Renderer;
    public Transform orb1;
    public Transform orb2;
    public Transform orb3;
    public Material lit;
    public Material unlit;
    public Material unlitol;
    GameObject pig;
    public Item key;
    Inventory inventory;

    private bool isSolved = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        pig = GameObject.FindGameObjectWithTag("CoinSlot");
        inventory = GameObject.FindGameObjectWithTag("canvas").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOrbs();
        CheckKey();
    }

    public void CheckOrbs()
    {
        if(orb1.GetComponent<MeshRenderer>().sharedMaterial == lit &&
         (orb2.GetComponent<MeshRenderer>().sharedMaterial == unlit ||
          orb2.GetComponent<MeshRenderer>().sharedMaterial == unlitol) && 
          orb3.GetComponent<MeshRenderer>().sharedMaterial == lit)
        {
            m_Renderer.material = PigScreen;
            isSolved = true;
            pig.GetComponent<CoinSlot>().OnTriggerCoins();
        }
    }

    public void CheckKey()
    {
        if (inventory.CheckItem(key))
        {
            m_Renderer.material = KeyScreen;
            orb1.GetComponent<MeshRenderer>().material = unlit;
            orb2.GetComponent<MeshRenderer>().material = unlit;
            orb3.GetComponent<MeshRenderer>().material = unlit;
        }
    }

    public bool checkIfSolved()
    {
        return isSolved;
    }
}
