using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    SwipeControl swipeControl;

    [SerializeField]
    float sensivity = 5f;

    [SerializeField]
    float xSpeed = 20f;

    [SerializeField]
     float zSpeed = 0.1f;


    Vector2 readingValue;
    Vector3 movementValue;

    private void Awake()
    {
        readingValue = Vector2.zero;
        swipeControl = new SwipeControl();
        //characterController = GetComponent<CharacterController>();

        swipeControl.Move.MoveX.started += MovementInputX;

        swipeControl.Move.MoveX.performed += MovementInputX;

        swipeControl.Move.MoveX.canceled += MovementInputX;

    }

    private void OnEnable()
    {
        swipeControl.Enable();
    }

    private void OnDisable()
    {
        swipeControl.Disable();
    }

    private void Update()
    {
        MoveForward();

        transform.Translate(movementValue/sensivity * Time.deltaTime * xSpeed);

    }

    
    public void MovementInputX(InputAction.CallbackContext context)
    {
        readingValue = context.ReadValue<Vector2>();
        movementValue.x = readingValue.x;
    }



    public void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * zSpeed);
    }

}
