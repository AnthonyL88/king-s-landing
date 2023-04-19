using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    PlayerInventory playerInv;

    // Animations du perso
    Animation animations;

    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    // Variables concernant l'attaque
    public float attackCooldown;
    private bool isAttacking;
    private float currentCooldown;
    public float attackRange;
    public GameObject rayhit;


    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;
    private LayerMask layer;
    

    // Le personnage est-il mort ?
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        layer = LayerMask.GetMask("Default");
        rayhit = GameObject.Find("RayHit");
        playerInv = gameObject.GetComponent<PlayerInventory>();
        
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x,
   playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.08f, layer);
    }

    // Update is called once per frame
    void Update()
    {
         if (!isDead)
            {
                // si on avance
                if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(0, 0, walkSpeed * Time.deltaTime);

                    if (!isAttacking)
                    {
                        animations.Play("walk");
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Attack();
                    }
                }

                // Si on sprint
                if (Input.GetKey(inputFront) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Q)))
                {
                    transform.Translate(0, 0, runSpeed * Time.deltaTime);
                    animations.Play("run");
                }

                // si on recule
                if (Input.GetKey(inputBack))
                {
                    transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);

                    if (!isAttacking)
                    {
                        animations.Play("walk");
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Attack();
                    }
                }

                // rotation �  gauche
                if (Input.GetKey(inputLeft))
                {
                    transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                }

                // rotation �  droite
                if (Input.GetKey(inputRight))
                {
                    transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                }

                // Si on avance pas et que on recule pas non plus
                if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
                {
                    if (!isAttacking)
                    {
                        animations.Play("idle");
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Attack();
                    }
                }

                // Si on saute
                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    // Préparation du saut (Nécessaire en C#)
                    Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                    v.y = jumpSpeed.y;

                    // Saut
                    gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;

                }
            }

            if (isAttacking)
            {
                currentCooldown -= Time.deltaTime;
            }

            if (currentCooldown <= 0)
            {
                currentCooldown = attackCooldown;
                isAttacking = false;
            }
        

    }

    public void Attack()
    {
        
            if (!isAttacking)
            {
                animations.Play("attack");

                RaycastHit hit;

                if (Physics.Raycast(rayhit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
                {
                    Debug.DrawLine(rayhit.transform.position, hit.point, Color.red);

                     if(hit.transform.tag == "Enemy")
                     {
                          hit.transform.GetComponent<enemyAi>().ApplyDammage(playerInv.currentDamage);
                     }
                     if(hit.transform.tag == "Boss1")
                     {
                         hit.transform.GetComponent<Boss1>().ApplyDammage(playerInv.currentDamage);
                     }
                     if(hit.transform.tag == "Skeleton")
                     {
                         hit.transform.GetComponent<Skeleton>().ApplyDammage(playerInv.currentDamage);
                     }
                     
                }
                isAttacking = true;
            }
        

    }
}

