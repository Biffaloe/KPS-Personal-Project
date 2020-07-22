using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_State : State
{
    public Exit_State(New_Field_Menu system) : base(system)
    {
    }

    GameObject Transition;
    public void Start()
    {  Transition = GameObject.Find("LevelTransition"); }

    public override void Enter()
    {
        _system.Cursor.color = new Color(_system.Cursor.color.r, _system.Cursor.color.g, _system.Cursor.color.b, 1f);
        _system.anim.SetTrigger("Close All");

        Transition.GetComponent<Scene_Transition>().LoadNextScene(0);
        StateMachine.Inactive = true;
        _system.SetState(new Inactive_State(_system));
    }

}
