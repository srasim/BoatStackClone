using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPreGameState : LevelManagerBaseState
{
    LevelManager levelManager;
    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.preGameCanvas.GetComponent<Canvas>().enabled = true;//Open preGameCanvas
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        levelManager.preGameCanvas.GetComponent<Canvas>().enabled = false;//Close preGameCanvas
    }

}
