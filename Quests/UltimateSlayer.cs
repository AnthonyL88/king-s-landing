using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    public Rigidbody lengendaryaxeRef;
    private void Start()
    {
        QuestName = "Ultimate Slayer";
        Description = "Kill some enemies !";
        ItemReward = lengendaryaxeRef;
        ExperienceReward = 100;
        
        Goals.Add(new KillGoal(this,0, "Kill 5 enemies", false,0, 5));
        Goals.Add(new KillGoal(this,1, "Kill 3 skeletons",false, 0, 3));
        
        Goals.ForEach(g => g.Init());
    }
}
