using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] dialogue;
    public string name;
    private bool _isInsideTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable Object"))
        {
            _isInsideTrigger = true;
            Interact();
        }
    }
    
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Interactable Object"))
        {
            _isInsideTrigger = false;
        }
    }

    void Interact()
    {
        if (_isInsideTrigger)
        {
            
            name = "Ragnar";
            dialogue = new string[3];
            dialogue[0] = "Welcome heroe! The enemie has taken all the courts of the castle!";
            dialogue[1] = "We need your help!";
            dialogue[2] = "Good luck, don't die ;)";
         
            DialogueSystem.Instance.AddNewDialogue(dialogue,name);
            Debug.Log("Interacting with NPC.");
        }
    }
    
}
