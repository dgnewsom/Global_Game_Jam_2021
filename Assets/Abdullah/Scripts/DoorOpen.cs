﻿using TMPro;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool doorOpened;
    [SerializeField] float doorHeight;
    [SerializeField]PlayerStats playerStats;
    [SerializeField] int triggerRequirement;
    [SerializeField] TextMeshProUGUI plateText;
    [SerializeField] GameObject notification;
    [SerializeField] LeanTweenType easeType;

    private void Start()
    {
        doorOpened = false;
        plateText.text = "x" + triggerRequirement.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            LeanTween.scale(notification, new Vector3(0, 0, 0), 0.75f).setEase(easeType);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!doorOpened)
            {
                LeanTween.scale(notification, new Vector3(0.1f, 0.1f, 0.1f), 0.75f).setEase(easeType);
                plateText.text = "x" + (Mathf.Clamp(triggerRequirement - playerStats.SoulsFollowing(), 0, 50)).ToString();
                if (playerStats.SoulsFollowing() >= triggerRequirement) {
                    door.transform.position += new Vector3(0, -doorHeight, 0);
                    doorOpened = true;
                }
            }
            else
            {
                if (playerStats.SoulsFollowing() >= triggerRequirement)
                {
                    door.transform.position += new Vector3(0, doorHeight, 0);
                    doorOpened = false;
                    LeanTween.scale(notification, new Vector3(0, 0, 0), 0.75f).setEase(easeType);
                    plateText.text = "x" + triggerRequirement.ToString();
                }
            } 
        }
    }

    public bool LevelComplete() {
        return doorOpened;
    }
}
