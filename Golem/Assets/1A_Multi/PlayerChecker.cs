using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    public CharacterMotor motor;
    public GameObject thecamera;
    // Start is called before the first frame update

    public void IsLocalPlayer()
    {
        Debug.Log("Cam On");
        motor.enabled = true;
        thecamera.SetActive(true);
    }
}
