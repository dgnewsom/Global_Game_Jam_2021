using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bonfire : MonoBehaviour
{
    [SerializeField] GameObject bonfire;
    [SerializeField] Stack<GameObject> bonfireSouls;
    [SerializeField] PlayerStats playerStats;
    bool atBonfire;
    

    private void Awake()
    {
        bonfireSouls = new Stack<GameObject>();
        atBonfire = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            atBonfire = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            atBonfire = false;
        }
    }

    public void OnDeposit(InputAction.CallbackContext context) 
    {
        if (playerStats.soulsFollowing() > 0 && atBonfire && context.performed) {
            bonfireSouls.Push(playerStats.removeSoul());
        }
       
    }

    public void OnWithdraw(InputAction.CallbackContext context) {
        if (playerStats.soulsFollowing() > 0 && atBonfire && context.performed)
        {
            playerStats.addSoul(bonfireSouls.Pop());
        }
    }
}
