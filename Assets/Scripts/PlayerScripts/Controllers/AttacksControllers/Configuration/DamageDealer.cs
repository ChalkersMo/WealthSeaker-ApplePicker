using UnityEngine;

public abstract class DamageDealer : MonoBehaviour
{
    [SerializeField] protected int Rank;
    [SerializeField] protected float Damage;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected string animationName;

    protected PlayerAnimationController playerAnimController;
    protected PlayerMovementController playerMovementController;
    protected Collider _collider;

    protected bool isAttackReady = true;


    protected virtual void Start()
    {
        playerMovementController = FindFirstObjectByType<PlayerMovementController>();
        playerAnimController = FindFirstObjectByType<PlayerAnimationController>();
        _collider = GetComponent<Collider>();
    }

    public virtual void DealAttack()
    {
        if (isAttackReady)
        {
            isAttackReady = false;
            _collider.enabled = true;
            playerAnimController.PlayByName(
                animationName, new SHG.AnimatorCoder.AnimationData(SHG.AnimatorCoder.Animations.RESET), 0.2f, 1);
            Invoke(nameof(EndOfAttack), reloadTime);
        }    
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            _collider.enabled = false;
            if(damageable.Rank > Rank)
                damageable.TakeDamage(Damage / playerMovementController.playerStrength / 2);
            else
                damageable.TakeDamage(Damage * playerMovementController.playerStrength);
        }
    }

    protected virtual void EndOfAttack()
    {
        if (_collider.enabled)
        {
           _collider.enabled = false;
        }
        isAttackReady = true;
    }
}
