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
    private PlayerBaseState expectedState;

    private bool isReadyTriggerReady = true;

    private void Start()
    {
        attacksController = FindFirstObjectByType<AttacksController>();
        animController = GetComponent<PlayerAnimationController>();
        controller = GetComponent<PlayerMovementController>();
        currentState = idleState;
        expectedState = currentState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void Entertrigger(Collider other)
    {
        if(isReadyTriggerReady)
            StartCoroutine(OnStay());
        IEnumerator OnStay()
        {
            isReadyTriggerReady = false;
            yield return new WaitForSeconds(1f);

            Other = other;
            if (currentState != expectedState)
                currentState = expectedState;

            currentState.OnTriggerStay(this);
            isReadyTriggerReady = true;
        }   
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        expectedState = state;
        state.EnterState(this);
    }
}
