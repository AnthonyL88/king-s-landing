using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    public float SpellDammage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<enemyAi>().ApplyDammage(SpellDammage);
            
        }

        if (col.gameObject.tag == "Skeleton")
        {
            col.gameObject.GetComponent<Skeleton>().ApplyDammage(SpellDammage);

        }

        if (col.gameObject.tag == "Boss1")
        {
            col.gameObject.GetComponent<Boss1>().ApplyDammage(SpellDammage);

        }

        if (col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
