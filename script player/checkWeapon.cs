using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWeapon : MonoBehaviour
{
    [SerializeField]
    private int weaponID;
    [SerializeField]
    public List<GameObject> weaponlist = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            weaponID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
        else
        {
            weaponID = 0;
            for (int i = 0; i < weaponlist.Count; i++)
            {
                weaponlist[i].SetActive(false);
            }

        }

        if (weaponID == 1 && transform.childCount > 0)
        {
            for (int i = 0; i < weaponlist.Count; i++)
            {
                if (i == 0)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }
    }
}

