    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] PickUpController pickUpController;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

           // int _index = PickUpController.stackList.IndexOf(transform.gameObject);
            Vector3 newPos = new Vector3(0, 1.5f, 0);
           /* for (int i = 0; i < _index; i++)
            {
                
                newPos.y += 1;
                
            }*/
        }
        
    }

   
}
