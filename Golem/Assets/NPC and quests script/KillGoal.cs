using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillGoal : Goal
{
    public int EnemyID { get; set; }

    public KillGoal(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        Quest = quest;
        EnemyID = enemyID;
        Description = description;
        CurrentAmount = currentAmount;
        RequiredAmount = requiredAmount;
        Completed = completed;
    }

    public override void Init()
    {
        base.Init();
        CombatEnemy.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(enemyAi enemy)
    {
        if (enemy.ID == EnemyID)
        {
            CurrentAmount++;
            Evaluate();
            Debug.Log("fetet 3a enemy died");
        }

        
    }
}
