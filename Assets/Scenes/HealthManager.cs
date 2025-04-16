using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }
}
