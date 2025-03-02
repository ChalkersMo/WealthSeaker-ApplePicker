using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        stateMachine.animController.Idle();
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        stateMachine.controller.CheckInputs();
        if (stateMachine.controller.Axis.x != 0 || stateMachine.controller.Axis.y != 0)
            stateMachine.SwitchState(stateMachine.runState);
        if (stateMachine.controller.Jump())
            stateMachine.SwitchState(stateMachine.jumpingState);
        if (Input.GetMouseButtonDown(0))
        {
            stateMachine.attacksController.Attack();
            stateMachine.animController.Punch();
            Debug.Log("Punch");
        }
            
    }

    public override void OnTriggerStay(PlayerStateMachine stateMachine)
    {
        if (stateMachine.Other.CompareTag("Apple"))
        {
            stateMachine.SwitchState(stateMachine.gatheringState);
        }
    }

}
