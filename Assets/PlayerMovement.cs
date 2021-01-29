using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] int moveSpeed;
    
    CharacterController myCC;

    [SerializeField]Camera cam;
    
    Vector3 moveDirection;

    private void Start()
    {
        myCC = GetComponent<CharacterController>();  
    }

    private void Update()
    {
        Move();
    }

    
    private void Move()
    {
        myCC.Move(moveDirection * moveSpeed *Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveDirection = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
    }


   
}
