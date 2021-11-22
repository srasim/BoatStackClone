using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPreGameState : LevelManagerBaseState
{
    float swipeSpeed = 0.01f;
    LevelManager levelManager;
    Vector3 lastMousePosition;
    Vector3 swipe;
    Vector3 tempPlayerPosition;
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

            tempPlayerPosition = levelManager.player.transform.position;
            tempPlayerPosition.x += swipe.x*swipeSpeed;

            if (tempPlayerPosition.x > 4.5f)//TODO : Plane bounds should be different
                tempPlayerPosition.x = 4.5f;
            else if (tempPlayerPosition.x < -4.5f)
                tempPlayerPosition.x = -4.5f;

            levelManager.player.transform.position = tempPlayerPosition;

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
