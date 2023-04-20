using UnityEngine;

namespace Golemall
{
    public class CombatGolem : MonoBehaviour
    {
        public delegate void EnemyEventHandler(enemyAi enemy);

        public static event EnemyEventHandler OnEnemyDeath2;

        public static void EnemyDied2(enemyAi enemy)
        {
            if (OnEnemyDeath2 != null)
            {
                OnEnemyDeath2(enemy);
            }
        }
    }
}