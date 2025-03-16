public class PlayerGatheringState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        stateMachine.controller.PickUpItem();
    }

    public override void OnTriggerEnter(PlayerStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        if (stateMachine.animController.IsAnimationFinished("Gathering"))
        {           
            stateMachine.SwitchState(stateMachine.idleState);
        }
    }
}
