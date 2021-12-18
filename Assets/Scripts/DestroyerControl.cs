using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestroyerControl : MonoBehaviour
{
    private PickUpController pickUpController;
    public PickUpController PickUpController { get { return pickUpController == null ? pickUpController = transform.root.GetComponentInChildren<PickUpController>() : pickUpController; } }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroyer"))
        {
            
            other.transform.GetComponent<Collider>().enabled = false;
            var index =PickUpController.stackList.IndexOf(transform.gameObject);
            Debug.Log(index);
            for (int i = pickUpController.stackList.Count-1; i >= index; i--)
            {
                PickUpController.stackList[i].transform.SetParent(null);
                PickUpController.stackList[i].transform.DOJump(PickUpController.stackList[i].transform.position,5,4,1);
                PickUpController.stackList.RemoveAt(i);
                PickUpController.pos.z -= pickUpController.stackList.Count-index;
            }
            
        }
    }
}