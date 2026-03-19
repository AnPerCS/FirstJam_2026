using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    private float maxHealth;
    private float currentHealth;

    public event System.Action OnDamaged;
    public event System.Action OnDeath;


    public void SetMaxHealth(float _maxHealth)
    {
        maxHealth = _maxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damage)
    {   
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
       
        OnDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
