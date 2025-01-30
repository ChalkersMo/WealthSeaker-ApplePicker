public abstract class BobrBaseState
{
    public abstract void EnterState(BobrStateMachine stateMachine);

    public abstract void UpdateState(BobrStateMachine stateMachine);

    public abstract void OnCollisionEnter(BobrStateMachine stateMachine);

    public abstract void OnTriggerEnter(BobrStateMachine stateMachine);

    public abstract void OnTriggerExit(BobrStateMachine stateMachine);
}
