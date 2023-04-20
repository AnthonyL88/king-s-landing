using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkkey : MonoBehaviour
{
    [SerializeField]
    private int KeyID;
    [SerializeField]
    public List<bool> Keylist = new List<bool>();

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            KeyID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        }
        else
        {
            KeyID = 0;
            for (int i = 0; i < Keylist.Count; i++)
            {
                Keylist[i] = false;
            }

        }

        if (KeyID == 4 && transform.childCount > 0)
        {
            for (int i = 0; i < Keylist.Count; i++)
            {
                if (i == 0)
                {
                    Keylist[i] = true;
                }

            }
        }

        if (KeyID == 14 && transform.childCount > 0)
        {
            for (int i = 1; i < Keylist.Count; i++)
            {
                if (i == 1)
                {
                    Keylist[i] = true;
                }

            }
        }

        if (KeyID == 15 && transform.childCount > 0)
        {
            for (int i = 2; i < Keylist.Count; i++)
            {
                if (i == 2)
                {
                    Keylist[i] = true;
                }

            }
        }

        if (KeyID == 16 && transform.childCount > 0)
        {
            for (int i = 3; i < Keylist.Count; i++)
            {
                if (i == 3)
                {
                    Keylist[i] = true;
                }

            }
        }

    }
}
