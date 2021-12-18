using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{Start,Playing,Collision,Finish}
public class GameManager : Singleton<GameManager>
{
    public State state=State.Start;
}
