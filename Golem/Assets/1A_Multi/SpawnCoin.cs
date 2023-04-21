using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject coinPrefab;
    private GameObject _coin;

    // Start is called before the first frame update
    void Start()
    {
        _coin = PhotonNetwork.Instantiate(coinPrefab.name, transform.position, Quaternion.identity);
        _coin.transform.localScale = new Vector3(1, 1, 1);
    }
}
