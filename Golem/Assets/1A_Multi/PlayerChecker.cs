using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerChecker : MonoBehaviourPunCallbacks
{
    public CharacterMotor motor;
    public GameObject thecamera;
    // Start is called before the first frame update

    public void IsLocalPlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Cam On");
            motor.enabled = true;
            thecamera.SetActive(true);
        }
    }
}
