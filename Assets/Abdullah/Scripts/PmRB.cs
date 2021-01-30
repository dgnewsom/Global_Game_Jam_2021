using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PmRB : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] Bonfire bonfireScript;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector3(context.ReadValue<Vector2>().x * moveSpeed, 0, context.ReadValue<Vector2>().y * moveSpeed);
    }

    public void Deposit(InputAction.CallbackContext context)
    {
        if (bonfireScript != null)
        {
            bonfireScript.OnDeposit(context);

        }
    }

    public void Withdraw(InputAction.CallbackContext context)
    {
        if (bonfireScript != null)
        {
            bonfireScript.OnWithdraw(context);
        }
    }
}
