using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ATMScore : MonoBehaviour
{
    private int score;
    public TMP_Text _score;


    [SerializeField] PickUpController pickUpController;

    public IndexHolder indexHolder;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Money") || other.CompareTag("Gold") || other.CompareTag("Money"))
        {

            if (other.CompareTag("Money"))
            {
                score++;
                _score.text = score.ToString();
            }
            else if (other.CompareTag("Gold"))
            {
                score+=2;
                _score.text = score.ToString();
            }
            else if (other.CompareTag("Money"))
            {
                score+=3;
                _score.text = score.ToString();
            }
            Debug.Log(other.gameObject.GetComponent<IndexHolder>().index);
            int index = other.gameObject.GetComponent<IndexHolder>().index; // vurduğum andaki index
            
            int count = pickUpController.stackList.Count; // vurduğum andaki count

            for (int i = pickUpController.stackList.Count - 1; i >= index; i--)
            {
                pickUpController.stackList[i].GetComponent<IndexHolder>().index = 0;

                pickUpController.stackList[i].transform.SetParent(null);

                pickUpController.stackList.RemoveAt(i);

            }

            Destroy(other.gameObject);


            pickUpController._collider.size -= Vector3.forward * index;

            pickUpController._collider.center -= Vector3.forward * (count - index) / 2;

            pickUpController.pos -= Vector3.forward * (count - index);

    

        }

        if (other.CompareTag("Player"))
        {
            this.transform.DOMoveY(-5f, 1f);
        }
    }
}
