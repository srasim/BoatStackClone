using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerInGameState : LevelManagerBaseState
{
    float swipeSpeed = 0.01f;
    LevelManager levelManager;
    public Vector3 lastMousePosition;
    Vector3 tempPlayerPosition;
    Vector3 swipe;
    private float planeXSize;
    private float boatXSize;


    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.inGameCanvas.GetComponent<Canvas>().enabled = true;//open inGammeCanvas
        levelManager.player.OnPlayerDead += PlayerDead;
        levelManager.player.OnTriggerDiamond += GetDiamond; 
        levelManager.player.OnFinish += PlayerOnFinish;
        planeXSize = GameObject.FindGameObjectWithTag("Plane").GetComponent<MeshFilter>().mesh.bounds.size.x;
        boatXSize = GameObject.FindGameObjectWithTag("Boat").GetComponent<MeshFilter>().mesh.bounds.size.x;
    }

    public override void UpdateState()
    {
        levelManager.player.PlayerMove();
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            swipe = Input.mousePosition - lastMousePosition;

            tempPlayerPosition = levelManager.player.transform.position;
            tempPlayerPosition.x += swipe.x*swipeSpeed;

            CheckBounds();

            levelManager.player.transform.position = tempPlayerPosition;

            lastMousePosition = Input.mousePosition;
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
        levelManager.player.collectedDiamond++;
        levelManager.inGameCanvas.GetComponentInChildren<TMPro.TMP_Text>().text = levelManager.player.collectedDiamond .ToString();
    }

    private void PlayerOnFinish()
    {
        levelManager.TransitionToState(levelManager.successGame);
    }
    private void CheckBounds()
    {
        if (tempPlayerPosition.x > planeXSize / 2 - boatXSize / 2)
            tempPlayerPosition.x = planeXSize / 2 - boatXSize / 2;
        else if (tempPlayerPosition.x < -(planeXSize / 2 - boatXSize / 2))
            tempPlayerPosition.x = -(planeXSize / 2 - boatXSize / 2);
    }
}

