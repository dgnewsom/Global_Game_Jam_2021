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

    private void OnTriggerEnter(Collider collider)
    {
        print(collider.ToString());
        if(collider.gameObject.tag == "Soul")
        {
            collider.gameObject.GetComponent<SoulAgent>().SetFound(this.gameObject);
            playerStats.addSoul(collider.gameObject);
        }
    }
}
