using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    public GameObject UIpannel;
    public Text pointsText;
    public int AvailablePoints;
    public string OpenKey;
    private bool IsOpen;
    private PlayerInventory playerinv;

    // Start is called before the first frame update
    void Start()
    {
        playerinv = gameObject.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(OpenKey))
        {
            IsOpen = !IsOpen;
        }

        if(IsOpen)
        {
            pointsText.text = "Available Points : " + AvailablePoints;
            UIpannel.SetActive(true);
        }
        else
        {
            UIpannel.SetActive(false);
        }
    }

    public void AddHealthMax(float AmountHp)
    {
        if(AvailablePoints >= 1)
        {
            playerinv.maxHealth += AmountHp;
            playerinv.currentHealth = playerinv.maxHealth;
            AvailablePoints -= 1;
        }
    }

    public void AddManaMax(float AmountMana)
    {
        if (AvailablePoints >= 1)
        {
            playerinv.maxMana += AmountMana;
            playerinv.currentMana = playerinv.maxMana;
            AvailablePoints -= 1;
        }
    }
}
