using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private PlayerStateMachine _playerState;

    void Start()
    {
        _playerState = GetComponentInParent<PlayerStateMachine>();
    }

    private void OnTriggerStay(Collider other)
    {
        _playerState.Entertrigger(other);
    }
}
