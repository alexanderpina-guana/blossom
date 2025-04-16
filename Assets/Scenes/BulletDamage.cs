using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        HealthManager HealthManagerScript = other.GetComponent<HealthManager>();
        if (HealthManagerScript != null)
        {
            HealthManagerScript.takeDamage(damage);
        }
    }
}
