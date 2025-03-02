using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float reloadTime;
    private PlayerMovementController playerMovementController;
    private Collider _collider;


    void Start()
    {
        playerMovementController = FindFirstObjectByType<PlayerMovementController>();
        _collider = GetComponent<Collider>();
    }

    public void DealAttack()
    {
        _collider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Damageable damageable))
        {
            _collider.enabled = false;
            damageable.TakeDamage(Damage * playerMovementController.playerStrength);
            Invoke(nameof(EndOfAttack), reloadTime);
        }
    }

    private void EndOfAttack()
    {
        if (_collider.enabled)
        {
           _collider.enabled = false;
        }
    }
}
