using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IndexHolder : MonoBehaviour
{
    public int index;
   
    private PickUpController pickUpController;
    public PickUpController PickUpController { get { return pickUpController == null ? pickUpController = transform.root.GetComponentInChildren<PickUpController>() : pickUpController; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Band"))
        {
            GameManager.Instance.score++;
            var count = PickUpController.stackList.Count;
            PickUpController.stackList.RemoveAt(PickUpController.stackList.Count-1);
            PickUpController._collider.size -= Vector3.forward* (count-index);
            PickUpController._collider.center -= Vector3.forward* (count-index)/2;
            PickUpController.pos -= Vector3.forward * (count - index);
            
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
