using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_State : State
{
    public Main_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        _system.Cursor.transform.position = _system.option1.transform.position;
        _system.selectedOption = 1;
    }

    public override void Handleinput()
    {
        base.Handleinput();
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Select();
        }
    }

    public void MoveUp()
    {
        _system.selectedOption -= 1;
        if (_system.selectedOption < 1)
        {
            _system.selectedOption = _system.numberOfOptions;
        }
    }

    public void MoveDown()
    {
        _system.selectedOption += 1;
        if (_system.selectedOption > _system.numberOfOptions)
        {
            _system.selectedOption = 1;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        switch (_system.selectedOption)
        {
            case 1:
                _system.Cursor.transform.position = _system.option1.transform.position;
                break;
            case 2:
                _system.Cursor.transform.position = _system.option2.transform.position;
                break;
            case 3:
                _system.Cursor.transform.position = _system.option3.transform.position;
                break;
            case 4:
                _system.Cursor.transform.position = _system.option4.transform.position;
                break;
        }
    }

    public override void Select()
    {
        base.Select();

        switch (_system.selectedOption)
        {
            case 1:
                _system.Initialize(new Inventory_State(_system));
                break;
            case 2:
                _system.Initialize(new SelectEquip_State(_system));
                break;
            case 3:
                _system.Initialize(new SelectStat_State(_system));
                break;
            case 4:
                _system.Initialize(new Exit_State(_system));
                break;
        }
    }

    public override void Cancel()
    {
        base.Cancel();
        _system.SetState(new Close_State(_system));
    }
}
