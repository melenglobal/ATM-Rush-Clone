using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IndexHolder : MonoBehaviour
{
    public int index;

    [SerializeField] PickUpController pickUpController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Band"))
        {
            GameManager.Instance.score++;

            int count = pickUpController.stackList.Count;
            if (pickUpController.stackList.Count> 0)
            {
                pickUpController.stackList.RemoveAt(pickUpController.stackList.Count - 1);

                pickUpController._collider.size -= Vector3.forward * (count - index);

                pickUpController._collider.center -= Vector3.forward * (count - index) / 2;

                pickUpController.pos -= Vector3.forward * (count - index);

                Transform transform1;
                (transform1 = transform).SetParent(null);

                var position = transform1.position;
                var position1 = other.transform.position;
                position = new Vector3(position.x, position.y, position1.z);
                transform1.position = position;
                transform.DOMoveX(position1.x, 1f);
            }
            

        }
        
    }
}
