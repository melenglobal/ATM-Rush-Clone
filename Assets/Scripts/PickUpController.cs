using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpController : MonoBehaviour
{
    private GameObject pickUp;
    private GameObject Player;
    private CubeController cubeController;
    public List<GameObject> List;
    public bool OnPickUp = false;
    public int Length;
    Vector3 pos;
    BoxCollider _collider;
   
    private void Awake()
    {
        cubeController = CubeController.Instance;
        Player = GameObject.Find("Player");
        pos = Vector3.zero;
        _collider = GetComponent<BoxCollider>();

    }
    private void Update()
    {
        MoveWavely();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "PickUp")
        {
            //Tagi sağ-sol yaparken birbirleriyle tekrar etkileştikleri için değiştik.
            other.tag = "Money";
            //adding
            OnPickUp = true;
            other.transform.SetParent(this.transform);

            other.transform.localPosition = pos;
            
            cubeController.stackList.Add(other.transform);

            pos.z += 1;
            //collider size
            Vector3 _size = _collider.size;
            

            _size.z += 1;

            Vector3 _center = _collider.center;

            _center.z += .5f;

            _collider.size = _size;

            _collider.center = _center;

            StartCoroutine(ScaleMotion());

        }
    }


    IEnumerator ScaleMotion()
    {
        yield return new WaitForSeconds(0.05f);
        for (int i = cubeController.stackList.Count - 1; i >= 0; i--)
        {
            cubeController.stackList[i].DOScale(1.2f, 0.2f).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(0.2f);
        }

    }
    void MoveWavely()
    {
        for (int i = cubeController.stackList.Count-1; i >= 1; i--)
        {
            cubeController.stackList[i].transform.DOMoveX(cubeController.stackList[i - 1].position.x, 0.1f);
        }
    }

}
