using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public readonly LevelManagerPreGameState preGame;
    public readonly LevelManagerInGameState inGame;
    public readonly LevelManagerFailGameState failGame;
    public readonly LevelManagerSuccessGameState successGameState;
    private LevelManagerBaseState currentState;

    public Canvas preGameCanvas;
    public Canvas inGameCanvas;
    public Canvas failGameCanvas;
    public Canvas successGameCanvas;
    
    void Start()
    {
        TransitionToState(this.preGame);
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
