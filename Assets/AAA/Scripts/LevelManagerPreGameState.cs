using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerPreGameState : LevelManagerBaseState
{
    float slideSpeed = 0.002f;
    LevelManager levelManager;
    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.preGameCanvas.GetComponent<Canvas>().enabled = true;//Open preGameCanvas
    }

    public override void UpdateState()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            levelManager.player.transform.position = new Vector3
                                                   (levelManager.player.transform.position.x + Input.touches[0].deltaPosition.x * slideSpeed,
                                                    levelManager.player.transform.position.y,
                                                    levelManager.player.transform.position.z);

            levelManager.TransitionToState(levelManager.inGame);
        }
    }

    public override void ExitState()
    {
        levelManager.preGameCanvas.GetComponent<Canvas>().enabled = false;//Close preGameCanvas
    }

}
