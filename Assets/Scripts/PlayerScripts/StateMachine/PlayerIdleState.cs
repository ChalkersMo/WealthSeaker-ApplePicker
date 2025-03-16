using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine stateMachine)
    {
        stateMachine.animController.Idle();
        stateMachine.controller.OnAppleGatheringCollider();
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
