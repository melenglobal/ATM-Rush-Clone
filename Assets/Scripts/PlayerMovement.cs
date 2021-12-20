using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private PickUpController pickUpController;
    public PickUpController PickUpController { get { return pickUpController == null ? pickUpController = transform.root.GetComponentInChildren<PickUpController>() : pickUpController; } }
    SwipeControl swipeControl;
    private bool isFinished;

    [SerializeField]
    float sensivity = 5f;

    [SerializeField]
    float xSpeed = 15f;

    [SerializeField]
     float zSpeed = 0.05f;


    Vector2 readingValue;
    Vector3 movementValue;

    private void Awake()
    {
       
        readingValue = Vector2.zero;

        swipeControl = new SwipeControl();

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
       
            PlayerControlMovement();
        
    }

    
    public void MovementInputX(InputAction.CallbackContext context)
    {
        readingValue = context.ReadValue<Vector2>();
        movementValue.x = readingValue.x;
    }


    private void PlayerControlMovement()
    {
        if (isFinished==false)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.75f, 1.75f), transform.position.y,
                transform.position.z);
            transform.Translate(Vector3.forward * Time.deltaTime * zSpeed);
            transform.Translate(movementValue/sensivity * Time.deltaTime * xSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Band"))
        {
            isFinished = true;

                for (int i = PickUpController.stackList.Count - 1; i >= 1; i--)
                {
                    PickUpController.stackList[i].transform.DOMoveY(PickUpController.stackList[i - 1].transform.position.y, 0.2f);
                }
        }
    }
}
