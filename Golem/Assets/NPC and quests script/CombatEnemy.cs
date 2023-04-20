using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : MonoBehaviour
{
    public delegate void EnemyEventHandler(enemyAi enemy);
    
    public delegate void SkeletonEventHandler(Skeleton enemy);

    public static event EnemyEventHandler OnEnemyDeath;
    
    public static event SkeletonEventHandler OnSkeletonDeath;

    

    

    public static void EnemyDied(enemyAi enemy)
    {
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath(enemy);
        }
    }
    
    public static void SkeletonDied(Skeleton enemy)
    {
        if (OnSkeletonDeath != null)
        {
            OnSkeletonDeath(enemy);
        }
    }


    
}
