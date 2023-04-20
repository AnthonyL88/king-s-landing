using System;
using System.Collections;
using System.Collections.Generic;
using Golemall;
using UnityEditor;
using UnityEngine;
public class GolemSpawer : SpawnGoal
{
    public static GameObject GolemRef;

    public GameObject Golem;

    
    /*
    public override void Init()
    {
        base.Init();
        CombatGolem.OnEnemyDeath2 += EnemyDied2;
    }
    */

    void EnemyDied2(enemyAi enemy)
    {
        CurrentAmount++;
        Evaluate();
    }
        
    
    private void Start()
    {
        base.Init();
        GolemRef = Golem;
        CombatGolem.OnEnemyDeath2 += EnemyDied2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void SpawnGolems()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject c = GameObject.Find("GolemSpawners");
            Transform Golemspawner = c.transform.Find($"GolemSpawner{i}");
            /*
            Rigidbody GolemIns;
            GolemIns = Instantiate(GolemRef, Golemspawner.position, Golemspawner.rotation) as Rigidbody;
            GolemIns.AddForce(0f, 0f, 0f);
            */
            GameObject GolemIns;
            GolemIns = Instantiate(GolemRef, Golemspawner.position, Golemspawner.rotation) as GameObject;
            GolemIns.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

