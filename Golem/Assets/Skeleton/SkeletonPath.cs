using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start () {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }
	
    // Update is called once per frame
    private void Update () 
    {
        /*
        // Move Enemy
        if (Distance > chaseRange)
            Move();
        else if (Distance < chaseRange && Distance > attackRange)
            chase();
        */
        /*
        if (!isDead)
        {
            Target = GameObject.Find("player").transform;
            Distance = Vector3.Distance(Target.position, transform.position);

            if (Distance > chaseRange)
            {
                Move();
            }
            else
            {
                chase();
            }
        }
        */

    }

    // Method that actually make Enemy walk
    protected void Move()
    {
        Debug.Log("move");
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
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
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
}