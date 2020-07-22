using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State_1
{
    protected readonly TurnSystem _system;
    public State_1(TurnSystem TSystem)
    { _system = TSystem; }

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Select()
    {

    }
    public virtual void Cancel()
    {

    }
    public virtual void Handleinput()
    {

    }
    public virtual void LogicUpdate()
    {

    }
}
