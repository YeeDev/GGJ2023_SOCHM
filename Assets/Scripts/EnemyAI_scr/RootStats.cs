using UnityEngine;
using System;

public class RootStats : EnemyStats
{
    public event Action<Transform> onTakingDamage;

    [SerializeField] string damageParameter = "TakingDamage"; 

    Animator anm;
    MegaVeggie megaVeggie;

    private void Awake()
    {
        anm = GetComponentInChildren<Animator>();
        megaVeggie = GetComponentInParent<MegaVeggie>();
    }

    public override void TakeDamage(GameObject other)
    {
        if (Time.time < damageTimer) { return; }

        anm.SetTrigger(damageParameter);
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
