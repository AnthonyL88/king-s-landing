using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Quest Quest { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {
        // default init stuff 
    }

    public void Evaluate() // to see if a quest is completed or not 
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Debug.Log($"C = {CurrentAmount}, R = {RequiredAmount}");
            Complete();
        }
    }
    public void Complete() // changes completed to true if the quest is done 
    {
        Completed = true;
        Quest.CheckGoals();
        Debug.Log("Goal marked as completed.");
    }
}
