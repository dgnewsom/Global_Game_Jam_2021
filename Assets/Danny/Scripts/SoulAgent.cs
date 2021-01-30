﻿using System;
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
    private Transform[] waypoints;
    private NavMeshAgent soulAgent;
    private Transform target;
    private int currentWaypoint;
    private bool isFound = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        soulAgent = GetComponent<NavMeshAgent>();
        SetWaypoints();
        soulAgent.speed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            if (Vector3.Distance(transform.position, player.transform.position) < player.GetComponent<PlayerStats>().GetLightRadius() -1f){
                soulAgent.speed = 0f;
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

    internal void SetFound()
    {
        isFound = true;
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
}
