using UnityEngine;

public class BobrStateMachine : MonoBehaviour
{
    private BobrBaseState currentState;

    public BobrSpawnState BobrSpawnState = new();
    public BobrSeekingState BobrSeekingState = new();
    public BobrPickUpAppleState BobrPickUpAppleState = new();
    public BobrRunAwayState BobrRunAwayState = new();
    public BobrHumilityState BobrHumilityState = new();
    public BobrDeathState BobrDeathState = new();

    public BobrAnimationController animationController;
    public BobrController controller;

    public Collision collision;
    public Collider other;

    private void Start()
    {
        animationController = GetComponent<BobrAnimationController>();
        controller = GetComponent<BobrController>();

        currentState = BobrSpawnState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.collision = collision;
        currentState.OnCollisionEnter(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.other = other;
        currentState.OnTriggerEnter(this);
    }

    private void OnTriggerExit(Collider other)
    {
        this.other = other;
    }

    public void SwitchState(BobrBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
