using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] float damageTick = 0.1f;
    [SerializeField] int damageTaken = 1;

    float damageTimer;

    public void TakeDamage()
    {
        if (Time.time < damageTimer) { return; }

        damageTimer = Time.time + damageTick;
        health -= damageTaken;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
