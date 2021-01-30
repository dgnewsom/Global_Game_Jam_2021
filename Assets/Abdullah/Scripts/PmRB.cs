using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PmRB : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveForce;
    [SerializeField] float maxSpeed;
    [SerializeField] Bonfire bonfireScript;
    [SerializeField] Vector3 moveDir;
    [SerializeField] bool isMoving;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (bonfireScript == null)
        {
            bonfireScript = FindObjectOfType<Bonfire>();
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isMoving = true;
            moveDir = new Vector3(context.ReadValue<Vector2>().x,0,context.ReadValue<Vector2>().y);
        }
        else
        {
            isMoving = false;
        }
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

    void Move()
    {
        if (rb.velocity.magnitude<= maxSpeed)
        {
            rb.AddForce(moveDir * moveForce * rb.mass * Time.deltaTime);
        }

    }
}
