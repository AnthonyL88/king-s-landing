using System.Collections;
using System.Collections.Generic;
using Golemall;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    private float Distance;
    public Transform Target;
    public float chaseRange = 15;
    public float attackRange = 2.2f;
    public float attackRepeatTime = 1;
    private float attackTime;
    public float TheDammage;
    public GameObject RewardSpawner;
    public Rigidbody RewardRef;
    private Transform Spawn;
    

    private UnityEngine.AI.NavMeshAgent agent;
    private Animation animations;
    public float enemyHealth;
    public float AgressiveHealth;
    public Slider healthbar;
    private bool isDead = false;

    void Start()
    {
        AgressiveHealth = enemyHealth/2;
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
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

            if (enemyHealth <= AgressiveHealth)
            {
                transform.localScale = new Vector3(2f, 2f, 2f);
                TheDammage += 10;
            }

        }
    }


    void chase()
    {
        animations.Play("Monster_anim_Walk");
        agent.destination = Target.position;
    }


    void attack()
    {

        agent.destination = transform.position;


        if (Time.time > attackTime)
        {
            animations.Play("Monster_anim_Atack");
            Target.GetComponent<PlayerInventory>().ApplyDamage(TheDammage);
            Debug.Log("L'ennemi a envoy� " + TheDammage + " points de d�g�ts");
            attackTime = Time.time + attackRepeatTime;
        }
    }


    void idle()
    {
        animations.Play("Monster_anim_Idle_1");
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
        animations.Play("Monster_anim_Get_hit");
        Destroy(transform.gameObject, 5);
        Spawn = RewardSpawner.transform.Find("Orc");
        Rigidbody reward;
        reward = Instantiate(RewardRef, Spawn.position, Spawn.rotation);
        reward.AddForce(0f, 150f, 0f);
        PlayerInventory.currentXP += 150;
    }
}
