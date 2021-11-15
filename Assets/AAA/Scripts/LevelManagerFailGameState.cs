using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerFailGameState : LevelManagerBaseState
{
    LevelManager levelManager;

    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.failGameCanvas.GetComponent<Canvas>().enabled = true;//open failGameCanvas
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        levelManager.failGameCanvas.GetComponent<Canvas>().enabled = false;//close failGameCanvas
    }

}
