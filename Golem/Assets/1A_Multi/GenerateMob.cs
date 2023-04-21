using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMob : MonoBehaviour
{
    // Start is called before the first frame update   }

    public GameObject mobPrefab;
    private GameObject _mob;

    // Start is called before the first frame update
    void Start()
    {
        _mob = PhotonNetwork.Instantiate(mobPrefab.name, transform.position, Quaternion.identity);
        _mob.transform.localScale = new Vector3(1, 1, 1);
    }
}
