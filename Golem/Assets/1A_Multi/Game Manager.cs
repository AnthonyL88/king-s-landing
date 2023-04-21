using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    [Space]
    public Transform spawnZone;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnZone.position, Quaternion.identity);
        _player.GetComponent<PlayerChecker>().IsLocalPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }
}