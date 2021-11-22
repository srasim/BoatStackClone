using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPreGameState : LevelManagerBaseState
{
    float slideSpeed = 0.01f;
    LevelManager levelManager;
    Vector3 lastMousePosition;
    Vector3 swipe;
    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.preGameCanvas.GetComponent<Canvas>().enabled = true;//Open preGameCanvas
    }

    public override void UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            swipe = Input.mousePosition - lastMousePosition;

            levelManager.player.transform.position = new Vector3
                                                   (levelManager.player.transform.position.x + swipe.x * slideSpeed,
                                                    levelManager.player.transform.position.y,
                                                    levelManager.player.transform.position.z);

            lastMousePosition = Input.mousePosition;
            levelManager.inGame.lastMousePosition = this.lastMousePosition;//Set inGame 's lastMousePosition 
            levelManager.TransitionToState(levelManager.inGame);
        }
    
    }

    public override void ExitState()
    {
        levelManager.preGameCanvas.GetComponent<Canvas>().enabled = false;//Close preGameCanvas
    }

}
