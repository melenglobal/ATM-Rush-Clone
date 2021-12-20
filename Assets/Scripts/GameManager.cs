using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{Start,Playing,Collision,Finish}
public class GameManager : Singleton<GameManager>
{
    public State state;

    private void Awake()
    {
        state = State.Start;
        state = State.Finish;
    }
}
