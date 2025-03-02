public class PlayerGatheringState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        stateMachine.animController.PickUp();
        stateMachine.controller.PickUpItem();
    }

    public override void OnTriggerStay(PlayerStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        if (stateMachine.animController.IsAnimEnded("Gathering"))
        {
            stateMachine.controller.OnAppleGatheringCollider();
            stateMachine.SwitchState(stateMachine.idleState);
        }
    }
}
