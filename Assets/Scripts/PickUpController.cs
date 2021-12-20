using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpController : MonoBehaviour
{
    public int score;
    private GameObject pickUp;
    public Vector3 pos;
   public  BoxCollider _collider;
    private bool isPickedUp;
    public List<GameObject> stackList;

    private void Awake()
    {
        pos = Vector3.zero;
        _collider = GetComponent<BoxCollider>();

    }
    private void Update()
    {
        if (isPickedUp)
        {
            MoveWavely();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            //Tagi sağ-sol yaparken birbirleriyle tekrar etkileştikleri için değiştik.
            other.tag = "Money";
            score++;
            //adding
            other.transform.SetParent(this.transform);
           
            other.transform.localPosition = pos;
            
            stackList.Add(other.gameObject);
            other.gameObject.AddComponent<DestroyerControl>();
            other.GetComponent<IndexHolder>().index = stackList.Count - 1;

            pos.z += 1;
            //collider size
           
            _collider.size += Vector3.forward;
            _collider.center += Vector3.forward/2;
            StartCoroutine(ScaleMotion());
            
        }
    }


    IEnumerator ScaleMotion()
    {
        yield return new WaitForSeconds(0.05f);
        for (int i = stackList.Count - 1; i >= 0; i--)
        {
            stackList[i].transform.DOScale(1.2f, 0.2f).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(0.2f);
        }
        isPickedUp = true;

    }
    void MoveWavely()
    {
        if (stackList!=null)
        {
            for (int i = stackList.Count-1; i >= 1; i--)
            {
                stackList[i].transform.DOMoveX(stackList[i - 1].transform.position.x, 0.1f);
            }   
        }
        
      
    }

}
