using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    protected float Distance;
    public Transform Target;
    public float chaseRange = 10;
    public float attackRange = 2.2f;
    public float attackRepeatTime = 1;
    private float attackTime;
    public float TheDammage;
    public GameObject RewardSpawner;
    public Rigidbody RewardRef;
    private Transform Spawn;
    

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animations;
    private Animation anim;
    public float enemyHealth;
    public Slider healthbar;
    protected bool isDead = false;
    public int ID { set; get; } = 1;
    
    
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;
    private bool isChasing = false;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
        transform.position = waypoints[waypointIndex].transform.position;
        animations.SetBool("walk", true);
    }



    void Update()
    {
        healthbar.value = enemyHealth;

        if (!isDead)
        {
            Target = GameObject.Find("player(Clone)").transform;


            Distance = Vector3.Distance(Target.position, transform.position);

            
            
            if (Distance > chaseRange)
            {
                animations.SetBool("attack", false);
                Move();
            }
            


            if (Distance < chaseRange && Distance > attackRange)
            {
                animations.SetBool("attack", false);
                chase();
            }


            if (Distance < attackRange)
            {
                attack();
            }
            
            

        }
       
        
    }


    protected void chase()
    {
        animations.SetBool("walk", true);
        agent.destination = Target.position;
    }


    void attack()
    {

        agent.destination = transform.position;


        if (Time.time > attackTime)
        {
            animations.SetBool("attack", true);
            Target.GetComponent<PlayerInventory>().ApplyDamage(TheDammage);
            Debug.Log("L'ennemi a envoy� " + TheDammage + " points de d�g�ts");
            attackTime = Time.time + attackRepeatTime;
        }
    }


    void idle()
    {
        animations.Play("Idle");
    }
    
    protected void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 1f)
            //if (transform.position == waypoints[waypointIndex].transform.position)
            {
                Debug.Log("change destination");
                waypointIndex += 1;
            }
            
            if (waypointIndex < waypoints.Length)
            {
                transform.LookAt(waypoints[waypointIndex].position);
            }
        }

        if (waypointIndex == waypoints.Length - 1)
        {
            waypointIndex = 0;
        }
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
        animations.SetBool("dead", true);
        animations.SetBool("walk", false);
        Destroy(transform.gameObject, 5);
        Spawn = RewardSpawner.transform.Find("Skeleton");
        Rigidbody reward;
        reward = Instantiate(RewardRef, Spawn.position, Spawn.rotation);
        reward.AddForce(0f, 150f, 0f);
        CombatEnemy.SkeletonDied(this);
        PlayerInventory.currentXP += 25;
    }
}
