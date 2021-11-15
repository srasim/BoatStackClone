using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerInGameState : LevelManagerBaseState
{
    LevelManager levelManager;
    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.inGameCanvas.GetComponent<Canvas>().enabled = true;//open inGammeCanvas
    }

    public override void UpdateState()
    {
        levelManager.player.PlayerMove();
    }
    public override void ExitState()
    {
        levelManager.inGameCanvas.GetComponent<Canvas>().enabled = false;//close inGammeCanvas
    }
}

