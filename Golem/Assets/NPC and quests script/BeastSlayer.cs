using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastSlayer : Quest
{
    public Rigidbody lengendarymaceRef;
    
    private void Start()
    {
        QuestName = "Beast Slayer";
        Description = "Kill some enemies !";
        ItemReward = lengendarymaceRef;
        ExperienceReward = 100;

        Goals.Add(new KillGoal(this,1, "Kill 1 enemie", false,0, 2));
        //Goals.Add(new KillGoal(this,1, "Kill 3 skeletons",false, 0, 3));
        
        Goals.ForEach(g => g.Init());
        
    }

}