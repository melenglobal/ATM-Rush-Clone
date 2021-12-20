    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    private PickUpController pickUpController;
    public PickUpController PickUpController { get { return pickUpController == null ? pickUpController = transform.root.GetComponentInChildren<PickUpController>() : pickUpController; } }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            var _index = PickUpController.stackList.IndexOf(transform.gameObject);
            Vector3 newPos = new Vector3(0, 1.5f, 0);
            for (int i = 0; i < _index; i++)
            {
                
                newPos.y += 1;
                
            }
        }
        
    }

   
}
