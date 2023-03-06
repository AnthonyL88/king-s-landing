using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public TMP_Text roomName;

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }
}
