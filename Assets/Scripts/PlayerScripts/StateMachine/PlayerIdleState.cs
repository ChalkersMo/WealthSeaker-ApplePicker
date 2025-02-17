
public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        stateMachine.controller.CheckInputs();
        if (stateMachine.controller.Axis.x != 0 || stateMachine.controller.Axis.y != 0)
            stateMachine.SwitchState(stateMachine.runState);
        if (stateMachine.controller.Jump())
            stateMachine.SwitchState(stateMachine.jumpingState);
    }

    public override void OnCollisionEnter(PlayerStateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(PlayerStateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(PlayerStateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

}
