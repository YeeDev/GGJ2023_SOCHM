using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] protected int health = 50;
    [SerializeField] protected float damageTick = 0.1f;
    [SerializeField] protected int damageTaken = 1;

    bool isInvulnerable;
    protected float damageTimer;

    public void MakeInvulnerable() { isInvulnerable = true; }
    public void MakeVulnerable() { isInvulnerable = false; }

    public virtual void TakeDamage()
    {
        if (Time.time < damageTimer || isInvulnerable) { return; }

        damageTimer = Time.time + damageTick;
        health -= damageTaken;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
