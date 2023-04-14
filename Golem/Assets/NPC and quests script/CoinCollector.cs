using UnityEngine;

public class CoinCollector : Quest
{
    public Rigidbody keyRef;
    
    private void Start()
    {
        QuestName = "Ultimate Slayer";
        Description = "Kill some enemies !";
        ItemReward = keyRef;
        ExperienceReward = 100;

        Goals.Add(new CollectGoal(this,"collect",false,0, 5));
        //Goals.Add(new KillGoal(this,1, "Kill 3 skeletons",false, 0, 3));
        
        Goals.ForEach(g => g.Init());
        
    }

}