using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SoulAgent : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Transform waypointsToFollow;
    [SerializeField]
    private SoulModelHandlerScript handler;
    private Transform[] waypoints;
    private NavMeshAgent soulAgent;
    private Transform target;
    private int currentWaypoint;
    private bool isFound = false;
    private GameObject player;
    private float followDistance;
    private Vector3 initialPosition;

    //Adding Sounds
    [Header("Sounds")]
    [SerializeField] List<Sound> pickUpSounds;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        soulAgent = GetComponent<NavMeshAgent>();
        SetWaypoints();
        ResetSoul();
    }

    internal bool IsFound()
    {
        return isFound;
    }

    private void ResetSoul()
    {
        transform.position = initialPosition;
        soulAgent.speed = speed;
        isFound = false;
        handler.SetHardlock(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        handler.SetFound(isFound, player.GetComponent<PlayerStats>().GetLightRadius(), distanceToPlayer);

        if (!isFound)
        {
            //if next point reached
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
        else
        {
            soulAgent.destination = player.transform.position;
            followDistance = Mathf.Clamp(player.GetComponent<PlayerStats>().GetLightRadius()*.2f,1f,10f);
            print(followDistance);
            handler.SetDeadZone(followDistance);
            if (distanceToPlayer < followDistance){
                soulAgent.speed = 0f;
                handler.SetHardlock(true);
            }
            else
            {
                soulAgent.speed = speed;
            }
        }
        
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
            soulAgent.destination = target.position;
    }

    public void SetFound(bool setIsFound)
    {
        if (!isFound && setIsFound)
        {
            PlaySound_PickUp();

        }
        if (setIsFound)
        {
            isFound = true;
        }
        else
        {
            ResetSoul();
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
        soulAgent.destination = target.position;
    }


    void PlaySound_PickUp()
    {
        print(this + " play found sound");
        pickUpSounds[UnityEngine.Random.Range(0, pickUpSounds.Count)].Play();
    }
}
