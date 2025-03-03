using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float reloadTime;
    [SerializeField] private string animationName;

    private PlayerAnimationController playerAnimController;
    private PlayerMovementController playerMovementController;
    private Collider _collider;


    void Start()
    {
        playerMovementController = FindFirstObjectByType<PlayerMovementController>();
        playerAnimController = FindFirstObjectByType<PlayerAnimationController>();
        _collider = GetComponent<Collider>();
    }

    public void DealAttack()
    {
        _collider.enabled = true;
        playerAnimController.PlayByName(
            animationName, new SHG.AnimatorCoder.AnimationData(SHG.AnimatorCoder.Animations.RESET), 0.2f, 1);
        Invoke(nameof(EndOfAttack), reloadTime);
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
