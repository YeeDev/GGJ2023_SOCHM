using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] string flameTag = "Flame";
    [SerializeField] float damageTick = 0.1f;
    [SerializeField] int damageTaken = 1;
    [SerializeField] int health = 100;

    float damageTimer;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(flameTag) && Time.time > damageTimer)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        damageTimer = Time.time + damageTick;
        health -= damageTaken;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
