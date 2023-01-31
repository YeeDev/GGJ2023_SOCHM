using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootStats : EnemyStats
{
    MegaVeggie megaVeggie;

    private void Awake() => megaVeggie = GetComponentInParent<MegaVeggie>();

    public override void TakeDamage()
    {
        if (Time.time < damageTimer) { return; }

        damageTimer = Time.time + damageTick;
        health -= damageTaken;

        if (health <= 0)
        {
            megaVeggie.RemoveAndCheckRoots(gameObject);
            Destroy(gameObject);
        }
    }
}
