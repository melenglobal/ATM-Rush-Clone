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
    public bool isGameStarted;
    public State state;

    public GameObject Player;
    private Animator _playerAnimations;
    public int score;

    public FinishControl finishControl;


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
        _playerAnimations.SetBool("isWalking", true);
        state = State.Playing;
        isGameStarted = true;
    }


    public int IncreaseScore()
    {
        score++;
        return score;

    }


    public void CallFinish()
    {
        state = State.Finish;
        isGameStarted = false;
        _playerAnimations.SetBool("isWalking", false);
        //finishControl.NextLevel();

    }
}
