using System.Collections;
using System.Collections.Generic;
using Golemall;
using UnityEngine;
using UnityEngine.UI;

public class enemyAi : MonoBehaviour
{
    private float Distance;
    public Transform Target;
    public float chaseRange = 10;
    public float attackRange = 2.2f;
    public float attackRepeatTime = 1;
    private float attackTime;
    public float TheDammage;
    public GameObject RewardSpawner;
    public Rigidbody RewardRef;
    private Transform Spawn;
    private PlayerInventory playerinv;
    

    private UnityEngine.AI.NavMeshAgent agent;
    private Animation animations;
    public float enemyHealth;
    public Slider healthbar;
    private bool isDead = false;
    public int ID { set; get; } = 0;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
        playerinv = gameObject.GetComponent<PlayerInventory>();
    }



    void Update()
    {
        healthbar.value = enemyHealth;

        if (!isDead)
        {
            Target = GameObject.Find("player").transform;


            Distance = Vector3.Distance(Target.position, transform.position);


            if (Distance > chaseRange)
            {
                idle();
            }


            if (Distance < chaseRange && Distance > attackRange)
            {
                chase();
            }


            if (Distance < attackRange)
            {
                attack();
            }

        }
    }


    void chase()
    {
        animations.Play("walk");
        agent.destination = Target.position;
    }


    void attack()
    {

        agent.destination = transform.position;


        if (Time.time > attackTime)
        {

                animations.Play("hit");
                Target.GetComponent<PlayerInventory>().ApplyDamage(TheDammage);
                Debug.Log("L'ennemi a envoy� " + TheDammage + " points de d�g�ts");
                attackTime = Time.time + attackRepeatTime;
            
        }
    }


    void idle()
    {
        animations.Play("idle");
    }

    public void ApplyDammage(float TheDammage)
    {
        if (!isDead)
        {
            enemyHealth = enemyHealth - TheDammage;
            print(gameObject.name + "a subit " + TheDammage + " points de degats.");

            if (enemyHealth <= 0)
            {
                Dead();
            }
        }
    }

    public void Dead()
    {
        isDead = true;
        animations.Play("die");
        Destroy(transform.gameObject, 5);
        Spawn = RewardSpawner.transform.Find("Golem");
        Rigidbody reward;
        reward = Instantiate(RewardRef, Spawn.position, Spawn.rotation);
        reward.AddForce(0f, 150f, 0f);
        CombatEnemy.EnemyDied(this);
        CombatGolem.EnemyDied2(this);
        PlayerInventory.currentXP += 20;
    }
}