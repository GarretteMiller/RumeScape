using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSlot : MonoBehaviour
{
    private GameObject key;
    public Transform keySpawn;
    private int numCoins = 0;
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("PiggyBank/Pedestal/KeySpawn/Key");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider col)
    {
        
        if(col.gameObject.tag == "coin")
        {
            col.gameObject.SetActive(false);
            numCoins++;
            Debug.Log("Number of Coins: " + numCoins);
            if (numCoins > 2)
                key.SetActive(true);
                
        }
    }
}
