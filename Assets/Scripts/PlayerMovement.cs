using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    SwipeControl swipeControl;
    Vector3 temp;

    CharacterController characterController;
    Movement movement;

    [SerializeField]
    Vector3 movementTransform;
    
    [SerializeField]
    float speed = 3f;

    [SerializeField]
    float sensivity = 5f;

    Vector2 readingValue;
    Vector3 movementValue;

    private void Awake()
    {
        readingValue = Vector2.zero;
        swipeControl = new SwipeControl();
        characterController = GetComponent<CharacterController>();
        movement = GetComponent<Movement>();

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
        characterController.Move(movementValue/5);
    }

    void MovementInputX(InputAction.CallbackContext context)
    {
        readingValue = context.ReadValue<Vector2>();
        movementValue.x = readingValue.x;
    }
}
