public class BobrSeekingState : BobrBaseState
{
    public override void EnterState(BobrStateMachine stateMachine)
    {
        stateMachine.controller.OnAgent();
        stateMachine.animationController.RunAnimSpeed(stateMachine.animationController.bobrRunAnimSpeed);
        stateMachine.animationController.Run();
        stateMachine.controller.OnCollider();
        stateMachine.controller.SeekApples();
    }

    public override void OnCollisionEnter(BobrStateMachine stateMachine)
    {
        if (stateMachine.collision.transform.TryGetComponent<ApplePickupable>(out ApplePickupable pickupable))
        {
            pickupable.BobrPickUp();
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

    public override void UpdateState(BobrStateMachine stateMachine)
    {
        stateMachine.controller.SeekApples();
    }
}
