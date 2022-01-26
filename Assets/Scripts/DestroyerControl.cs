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

            if (PickUpController == null)
            {
                Debug.Log("Neden");
            }
            int index = PickUpController.stackList.IndexOf(transform.gameObject); // vurduğum andaki index
            
            int count = PickUpController.stackList.Count; // vurduğum andaki count

            for (int i = PickUpController.stackList.Count - 1; i >= index; i--)
            {
                PickUpController.stackList[i].GetComponent<IndexHolder>().index = 0;

                PickUpController.stackList[i].transform.SetParent(null);

                //PickUpController._collider.size -= new Vector3(0, 0, pickUpController.stackList[i].transform.position.z);

                PickUpController.stackList[i].transform.DOJump(this.transform.position + new Vector3(Random.Range(-2,1),0,Random.Range(15,20)),5,3,.1f);

                PickUpController.stackList[i].gameObject.transform.tag = "PickUp";

                PickUpController.stackList.RemoveAt(i);

            }
            
            PickUpController._collider.size -= Vector3.forward * index; 

            PickUpController._collider.center -= Vector3.forward * (count-index)/2;

            PickUpController.pos -= Vector3.forward * (count - index);

            Destroy(this);
        }
     
    }
}