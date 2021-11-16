using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public readonly LevelManagerPreGameState preGame = new LevelManagerPreGameState();
    public readonly LevelManagerInGameState inGame = new LevelManagerInGameState();
    public readonly LevelManagerFailGameState failGame = new LevelManagerFailGameState();
    public readonly LevelManagerSuccessGameState successGame = new LevelManagerSuccessGameState();
    private LevelManagerBaseState currentState;
    public bool isItLastLevel = false;

    public PlayerController player;
    public Canvas preGameCanvas;
    public Canvas inGameCanvas;
    public Canvas failGameCanvas;
    public Canvas successGameCanvas;
    
    void Start()
    {
        currentState = this.preGame;
        preGame.EnterToState(this);
        if (SceneManager.GetActiveScene().buildIndex == 2)//level 3
            isItLastLevel = true;
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
