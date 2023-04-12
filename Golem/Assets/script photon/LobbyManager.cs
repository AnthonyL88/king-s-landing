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
    public TMP_Text roomName;
    public TMP_Text roomTittleName;

    public GameObject Room1;
    public GameObject Content;

    [SerializeField]
    public TMP_Text RoomPlayerList;

    [SerializeField]
    public TMP_Text logsLobby;
    [SerializeField]
    public TMP_Text logsRoom;

    public void Start()
    {
        LogLobbyFeedback("Lobby joined");
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        LogLobbyFeedback("Button Pressed");
        if (roomInputField.text.Length != 0)
        {
            PhotonNetwork.CreateRoom(roomInputField.text); //, new RoomOptions() {MaxPlayers = 4}
            roomName.text = roomInputField.text;
            LogLobbyFeedback($"\"{roomInputField.text}\" has been created");
        }
    }

    public override void OnCreatedRoom()
    {
        if(roomInputField!= null && roomInputField.text != "") 
        {
            roomName.text = roomInputField.text;
        }
    }

    public override void OnJoinedRoom()
    {
        LogLobbyFeedback("You just joined a Room");
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomTittleName.text = "Room Name : " + PhotonNetwork.CurrentRoom.Name;
        RoomPlayerList.text = "Current Players :";
        refresh();
        LogRoomFeedback($"You are in the Room : {PhotonNetwork.CurrentRoom.Name}");
    }

    public void refresh()
    {
        RoomPlayerList.text = "Current Players :";
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            RoomPlayerList.text += System.Environment.NewLine + player.NickName;
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList != null && roomList.Count > 0)
        {
            if (roomInputField != null && roomInputField.text.Length != 0)
                roomName.text = roomInputField.text;
            Content.SetActive(!false);
        }
        else
        {
            Content.SetActive(false);
        }
        LogRoomFeedback("Update des Rooms");
        /*UpdateRoomList(roomList);
    }

    //Update the Room print on the scene
    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            LogLobbyFeedback($"Destroy {item.name}");
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            LogLobbyFeedback($"Add {newRoom.name}");
            roomItemsList.Add(newRoom);
        }*/
    }

    public void OnRoom1Joinned()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void LogLobbyFeedback(string message)
    {
        if (logsLobby == null)
        {
            return;
        }
        logsLobby.text += System.Environment.NewLine + message;
    }

    void LogRoomFeedback(string message)
    {
        if (logsRoom == null)
        {
            return;
        }
        logsRoom.text += System.Environment.NewLine + message;
    }
    public void OnClickPlay()
    {
        LogLobbyFeedback("Button Pressed");
        PhotonNetwork.CreateRoom(roomInputField.text); //, new RoomOptions() {MaxPlayers = 4} 
        LogLobbyFeedback($"\"{roomInputField.text}\" has been created");
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickLeaveRoom()
    {
        LogRoomFeedback("You just left " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LeaveRoom();
    }

   /* public override void OnLeftRoom()
    {
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
    }*/
}
