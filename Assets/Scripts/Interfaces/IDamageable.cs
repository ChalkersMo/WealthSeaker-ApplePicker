using UnityEngine;

public interface IDamageable
{
    [SerializeField, Range(0.1f, 1000f)] float MaxHealth { get;}
    [SerializeField, Range(0.1f, 1000f)] int Rank { get; }

    void TakeDamage(float damage);
    void OnHealthChanged();
    void Die();
}
