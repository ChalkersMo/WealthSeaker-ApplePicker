using UnityEngine;

public class TreeDamageable : MonoBehaviour, IDamageable
{
    public float MaxHealth { get { return maxHealth; } }
    [SerializeField] private float maxHealth;

    private float health;

    public void Die()
    {
        Destroy(gameObject, 5);
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
