using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Turn_State : State_1
{
    public End_Turn_State(TurnSystem TSystem) : base(TSystem)
    {
    }

    public override void Enter()
    {
        _system.IsTurnOver = true;
    }

    public override void Exit()
    {
        _system.IsTurnOver = false;
    }
}
