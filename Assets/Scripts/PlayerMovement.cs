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
 
    public IndexHolder indexHolder;
    SwipeControl swipeControl;
  
    public Transform pos;
    public GameObject _prefab;
    public float offsetY;
    private GameManager gm;
    [SerializeField]
    float sensivity = 5f;

    [SerializeField]
    float xSpeed = 15f;

    [SerializeField]
     float zSpeed = 0.05f;


    Vector2 readingValue;
    Vector3 movementValue;

    public bool isWalking = true;

    private void Awake()
    {

        gm = GameManager.Instance;
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
        if (gm.state == State.Playing)
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
            isWalking = false;
            //myAnim.SetBool("isWalking",isWalking);
            gm.CallFinish();

            Debug.Log(gm.IncreaseScore());

//            HappyBanker.SetActive(false);
            

            for (int i = 0; i < gm.score; i++)
            {
                
                Instantiate(_prefab, pos.position + new Vector3(0, offsetY, 0), Quaternion.identity);
                offsetY += 1;
 

            }




        }
    }
}
