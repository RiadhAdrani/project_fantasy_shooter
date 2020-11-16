using UnityEngine;

public class EnemyOld : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        // reduce health by "damage" amount
        health -= damage;

        if (health <= 0) Die();
    }

    private void Die()
    {
        // if the health goes below 0
        // destroy the object
        Destroy(gameObject);
    }
}
