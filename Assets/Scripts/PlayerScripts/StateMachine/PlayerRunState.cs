using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.SwitchState(stateMachine.jumpingState);
        if (Input.GetMouseButtonDown(0))
        {
            stateMachine.attacksController.Attack();
            stateMachine.animController.Punch();
        }
    }

    public override void OnTriggerEnter(PlayerStateMachine stateMachine)
    {
        if (stateMachine.Other.TryGetComponent<IPickupable>(out IPickupable pickupable))
        {
            stateMachine.animController.PickUp();
            pickupable.PickUp();
            stateMachine.SwitchState(stateMachine.gatheringState);
        }
    }
}
