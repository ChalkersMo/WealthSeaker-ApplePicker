using System.Collections;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [HideInInspector] public Collision Collision;
    [HideInInspector] public Collider Other;

    [HideInInspector] public AttacksController attacksController;
    [HideInInspector] public PlayerAnimationController animController;
    [HideInInspector] public PlayerMovementController controller;

    public PlayerIdleState idleState = new();
    public PlayerRunState runState = new();
    public PlayerJumpingState jumpingState = new();
    public PlayerGatheringState gatheringState = new();

    private PlayerBaseState currentState;

    private void Start()
    {
        attacksController = FindFirstObjectByType<AttacksController>();
        animController = GetComponent<PlayerAnimationController>();
        controller = GetComponent<PlayerMovementController>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void Entertrigger(Collider other)
    {
        Other = other;
        currentState.OnTriggerEnter(this);
    }

    public void StayInTrigger(Collider other)
    {
        Other = other;
        currentState.OnTriggerStay(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
