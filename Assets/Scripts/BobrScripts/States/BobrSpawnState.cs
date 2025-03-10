public class BobrSpawnState : BobrBaseState
{
    public override void EnterState(BobrStateMachine stateMachine)
    {
        stateMachine.animationController.StandUpSpeed(1);
        stateMachine.animationController.StandUp();
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
        if (stateMachine.collision.transform.CompareTag("Apple"))
        {
            stateMachine.SwitchState(stateMachine.BobrPickUpAppleState);
        }
    }

    public override void OnTriggerEnter(BobrStateMachine stateMachine)
    {
        if (stateMachine.other.CompareTag("Player") && stateMachine.controller.IsTimid)
        {
            stateMachine.SwitchState(stateMachine.BobrRunAwayState);
        }
    }

    public override void OnTriggerExit(BobrStateMachine stateMachine)
    {
    }
}
