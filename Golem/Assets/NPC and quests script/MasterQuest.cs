using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterQuest : Quest
{
    public Rigidbody keyRef;
    
    private void Start()
    {
        QuestName = "Ultimate Slayer";
        Description = "Kill some enemies !";
        ItemReward = keyRef;
        ExperienceReward = 100;

        if (Ubbe.check2quests == 1)
        {
            Debug.Log("quest1");
            Goals.Add(new CollectGoal(this, "collect", false, 0, 4));
        }

        if (Ubbe.check2quests == 2)
        {
            Debug.Log("quest2");
            Goals.Add(new KillGoal(this, 0, "Kill 2 golems", false, 0, 2));
        }

        Goals.ForEach(g => g.Init());
        
    }
}
