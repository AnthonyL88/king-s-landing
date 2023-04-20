using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class InGame : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text playersList;

    public void PlayersList()
    {
        playersList.text = "With :\n";
        foreach (Player player in PhotonNetwork.PlayerListOthers)
        {
            playersList.text += System.Environment.NewLine + player.NickName;
        }
    }
}
