using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Select_Command_State : State_1
{
    public Select_Command_State(TurnSystem Tsystem) : base(Tsystem)
    {
    }

    private int action;
    public override void Enter()
    {
        _system.ActionsMenu.SetActive(true);
    }
    public override void Exit()
    {
        _system.ActionsMenu.SetActive(false);
    }

    public override void Handleinput()
    {
        base.Handleinput();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            action = 1;
            Select();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            action = 2;
            Select();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            action = 3;
            Select();
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    public override void Select()
    {
        switch (action)
        {
            case 1:
                _system.ChangeState(new Attack_Target_State(_system));
                break;
            case 2:
                _system.ChangeState(new Item_Select_State(_system));
                break;
            case 3:
                _system.ChangeState(new Run_State(_system));
                break;
        }
    }
}