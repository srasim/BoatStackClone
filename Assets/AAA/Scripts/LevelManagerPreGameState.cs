using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPreGameState : LevelManagerBaseState
{
    LevelManager levelManager;
    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }

    public override void UpdateState()
    {
        
    }
}
