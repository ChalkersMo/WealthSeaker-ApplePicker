using UnityEngine;

public abstract class BobrBaseState : MonoBehaviour
{
    public abstract void EnterState(BobrStateMachine stateMachine);

    public abstract void UpdateState(BobrStateMachine stateMachine);

    public abstract void ExitStateState(BobrStateMachine stateMachine);
}
