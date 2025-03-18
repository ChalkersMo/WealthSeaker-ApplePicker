using UnityEngine;

public class AxeDamageDealer : DamageDealer
{
    [SerializeField] private int Durability = 3;

    private int currentDurability;
    private int durabilityAverage;
    private bool isCracked = false;

    private AttacksController attackController;
    private AxeIndicator axeIndicator;

    protected override void Awake()
    {
        base.Awake();
        attackController = FindFirstObjectByType<AttacksController>();
        axeIndicator = FindFirstObjectByType<AxeIndicator>();
    }

    private void OnEnable()
    {
        if (attackController.currentDamageDealer != this)
            gameObject.SetActive(false);
        else
        {
            currentDurability = Durability;
            durabilityAverage = (Durability + currentDurability) / 2;
            isCracked = false;
            axeIndicator.RenewAxe();
        }       
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            _collider.enabled = false;
            damageable.TakeDamage(Damage * playerMovementController.playerStrength);
            currentDurability--;
            if (currentDurability <= 0)
                Broke();
            else if (currentDurability <= durabilityAverage && !isCracked)
                Crack();
        }
    }

    public override void DealAttack()
    {
        base.DealAttack();
    }

    private void Crack()
    {
        isCracked = true;
        axeIndicator.CrackAxe();
    }
    private void Broke()
    {
        axeIndicator.DestroyAxe();
        attackController.ChangeDamageDealer("Hand");
    }
}
