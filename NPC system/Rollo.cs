using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollo : MonoBehaviour
{
    public string[] dialogue;
    public string name;
    private bool _isInsideTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rollo"))
        {
            _isInsideTrigger = true;
            Interact();
        }
    }
    
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Rollo"))
        {
            _isInsideTrigger = false;
        }
    }

    public virtual void Interact()
    {
        if (_isInsideTrigger)
        {
            name = "Rollo";
            dialogue = new string[3];
            dialogue[0] = "I knew you'll come to save us";
            dialogue[1] = "Be careful";
            dialogue[2] = "We trust you";
            DialogueSystem.Instance.AddNewDialogue(dialogue,name);
            Debug.Log("Interacting with NPC.");
        }
    }
}
