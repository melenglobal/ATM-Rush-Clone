using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Singleton<CubeController>
{

    public List<Transform> stackList;
    public Transform stackPos;
    public bool isCollect;
    public int stackLength;

    private void Awake()
    {
        stackList = new List<Transform>();
    }


}
