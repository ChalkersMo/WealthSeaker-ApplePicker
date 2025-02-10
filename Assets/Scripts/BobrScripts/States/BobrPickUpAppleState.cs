

public class BobrPickUpAppleState : BobrBaseState
{
    public override void EnterState(BobrStateMachine stateMachine)
    {
        stateMachine.controller.PickUpApple(stateMachine.collision.gameObject);
        stateMachine.animationController.PickUp();
    }

    public override void OnCollisionEnter(BobrStateMachine stateMachine)
    {
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
        if (stateMachine.animationController.IsAnimEnded("PickingUp"))
        {
            stateMachine.SwitchState(stateMachine.BobrSeekingState);
        }
    }
}
