using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{Start,Playing,Collision,Finish}
public class GameManager : Singleton<GameManager>
{
    public State state;

    private GameObject Player;

    public int score;


    private void Awake()
    {
        score = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        state = State.Start;;
    }

    public int IncreaseScore()
    {
        score++;
        return score;

    }
}
