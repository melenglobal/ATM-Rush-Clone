using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestroyerControl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money") || other.gameObject.CompareTag("Gold") || other.gameObject.CompareTag("Diamond"))
        {
            Debug.Log("Gördüm ordasýn!");
            int index = other.transform.GetComponent<IndexHolder>().index;

            for (int i = index; i < CubeController.Instance.stackList.Count; i++)
            {
                CubeController.Instance.stackList[i].transform.SetParent(null);
                var pos = CubeController.Instance.stackList[i].transform;
                CubeController.Instance.stackList[i].transform.DOJump(pos.position + Vector3.forward, 5.0f, 4, 1.5f);
                CubeController.Instance.stackList.RemoveAt(i);
            }

        }
    }
}
