﻿using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool doorOpened;
    [SerializeField] float doorHeight;
    [SerializeField]PlayerStats playerStats;
   [SerializeField] int triggerRequirement;

    private void Start()
    {
        doorOpened = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")){

            if (!doorOpened)
            {
                if (playerStats.SoulsFollowing() >= triggerRequirement) {
                    door.transform.position += new Vector3(0, -doorHeight, 0);
                    doorOpened = true; }
            }
            else
            {
                if (playerStats.SoulsFollowing() >= triggerRequirement)
                {
                    door.transform.position += new Vector3(0, doorHeight, 0);
                    doorOpened = false;
                }
            } 
        }
        
    }

    public bool LevelComplete() {
        return doorOpened;
    }
}
