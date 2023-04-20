using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float Z;

    private void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY,maxY), Z);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }
}
