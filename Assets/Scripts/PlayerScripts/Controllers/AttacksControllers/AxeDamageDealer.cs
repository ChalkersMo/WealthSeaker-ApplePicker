using UnityEngine;

public class AxeDamageDealer : DamageDealer
{
    [SerializeField] private int Durability = 3;

    private int currentDurability;

    private AttacksController attackController;

    protected override void Start()
    {
        base.Start();
        attackController = FindFirstObjectByType<AttacksController>();
    }

    private void OnEnable()
    {
        currentDurability = Durability;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            _collider.enabled = false;
            damageable.TakeDamage(Damage * playerMovementController.playerStrength);
            currentDurability--;
            if (currentDurability == 0)
                Broke();
        }
    }

    public override void DealAttack()
    {
        base.DealAttack();
    }

    private void Broke()
    {
        attackController.ChangeDamageDealer("Hand");
    }
}
