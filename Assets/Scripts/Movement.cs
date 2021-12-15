using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 20f;
    public bool isMoving;

    void Start()
    {

    }

    void Update()
    {
        if (isMoving)
        {
            MoveForward();
        }

    }

    public void MoveForward()
    {
        transform.position += Time.deltaTime * speed * Vector3.forward;
    }
}
