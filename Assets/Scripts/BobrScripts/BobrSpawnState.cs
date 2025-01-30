public class BobrSpawnState : BobrBaseState
{
    public override void EnterState(BobrStateMachine stateMachine)
    {
        stateMachine.animationController.StandUpSpeed(1);
    }

    public override void UpdateState(BobrStateMachine stateMachine)
    {
        if(stateMachine.animationController.IsAnimEnded("StandingUp"))
        {
            stateMachine.SwitchState(stateMachine.BobrSeekingState);
        }
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
}
