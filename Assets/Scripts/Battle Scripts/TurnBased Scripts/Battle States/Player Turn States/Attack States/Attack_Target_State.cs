using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attack_Target_State : State_1
{
    public Attack_Target_State(TurnSystem TSystem) : base(TSystem)
    {
    }

    GameObject[] Enemies;

    public override void Enter()
    {
        base.Enter();

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        _system.IP_Cursor.transform.position = Enemies[0].transform.position;
        _system.selectedOption = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Handleinput()
    {
        base.Handleinput();

        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveUpList();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveDownList();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUpList();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDownList();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Select();
            }
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public void MoveUpList()
    {
        _system.selectedOption++;

        if (_system.selectedOption <= Enemies.Count() && _system.selectedOption >= 0)
        {
            _system.IP_Cursor.transform.position = Enemies[_system.selectedOption].transform.position;
        }
        else
        {
            _system.selectedOption = 0;
            _system.IP_Cursor.transform.position = Enemies[_system.selectedOption].transform.position;
        }
    }

    public void MoveDownList()
    {
        _system.selectedOption--;

        if (_system.selectedOption <= Enemies.Count() && _system.selectedOption >= 0)
        {
            _system.IP_Cursor.transform.position = Enemies[_system.selectedOption].transform.position;
        }
        else
        {
            _system.selectedOption = Enemies.Count();
            _system.IP_Cursor.transform.position = Enemies[_system.selectedOption].transform.position;
        }
    }

    public override void Select()
    {

    }
}
