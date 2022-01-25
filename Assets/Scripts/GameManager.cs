using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Start,

    Playing,

    Collision,

    Finish
}
public class GameManager : Singleton<GameManager>
{
    public State state;

    public GameObject Player;
    private Animator _playerAnimations;
    public int score;


    private void Awake()
    {
        score = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        state = State.Start;
        InitGame();
    }

    public void InitGame()
    {
        _playerAnimations = Player.transform.GetChild(1).gameObject.GetComponent<Animator>();
        state = State.Playing;
    }


    public int IncreaseScore()
    {
        score++;
        return score;

    }


    public void CallFinish()
    {
        state = State.Finish;
    }
}
