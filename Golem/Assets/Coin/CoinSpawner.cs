using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{

    public static Rigidbody CoinBaseRef;

    public Rigidbody CoinBase;

    private void Start()
    {
        CoinBaseRef = CoinBase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void SpawnCoins()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject c = GameObject.Find("CoinSpawners");
            if (c is null)
                Debug.Log("yfgemvkv");
            Transform Coinspawner = c.transform.Find($"CoinSpawner{i}");
            if (Coinspawner is null)
                Debug.Log("ma le2a el Coinspawner");
            if (Coinspawner is null)
                Debug.Log("rig is null");
            Rigidbody CoinIns;
            CoinIns = Instantiate(CoinBaseRef, Coinspawner.position, Coinspawner.rotation) as Rigidbody;
            CoinIns.AddForce(0f, 0f, 0f);
        }
    }
}