using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_1 : MonoBehaviour
{
    protected State_1 CurrentState;
    public bool IsBattleOver = false;

    public void SetState(State_1 state)
    {
        CurrentState = state;
    }

    public void Initialize(State_1 startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State_1 newState)
    {
        CurrentState.Exit();

        CurrentState = newState;

        CurrentState.Enter();
    }
}
