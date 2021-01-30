using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDetector : MonoBehaviour
{
    private SphereCollider detectionCollider;    
    private float currentLightRadius;
    private PlayerStats playerStats;

    private void Start()
    {
        detectionCollider = GetComponentInChildren<SphereCollider>();
        playerStats = GetComponentInParent<PlayerStats>();
        currentLightRadius = playerStats.GetLightRadius();
        detectionCollider.radius = currentLightRadius;
    }

    private void Update()
    {
        currentLightRadius = playerStats.GetLightRadius();
        detectionCollider.radius = currentLightRadius;
    }
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Soul")
        {
            SoulAgent colliderSoulAgent = collider.gameObject.GetComponent<SoulAgent>();
            if (!colliderSoulAgent.IsFound())
            {
                colliderSoulAgent.SetFound(true);
                playerStats.AddSoul(collider.gameObject);
            }
            
        }
        if(collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyAgent>().SetCharging();
        }
    }
}
