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
    private float planeXSize;
    private float boatXSize;

    public override void EnterToState(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        levelManager.preGameCanvas.GetComponent<Canvas>().enabled = true;//Open preGameCanvas
        planeXSize = GameObject.FindGameObjectWithTag("Plane").GetComponent<MeshFilter>().mesh.bounds.size.x;
        boatXSize = GameObject.FindGameObjectWithTag("Boat").GetComponent<MeshFilter>().mesh.bounds.size.x;
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

            CheckBounds();

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

    private void CheckBounds()
    {
        if (tempPlayerPosition.x > planeXSize / 2 - boatXSize / 2)
            tempPlayerPosition.x = planeXSize / 2 - boatXSize / 2;
        else if (tempPlayerPosition.x < -(planeXSize / 2 - boatXSize / 2))
            tempPlayerPosition.x = -(planeXSize / 2 - boatXSize / 2);
    }

}
