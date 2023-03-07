using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : Rollo
{
    public bool AssignedQuest { get; set; }
    public bool IsCompleted { get; set; }
    
    [SerializeField]
    private GameObject _quests;

    [SerializeField] 
    private string _questType;
    public Quest Quest { get; set; }
    public override void Interact()
    {
        if (!AssignedQuest && !IsCompleted)
        {
            base.Interact();
            AssignQuest();
        }
        else if (AssignedQuest && !IsCompleted)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] {"Hoho you got this hero!"}, "Rollo");
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)_quests.AddComponent(System.Type.GetType(_questType));
        Debug.Log("quest is Assigned");
    }

    void CheckQuest()
    {
        /*
        if (Quest.Completed)
        {
            Quest.GiveReward();
            IsCompleted = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] {"Well done!", "Here's your reward."}, "Rollo");
        }
        else
        {
        */
            DialogueSystem.Instance.AddNewDialogue(new string[] {"You still haven't completed the quest", "I believe in you", "You can do it!"}, "Rollo");
        //}
    }
}
