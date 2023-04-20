using System;
using System.Collections;
using System.Collections.Generic;
using NPC_and_quests_script;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinCollect = 0;
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCollect++;
            CollectCoin.CoinCollected(this);
            Debug.Log("coin collected");
        }
    }
}
