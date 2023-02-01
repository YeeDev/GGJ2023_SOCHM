using UnityEngine;

public class MegaVeggieStats : EnemyStats
{
    [SerializeField] Teleporter teleporterToActivate;

    public override void TakeDamage()
    {
        if (Time.time < damageTimer) { return; }

        damageTimer = Time.time + damageTick;
        health -= damageTaken;

        if (health <= 0)
        {
            if (teleporterToActivate != null) { teleporterToActivate.Activate(); }
            Destroy(gameObject);
        }
    }
}
