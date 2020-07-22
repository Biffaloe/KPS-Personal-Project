using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State CurrentState;
    public static bool Inactive;

    public void SetState(State state)
    {
        CurrentState = state;
    }

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
    }
}
