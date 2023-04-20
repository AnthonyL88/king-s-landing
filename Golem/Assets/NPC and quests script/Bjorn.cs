using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bjorn : MonoBehaviour
{
    public string[] dialogue;
    public string name = "Bjorn";
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
    public Rigidbody Reward2Ref;
    private Transform Spawn;
    private Transform Spawn2;
    
    void OnTriggerEnter(Collider other)
    {
        Spawn = RewardSpawner.transform.Find("BjornSpawner");
        Spawn2 = RewardSpawner.transform.Find("BjornSpawner2");

        if (other.gameObject.CompareTag("Bjorn"))
        {
            _isInsideTrigger = true;
            if (QuestSystem.TalkedToNCP && !AssignedQuest && !IsCompleted)
            {
                DialogueSystem.Instance.AddNewDialogue(new string[] {"You should finish your quest first"}, "Bjorn");
            }
            else if (!AssignedQuest && !IsCompleted)
            {
                AssignQuest();
                CoinsSpawner.SpawnCoins();
                Debug.Log("quest asseigned");
                QuestSystem.TalkedToNCP = true;
            }
            else if (AssignedQuest && !IsCompleted)
            {
                CheckQuest();
            }
            else
            {
                DialogueSystem.Instance.AddNewDialogue(new string[] { "Hoho you got this hero!" }, "Bjorn");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bjorn"))
        {
            _isInsideTrigger = false;
        }
    }
    
    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)_quests.AddComponent(System.Type.GetType(_questType));
        string[] questdialogue = new string[3];
        questdialogue[0] = "It's time to collect some coin!";
        questdialogue[1] = "Your quest is to kill collect 5 coins";
        questdialogue[2] = "I might give something in exchange of them!";
        DialogueSystem.Instance.AddNewDialogue(questdialogue, name);
        string questText = "Coins collected: ";
        string queststagtext = "Bjorn's Quest";
        string amount = "5";
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
            Rigidbody reward2;
            reward2 = Instantiate(Reward2Ref, Spawn2.position, Spawn2.rotation);
            reward2.AddForce(0f, 150f, -50f);
            Quest.GiveReward();
            IsCompleted = true;
            AssignedQuest = false;
            QuestSystem.CheckQuest = true;
            DialogueSystem.Instance.AddNewDialogue(new string[] {"Well done!", "Here's your reward.", "and you gained 50xp hehe"}, "Bjorn");
            PlayerInventory.currentXP += 50;
            QuestSystem.TalkedToNCP = false;
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "You still haven't completed the quest", "I believe in you", "You can do it!" }, "Rollo");
        }
    }
}
