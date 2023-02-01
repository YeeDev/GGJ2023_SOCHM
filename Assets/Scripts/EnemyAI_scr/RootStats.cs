using UnityEngine;
using System;

public class RootStats : EnemyStats
{
    public event Action<Transform> onTakingDamage;

    MegaVeggie megaVeggie;

    private void Awake() => megaVeggie = GetComponentInParent<MegaVeggie>();

    public override void TakeDamage(GameObject other)
    {
        if (Time.time < damageTimer) { return; }

        damageTimer = Time.time + damageTick;
        health -= damageTaken;
        if (onTakingDamage != null) { onTakingDamage(other.transform.parent); }

        if (health <= 0)
        {
            megaVeggie.RemoveAndCheckRoots(gameObject);
            Destroy(gameObject);
        }
    }
}
