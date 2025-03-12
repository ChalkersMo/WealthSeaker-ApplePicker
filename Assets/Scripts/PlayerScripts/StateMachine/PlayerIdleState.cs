using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        stateMachine.animController.Idle();
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        stateMachine.controller.Run();
        if (stateMachine.controller.Axis.x != 0 || stateMachine.controller.Axis.y != 0)
            stateMachine.SwitchState(stateMachine.runState);
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.SwitchState(stateMachine.jumpingState);
        if (Input.GetMouseButtonDown(0))
            stateMachine.attacksController.Attack();
            
    }

    public override void OnTriggerStay(PlayerStateMachine stateMachine)
    {
        if (stateMachine.Other.CompareTag("Apple"))
        {
            stateMachine.SwitchState(stateMachine.gatheringState);
        }
    }

}
