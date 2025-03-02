public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        stateMachine.animController.Run();
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        stateMachine.controller.Run();
        if (stateMachine.controller.Axis.x == 0 && stateMachine.controller.Axis.y == 0)
            stateMachine.SwitchState(stateMachine.idleState);
        if (stateMachine.controller.Jump())
            stateMachine.SwitchState(stateMachine.jumpingState);
    }

    public override void OnTriggerStay(PlayerStateMachine stateMachine)
    {
        if(stateMachine.Other.CompareTag("Apple"))
            stateMachine.SwitchState(stateMachine.gatheringState);
    }
}
