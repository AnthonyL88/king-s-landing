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

        if (weaponID == 7 && transform.childCount > 0)
        {
            for (int i = 1; i < weaponlist.Count; i++)
            {
                if (i == 1)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }

        if (weaponID == 8 && transform.childCount > 0)
        {
            for (int i = 2; i < weaponlist.Count; i++)
            {
                if (i == 2)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }

        if (weaponID == 9 && transform.childCount > 0)
        {
            for (int i = 3; i < weaponlist.Count; i++)
            {
                if (i == 3)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }

        if (weaponID == 10 && transform.childCount > 0)
        {
            for (int i = 4; i < weaponlist.Count; i++)
            {
                if (i == 4)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }

        if (weaponID == 11 && transform.childCount > 0)
        {
            for (int i = 5; i < weaponlist.Count; i++)
            {
                if (i == 5)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }

        if (weaponID == 12 && transform.childCount > 0)
        {
            for (int i = 6; i < weaponlist.Count; i++)
            {
                if (i == 6)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }

        if (weaponID == 13 && transform.childCount > 0)
        {
            for (int i = 7; i < weaponlist.Count; i++)
            {
                if (i == 7)
                {
                    weaponlist[i].SetActive(true);
                }

            }
        }
    }
}

