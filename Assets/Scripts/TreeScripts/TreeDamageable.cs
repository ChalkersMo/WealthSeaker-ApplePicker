using UnityEngine;

public class TreeDamageable : MonoBehaviour, IDamageable
{
    public float MaxHealth { get { return maxHealth; } }
    [SerializeField] private float maxHealth;

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void OnHealthChanged()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

}
