public class PlayerJumpingState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        stateMachine.animController.Jump();
        stateMachine.controller.Jump();
    }
    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        stateMachine.controller.Run();
        if (stateMachine.controller.isGroundedAfterJump)
            stateMachine.SwitchState(stateMachine.idleState);

    }

    public override void OnTriggerStay(PlayerStateMachine stateMachine)
    {
    } 
}
