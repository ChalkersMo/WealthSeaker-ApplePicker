using UnityEngine;

public class PunchDamageDealer : DamageDealer
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter(Collider other)
    {
       base.OnTriggerEnter(other);
    }

    public override void DealAttack()
    {
        base.DealAttack();
    }
}
