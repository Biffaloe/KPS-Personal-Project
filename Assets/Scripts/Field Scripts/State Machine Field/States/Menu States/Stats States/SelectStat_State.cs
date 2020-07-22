using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStat_State : State
{
    public SelectStat_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        _system.IP_Cursor.transform.position = _system.PM_1.transform.position;
    }

    public override void Handleinput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Select();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Cancel();
        }
    }

    public void MoveLeft()
    {
        _system.currentOption -= 1;
        if (_system.currentOption < 1)
        {
            _system.currentOption = 2;
        }
    }

    public void MoveRight()
    {
        _system.currentOption += 1;
        if (_system.currentOption > 2)
        {
            _system.currentOption = 1;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        switch (_system.currentOption)
        {
            case 1:
                _system.IP_Cursor.transform.position = _system.PM_1.transform.position;
                break;
            case 2:
                _system.IP_Cursor.transform.position = _system.PM_2.transform.position;
                break;
        }
    }

    public override void Select()
    {
        switch (_system.currentOption)
        {
            case 1:
                _system.Initialize(new Status_State(_system));
                break;
            case 2:
                _system.Initialize(new Status_State(_system));
                break;
        }
    }

    public override void Cancel()
    {
        base.Cancel();

        _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
        _system.SetState(new Main_State(_system));
    }
}
