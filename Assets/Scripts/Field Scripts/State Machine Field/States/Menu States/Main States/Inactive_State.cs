using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inactive_State : State
{
    public Inactive_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StateMachine.Inactive = true;
    }

}
