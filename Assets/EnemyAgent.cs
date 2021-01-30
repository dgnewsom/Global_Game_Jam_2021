using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Transform waypointsToFollow;
    [SerializeField]
    private float chargeDelay = 2f;
    private Transform[] waypoints;
    private NavMeshAgent enemyAgent;
    private Transform target;
    private int currentWaypoint;
    private bool isCharging = false;
    private GameObject player;
    private float currentCharge = 0f;
    bool isAttacking = false;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        SetWaypoints();
        enemyAgent.speed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isCharging)
        {
            //if next point reached
            enemyAgent.speed = speed;
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
        else
        {
            currentCharge += Time.deltaTime;
            enemyAgent.destination = player.transform.position;
            enemyAgent.speed = speed / 2;
            if (currentCharge > chargeDelay)
            {
                AttackPlayer();
            }
            print("Charging - " + currentCharge / chargeDelay);
            // todo set shader
        }

    }

    private void AttackPlayer()
    {
        isCharging = false;
        isAttacking = true;
        print("Attacking");
        currentCharge = 0f;
        // todo charge code
    }

    public void SetWaypoints()
    {
        try
        {
            waypoints = new Transform[waypointsToFollow.childCount];
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = waypointsToFollow.GetChild(i);
            }
            target = waypoints[0];
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
        if (target != null)
            enemyAgent.destination = target.position;
    }

    internal void SetCharging()
    {
        if (!isAttacking)
        {
            isCharging = true;
        }
        
    }

    //Get next waypoint and reset to first if last waypoint reached.
    private void GetNextWaypoint()
    {
        if (currentWaypoint >= waypoints.Length - 1)
        {
            currentWaypoint = 0;
        }
        else
        {
            currentWaypoint++;
        }
        target = waypoints[currentWaypoint];
        enemyAgent.destination = target.position;
    }
}
