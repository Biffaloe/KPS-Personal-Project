using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected readonly New_Field_Menu _system;
    public State(New_Field_Menu system)
    {  _system = system;  }

    public virtual void Enter()
    {

    }
    public virtual void Select()
    {

    }
    public virtual void Cancel()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Handleinput()
    {

    }
    public virtual void LogicUpdate()
    {

    }
}
