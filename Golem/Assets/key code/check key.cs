using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkkey : MonoBehaviour
{
    [SerializeField]
    private int KeyID;
    [SerializeField]
    public List<bool> Keylist;
    public static List<bool> list2;

    private void Start()
    {
        Keylist.Add(false);
        Keylist.Add(false);
        Keylist.Add(false);
        Keylist.Add(false);
        list2 = Keylist;
    }

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
            Keylist[0] = true;
            list2 = Keylist;
        }

        if (KeyID == 14 && transform.childCount > 0)
        {
            Keylist[1] = true;
            list2 = Keylist;
        }

        if (KeyID == 15 && transform.childCount > 0)
        {
            Keylist[2] = true;
            list2 = Keylist;
        }

        if (KeyID == 16 && transform.childCount > 0)
        {
            Keylist[3] = true;
            list2 = Keylist;
        }
        

    }
}
