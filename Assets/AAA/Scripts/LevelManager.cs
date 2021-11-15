using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public readonly LevelManagerPreGameState preGame = new LevelManagerPreGameState();
    public readonly LevelManagerInGameState inGame = new LevelManagerInGameState();
    public readonly LevelManagerFailGameState failGame = new LevelManagerFailGameState();
    public readonly LevelManagerSuccessGameState successGameState = new LevelManagerSuccessGameState();
    private LevelManagerBaseState currentState;

    public PlayerController player;
    public Canvas preGameCanvas;
    public Canvas inGameCanvas;
    public Canvas failGameCanvas;
    public Canvas successGameCanvas;
    
    void Start()
    {
        currentState = this.preGame;
        preGame.EnterToState(this);
    }
    void Update()
    {
        currentState.UpdateState();
    }

    public void TransitionToState(LevelManagerBaseState targetState)
    {
        currentState.ExitState();
        currentState = targetState;
        currentState.EnterToState(this);
    }
}
