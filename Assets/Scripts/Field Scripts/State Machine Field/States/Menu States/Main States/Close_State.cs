using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_State : State
{
    public Close_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        _system.Cursor.color = new Color(_system.Cursor.color.r, _system.Cursor.color.g, _system.Cursor.color.b, 0f);
        _system.anim.SetTrigger("Close All");

        StateMachine.Inactive = true;
        _system.SetState(new Inactive_State(_system));
    }
}
