using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Begin_State : State
{
    public Begin_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        _system.Cursor.color = new Color(_system.Cursor.color.r, _system.Cursor.color.g, _system.Cursor.color.b, 1f);
        _system.anim.SetTrigger("Open Menu");

        StateMachine.Inactive = false;
        _system.SetState(new Main_State(_system));
    }
}
