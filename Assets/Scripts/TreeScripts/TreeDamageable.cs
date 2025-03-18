using UnityEngine;

public class TreeDamageable : MonoBehaviour, IDamageable
{
    public float MaxHealth { get { return maxHealth; } }
    public int Rank { get { return rank; } }

    [SerializeField] private float maxHealth;
    [SerializeField] private int rank;

    private float health;

    public void Die()
    {
        Destroy(gameObject, 5);
    }

    public void OnHealthChanged()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, MaxHealth);

        OnHealthChanged();

        if (health == 0)
            Die();  
    }

}
