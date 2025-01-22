using UnityEngine;

public class BobrStateMachine : MonoBehaviour
{
    private BobrBaseState currentState;

    public BobrSpawnState BobrSpawnState = new();
    public BobrSeekingState BobrSeekingState = new();
    public BobrRunAwayState BobrRunAwayState = new();
    public BobrHumilityState BobrHumilityState = new();
    public BobrDeathState BobrDeathState = new();

    private void Start()
    {
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BobrBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
