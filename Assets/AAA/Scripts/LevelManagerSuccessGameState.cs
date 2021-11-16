using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerSuccessGameState :LevelManagerBaseState
{
    LevelManager levelManager;

    public override void EnterToState(LevelManager levelManager)
    {

        this.levelManager = levelManager;
        if (levelManager.isItLastLevel)
        {
            levelManager.successGameCanvas.transform.GetChild(1).gameObject.SetActive(false);//If it is 3. level , disable next button.
            levelManager.successGameCanvas.GetComponent<Canvas>().enabled = true;//open sucessGameCanvas
        }
        else
        {
            levelManager.successGameCanvas.GetComponent<Canvas>().enabled = true;//open sucessGameCanvas
        }
        CalculateScore();
    }

    public override void UpdateState()
    {
        
    }
    public override void ExitState()
    {
        levelManager.successGameCanvas.GetComponent<Canvas>().enabled = false;//close sucessGameCanvas
    }
    private void CalculateScore()
    {
        int score = levelManager.player.collectedDiamond * levelManager.player.boats.Count * 10;

        levelManager.successGameCanvas.transform.GetChild(3).gameObject.GetComponent<TMPro.TMP_Text>().text = score.ToString();
    }

}
