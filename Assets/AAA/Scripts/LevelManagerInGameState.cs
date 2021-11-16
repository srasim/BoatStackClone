using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerInGameState : LevelManagerBaseState
{
    float slideSpeed = 0.002f;
    LevelManager levelManager;
    int collectedDiamond = 0;
    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.inGameCanvas.GetComponent<Canvas>().enabled = true;//open inGammeCanvas
        levelManager.player.OnPlayerDead += PlayerDead;
        levelManager.player.OnTriggerDiamond += GetDiamond; ;
    }

    public override void UpdateState()
    {
        levelManager.player.PlayerMove();
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            levelManager.player.transform.position = new Vector3
                                                   (levelManager.player.transform.position.x + Input.touches[0].deltaPosition.x * slideSpeed,
                                                    levelManager.player.transform.position.y,
                                                    levelManager.player.transform.position.z);
        }
    }
    public override void ExitState()
    {
        levelManager.inGameCanvas.GetComponent<Canvas>().enabled = false;//close inGammeCanvas
    }
    private void PlayerDead()
    {
        levelManager.TransitionToState(levelManager.failGame);
    }
    private void GetDiamond()
    {
        collectedDiamond++;
        levelManager.inGameCanvas.GetComponentInChildren<TMPro.TMP_Text>().text = collectedDiamond.ToString();
    }
}

