using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarningsManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Money")
        {
            other.tag = "Gold";
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);


        }
        else if (other.tag == "Gold")
        {
            other.tag = "Diamond";
            other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            other.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (other.tag == "ATM")
        {
            Destroy(other.gameObject);
        }
    }

}
