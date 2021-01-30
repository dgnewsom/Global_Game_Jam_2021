using System;
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
    [SerializeField]
    private float attackSpeed = 20f;
    [SerializeField]
    private float attackDistance = 10f;
    [SerializeField]
    GameObject prefabForRespawn;
    private Vector3 initialPosition;
    private NavMeshAgent enemyAgent;
    private Transform[] waypoints;
    private Vector3 target;
    private int currentWaypoint;
    private bool isCharging = false;
    private GameObject player;
    private float currentCharge = 0f;
    bool isAttacking = false;
    private Vector3 attackTarget;
    private bool isDead;
    

    // Start is called before the first frame update
    void Start()
    {
        ResetEnemy();
    }

    private void ResetEnemy()
    {
        initialPosition = GetComponentInParent<Transform>().position;
        enemyAgent = GetComponent<NavMeshAgent>();
        SetWaypoints();
        enemyAgent.speed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
        isAttacking = false;
        isCharging = false;
        isDead = false;
        currentCharge = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {

            if (isAttacking)
            {
                if(Vector3.Distance(attackTarget, transform.position) <= 1f)
                {
                    Death();
                }
            }
            else if (!isCharging)
            {
                //if next point reached
                if (!isAttacking)
                {
                    enemyAgent.speed = speed;
                }
            
                if (Vector3.Distance(transform.position, target) <= 0.2f)
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
            
                // todo set shader
            }
        }

    }

    public void Death()
    {
        isDead = true;
        GameObject reSpawn = GameObject.Instantiate(prefabForRespawn,initialPosition,Quaternion.identity,this.transform.parent);
        reSpawn.GetComponent<EnemyAgent>().ResetEnemy();
        isAttacking = false;
        enemyAgent.speed = 0;
        GameObject.Destroy(this.gameObject,1f);
    }

    
    private void AttackPlayer()
    {
        isCharging = false;
        isAttacking = true;
        currentCharge = 0f;
        enemyAgent.velocity = Vector3.zero;
        enemyAgent.speed = attackSpeed;
        Vector3 direction = player.transform.position - transform.position;

        Vector3 moveDir = (new Vector3(direction.x,0f,direction.z)).normalized * attackDistance;
        //Debug.DrawRay(transform.position, moveDir ,Color.red,20f);
        attackTarget = transform.position + moveDir;
        target = attackTarget;
        enemyAgent.SetDestination(target);
        
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
            target = waypoints[0].position;
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
        if (target != null)
            enemyAgent.destination = target;
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
        target = waypoints[currentWaypoint].position;
        enemyAgent.destination = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats.soulsFollowing() > 0)
            {
                GameObject removedSoul = playerStats.removeSoul();
                removedSoul.GetComponent<SoulAgent>().SetFound(false);
            }
        }
    }
}
