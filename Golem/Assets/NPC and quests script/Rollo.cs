using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollo : MonoBehaviour
{
    public string[] dialogue;
    public string name = "Rollo";
    private bool _isInsideTrigger = false;
    public bool AssignedQuest { get; set; }
    public bool IsCompleted { get; set; }

    [SerializeField]
    private GameObject _quests;

    [SerializeField]
    private string _questType;
    public Quest Quest { get; set; }
    
    public GameObject RewardSpawner;
    public Rigidbody RewardRef;
    private Transform Spawn;
    
    void OnTriggerEnter(Collider other)
    {
        Spawn = RewardSpawner.transform.Find("RolloSpawner");
        if (other.gameObject.CompareTag("Rollo"))
        {
            _isInsideTrigger = true;
            if (!AssignedQuest && !IsCompleted)
            {
                AssignQuest();
                Debug.Log("quest asseigned");
            }
            else if (AssignedQuest && !IsCompleted)
            {
                CheckQuest();
            }
            else
            {
                DialogueSystem.Instance.AddNewDialogue(new string[] { "Hoho you got this hero!" }, "Rollo");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rollo"))
        {
            _isInsideTrigger = false;
        }
    }
    
    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)_quests.AddComponent(System.Type.GetType(_questType));
        string[] questdialogue = new string[2];
        questdialogue[0] = "Let's see if you are the Ultimate Slayer";
        questdialogue[1] = "Your quest is to kill 3 golems";
        DialogueSystem.Instance.AddNewDialogue(questdialogue, name);
        string questText = "Golems kill count: ";
        string queststagtext = "Rollo's Quest";
        string amount = "3";
        QuestSystem.Instance.AddNewQuest(questText,queststagtext, amount);
        Debug.Log("quest is Asseigned");
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Rigidbody reward;
            reward = Instantiate(RewardRef, Spawn.position, Spawn.rotation);
            reward.AddForce(0f, 150f, -50f);
            Quest.GiveReward();
            IsCompleted = true;
            AssignedQuest = false;
            QuestSystem.CheckQuest = true;
            DialogueSystem.Instance.AddNewDialogue(new string[] {"Well done!", "Here's your reward."}, "Rollo");
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "You still haven't completed the quest", "I believe in you", "You can do it!" }, "Rollo");
        }
    }
    
}
