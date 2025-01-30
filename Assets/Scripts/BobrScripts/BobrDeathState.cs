public class BobrDeathState : BobrBaseState
{
    public override void EnterState(BobrStateMachine stateMachine)
    {
        stateMachine.controller.Die();
        stateMachine.animationController.Death();
    }

    public override void OnCollisionEnter(BobrStateMachine stateMachine)
    {
    }

    public override void OnTriggerEnter(BobrStateMachine stateMachine)
    {
    }

    public override void OnTriggerExit(BobrStateMachine stateMachine)
    {
    }

    public override void UpdateState(BobrStateMachine stateMachine)
    {
    }
}
