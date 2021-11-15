using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerSuccessGameState :LevelManagerBaseState
{
    LevelManager levelManager;

    public override void EnterToState(LevelManager levelManager)
    {
    
        this.levelManager = levelManager;
        levelManager.successGameCanvas.GetComponent<Canvas>().enabled = true;//open sucessGameCanvas
    }

    public override void UpdateState()
    {
        
    }
    public override void ExitState()
    {
        levelManager.successGameCanvas.GetComponent<Canvas>().enabled = false;//close sucessGameCanvas
    }

}
