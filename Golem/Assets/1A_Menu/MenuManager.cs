using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MenuManager : MonoBehaviourPunCallbacks
{
    public GameObject canva;

    public void Start()
    {
        canva.SetActive(false);
        Debug.Log("Connecting...");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected !!!");
        base.OnConnectedToMaster();
        canva.SetActive(true);
    }

    public void Multiplayer()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void Solo()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Leave()
    {
    }
}
