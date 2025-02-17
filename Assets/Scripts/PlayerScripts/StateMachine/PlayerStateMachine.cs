using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [HideInInspector] public Collision Collision;
    [HideInInspector] public Collider Other;

    public PlayerAnimationController animController;
    public PlayerMovementController controller;

    public PlayerIdleState idleState = new();
    public PlayerRunState runState = new();
    public PlayerJumpingState jumpingState = new();
    public PlayerGatheringState gatheringState = new();

    private PlayerBaseState currentState;

    private void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collision = collision;
        currentState.OnCollisionEnter(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Other = other;
        currentState.OnTriggerEnter(this);
    }

    private void OnTriggerExit(Collider other)
    {
        Other = other;
        currentState.OnTriggerExit(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
