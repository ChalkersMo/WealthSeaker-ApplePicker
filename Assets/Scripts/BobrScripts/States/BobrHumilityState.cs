public class BobrHumilityState : BobrBaseState
{
    public override void EnterState(BobrStateMachine stateMachine)
    {
        stateMachine.controller.Wait();
    }

    public override void OnCollisionEnter(BobrStateMachine stateMachine)
    {
    }

    public override void OnTriggerEnter(BobrStateMachine stateMachine)
    {
    }

    public override void OnTriggerExit(BobrStateMachine stateMachine)
    {
        if (stateMachine.other.CompareTag("Player"))
        {
            stateMachine.SwitchState(stateMachine.BobrSeekingState);
        }
    }

    public override void UpdateState(BobrStateMachine stateMachine)
    {
    }
}
