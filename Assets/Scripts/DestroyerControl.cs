using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class DestroyerControl : MonoBehaviour
{
    private PickUpController pickUpController;
    public PickUpController PickUpController { get { return pickUpController == null ? pickUpController = transform.root.GetComponentInChildren<PickUpController>() : pickUpController; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroyer"))
        {
            
            other.transform.GetComponent<Collider>().enabled = false;
            var index = PickUpController.stackList.IndexOf(transform.gameObject); // vurduğum objenin indexi
            Debug.Log(index);
            var count = PickUpController.stackList.Count;
            for (int i = PickUpController.stackList.Count-1; i >= index; i--)
            {
                PickUpController.stackList[i].GetComponent<IndexHolder>().index = 0;
                PickUpController.stackList[i].transform.SetParent(null);
                PickUpController.stackList[i].gameObject.transform.tag = "PickUp";
               
                PickUpController._collider.size -= Vector3.forward;
                
                PickUpController.stackList[i].transform.DOJump(PickUpController.stackList[i].transform.position,1,2,.1f);

                PickUpController.stackList.RemoveAt(i);



            }

            Debug.Log(Vector3.forward * (count - index) / 2);
            Debug.Log(Vector3.forward * (count - index));
            //PickUpController._collider.size -= Vector3.forward * index;
            PickUpController._collider.center -= Vector3.forward * (count-index)/2;
            PickUpController.pos -= Vector3.forward * (count - index);

            Destroy(this);
        }
     
    }
}