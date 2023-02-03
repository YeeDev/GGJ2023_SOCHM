using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVeggieStats : EnemyStats
{
    [SerializeField] string damageParameter = "Damage";

    Animator anm;

    private void Awake() => anm = GetComponent<Animator>();

    public override void TakeDamage(GameObject other)
    {
        if (Time.time < damageTimer) { return; }

        anm.SetTrigger(damageParameter);
        damageTimer = Time.time + damageTick;
        health -= damageTaken;

        if (health <= 0) { Destroy(gameObject); }
    }
}