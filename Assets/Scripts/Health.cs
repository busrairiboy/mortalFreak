using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        ShowHealth(); 
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(float amount)
    {
        currentHealth = Mathf.Clamp(amount, 0, maxHealth);
        ShowHealth(); 
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        ShowHealth(); 
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0); 
        ShowHealth(); 

        if (currentHealth <= 0)
        {
            Debug.Log("Karakter öldü.");
            Die();
        }
    }

    public bool IsFullHealth()
    {
        return currentHealth >= maxHealth;
    }

    public void ShowHealth()
    {
        Debug.Log("Kalan can: " + currentHealth);
    }

    private void Die()
    {
      
        Destroy(gameObject);
    }
}
