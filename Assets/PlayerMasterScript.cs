using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMasterScript : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerLightHandlerScript playerLightHandler;

    private void FixedUpdate()
    {
        playerLightHandler.UpdateRange(playerStats.GetLightRadius());
    }

}
