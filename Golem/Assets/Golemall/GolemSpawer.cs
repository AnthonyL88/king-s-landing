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
        Debug.Log("fetet 3a enemy died2");
        Debug.Log($"{CurrentAmount} {RequiredAmount}");
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
        Debug.Log("fetet 3a spawn Golem");
        for (int i = 0; i < 3; i++)
        {
            GameObject c = GameObject.Find("GolemSpawners");
            if (c is null)
                Debug.Log("yfgemvkv");
            Transform Golemspawner = c.transform.Find($"GolemSpawner{i}");
            if (Golemspawner is null)
                Debug.Log("ma le2a el Golemspawner");
            if (Golemspawner is null)
                Debug.Log("rig is null");
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

