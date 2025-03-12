using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BobrStateMachine : MonoBehaviour
{
    public BobrBaseState currentState;

    public BobrSpawnState BobrSpawnState = new();
    public BobrSeekingState BobrSeekingState = new();
    public BobrPickUpAppleState BobrPickUpAppleState = new();
    public BobrRunAwayState BobrRunAwayState = new();
    public BobrHumilityState BobrHumilityState = new();
    public BobrDeathState BobrDeathState = new();

    [HideInInspector] public BobrAnimationController animationController;
    [HideInInspector] public BobrController controller;
    [HideInInspector] public BobrDamageable hpController;

    [HideInInspector] public Collision collision;
    [HideInInspector] public Collider other;

    private void Awake()
    {
        animationController = GetComponent<BobrAnimationController>();
        controller = GetComponent<BobrController>();
        hpController = GetComponent<BobrDamageable>();
    }
    private void OnEnable()
    {
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

    public void TriggerEnter(Collider other)
    {
        this.other = other;
        currentState.OnTriggerEnter(this);
    }

    public void TriggerExit(Collider other)
    {
        this.other = other;
        currentState.OnTriggerExit(this);
    }

    public void SwitchState(BobrBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
