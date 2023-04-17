using UnityEngine;

namespace Golemall
{
    public class SpawnGoal : MonoBehaviour
    {
        public static int CurrentAmount = 0;
        public static int RequiredAmount = 3;
        
        
        public virtual void Init()
        {
            // default init stuff 
        }

        public void Evaluate() // to see if a quest is completed or not 
        {
            if (CurrentAmount >= RequiredAmount)
            {
                Complete();
            }
        }
        public void Complete() // changes completed to true if the quest is done 
        {
            GolemSpawer.SpawnGolems();
            CurrentAmount = 0;
        }
    }
}    
