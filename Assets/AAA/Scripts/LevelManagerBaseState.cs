using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManagerBaseState
{
    public abstract void EnterToState(LevelManager levelManager);
    public abstract void UpdateState();

    public abstract void ExitState();
   
}
