using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TMP_Text roomTittleName;

    public GameObject RoomPrefab;
    public GameObject Content;

    [SerializeField]
    public TMP_Text RoomPlayerList;

    public GameObject PlayButton;

    public void Start()
    {
        //Juste pour la soutenance
        PhotonNetwork.JoinOrCreateRoom("Fast Room", null, null);
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length != 0 && PhotonNetwork.IsConnected)
        {
            PhotonNetwork.CreateRoom(roomInputField.text);
        }
    }

    public override void OnCreatedRoom()
    {
        /*
        GameObject _room = PhotonNetwork.InstantiateRoomObject(RoomPrefab.name, RoomPrefab.transform.position, Quaternion.identity);
        _room.GetComponent<RoomRename>().SetRoomName(roomInputField.text);*/
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
{
        base.OnPlayerEnteredRoom(newPlayer);

        if (PhotonNetwork.IsMasterClient)
            PlayButton.SetActive(true);
        else PlayButton.SetActive(false);

        RoomPlayerList.text = "Current Players :" + PhotonNetwork.CurrentRoom.PlayerCount;
    }
    
    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        RoomPlayerList.text = "Current Players :" + PhotonNetwork.CurrentRoom.PlayerCount + "/ 4";
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomTittleName.text = "Room : " + PhotonNetwork.CurrentRoom.Name;
        RoomPlayerList.text = "Current Players :" + PhotonNetwork.CurrentRoom.PlayerCount + "/ 4";
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList != null && roomList.Count > 0)
        {
            Content.SetActive(!false);
        }
        else
        {
            Content.SetActive(false);
        }
    }

    public void OnRoom1Joinned()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public void OnClickPlay()
    {
        PlayButton.SetActive(false);
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel("Multi");
    }
}
