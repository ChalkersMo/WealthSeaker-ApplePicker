using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private PlayerStateMachine _playerState;

    void Start()
    {
        _playerState = GetComponentInParent<PlayerStateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerState.Entertrigger(other);
    }

    private void OnTriggerStay(Collider other)
    {
        _playerState.StayInTrigger(other);
    }
}
