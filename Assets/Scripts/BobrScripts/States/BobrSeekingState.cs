public class BobrSeekingState : BobrBaseState
{
    public override void EnterState(BobrStateMachine stateMachine)
    {
        stateMachine.controller.IsRunningAway = false;
        stateMachine.animationController.RunAnimSpeed(stateMachine.animationController.bobrRunAnimSpeed);
        stateMachine.animationController.Run();
        stateMachine.controller.OnCollider();
        stateMachine.controller.SeekApples();
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
        if (stateMachine.other.CompareTag("Player"))
        {
            stateMachine.SwitchState(stateMachine.BobrRunAwayState);
        }
    }

    public override void OnTriggerExit(BobrStateMachine stateMachine)
    {      
    }

    public override void UpdateState(BobrStateMachine stateMachine)
    {
        if(!stateMachine.controller.IsRunningAway)
            stateMachine.controller.SeekApples();
    }
}
