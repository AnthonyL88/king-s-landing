using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubbe : MonoBehaviour
{
    public string[] dialogue;
    public string name = "Ubbe";
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

    public static int check2quests = 0;
    
    void OnTriggerEnter(Collider other)
    {
        Spawn = RewardSpawner.transform.Find("UbbeSpawner");
        if (other.gameObject.CompareTag("Ubbe"))
        {
            _isInsideTrigger = true;
            if (QuestSystem.TalkedToNCP && !AssignedQuest && !IsCompleted)
            {
                DialogueSystem.Instance.AddNewDialogue(new string[] {"You should finish your quest first"}, "Ubbe");
            }
            else if (!AssignedQuest && !IsCompleted)
            {
                AssignQuest();
                Debug.Log("quest asseigned");
                QuestSystem.TalkedToNCP = true;
            }
            else if (AssignedQuest && !IsCompleted && check2quests == 1)
            {
                Debug.Log("anss 2");
                AssignQuest();
            }
            else if (AssignedQuest && !IsCompleted)
            {
                CheckQuest();
            }
            else
            {
                DialogueSystem.Instance.AddNewDialogue(new string[] { "Hoho you got this hero!" }, "Ubbe");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ubbe"))
        {
            _isInsideTrigger = false;
        }
    }
    
    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)_quests.AddComponent(System.Type.GetType(_questType));
        Debug.Log($"{Quest.Completed}");
        check2quests++;
        if (check2quests == 1)
        {
            string[] questdialogue = new string[2];
            questdialogue[0] = "Let's see if you can handle 2 quests at the same time";
            questdialogue[1] = "Your first quest is to collect 4 coins";
            DialogueSystem.Instance.AddNewDialogue(questdialogue, name);
            string questText = "Coins collect count: ";
            string queststagtext = "Ubbe's Quest";
            string amount = "4";
            QuestSystem.Instance.AddNewQuest(questText, queststagtext, amount);
            Debug.Log("quest is Asseigned");
            CoinsSpawner.SpawnCoins();
        }
        if (check2quests == 2)
        {
            string[] questdialogue = new string[2];
            questdialogue[0] = "You're half way done!";
            questdialogue[1] = "Your second quest is to kill 2 golems";
            DialogueSystem.Instance.AddNewDialogue(questdialogue, name);
            string questText = "Golem kill count: ";
            string queststagtext = "Ubbe's Quest";
            string amount = "2";
            Goal.CurrentAmount = 0;
            QuestSystem.Instance.AddNewQuest(questText, queststagtext, amount);
            Debug.Log("quest is Asseigned");
        }
    }

    void CheckQuest()
    {
        Debug.Log("checking...");
        Debug.Log($"{Quest.Completed} {check2quests}");
        if (Quest.Completed && check2quests >= 2)
        {
            Rigidbody reward;
            reward = Instantiate(RewardRef, Spawn.position, Spawn.rotation);
            reward.AddForce(0f, 150f, -50f);
            Quest.GiveReward();
            IsCompleted = true;
            AssignedQuest = false;
            QuestSystem.CheckQuest = true;
            DialogueSystem.Instance.AddNewDialogue(new string[] {"Well done!", "Here's your reward.", "and you gained 50xp points hehe"}, "Rollo");
            PlayerInventory.currentXP += 100;
            QuestSystem.TalkedToNCP = false;
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "You still haven't completed the quest", "I believe in you", "You can do it!" }, "Rollo");
        }
    }
}
