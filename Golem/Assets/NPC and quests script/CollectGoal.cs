using System.Collections;
using System.Collections.Generic;
using NPC_and_quests_script;
using Unity.VisualScripting;
using UnityEngine;

public class CollectGoal : Goal
{

    public CollectGoal(Quest quest, string description, bool completed, int currentAmount, int requiredAmount)
    {
        Quest = quest;
        Description = description;
        CurrentAmount = currentAmount;
        RequiredAmount = requiredAmount;
        Completed = completed;
    }

    public override void Init()
    {
        base.Init();
        CollectCoin.OnCoinCollected += CoinCollected;
    }

    void CoinCollected(Coin coin)
    {
        CurrentAmount++;
        QuestSystem.changetext = $"{Goal.CurrentAmount}/{Goal.RequiredAmount}";
        Evaluate(); 
        Debug.Log("fetet 3a coincollected");
    }

    
}