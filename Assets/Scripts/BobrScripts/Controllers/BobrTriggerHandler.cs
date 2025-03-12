using UnityEngine;

public class BobrTriggerHandler : MonoBehaviour
{
    private BobrStateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponentInParent<BobrStateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        stateMachine.TriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        stateMachine.TriggerExit(other);
    }
}
