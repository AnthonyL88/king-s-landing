using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : MonoBehaviour
{
    public delegate void EnemyEventHandler(enemyAi enemy);

    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied(enemyAi enemy)
    {
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath(enemy);
        }
    }
}
