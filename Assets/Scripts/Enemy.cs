using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] string flameTag = "Flame";
    [SerializeField] string enemyTag = "Player";
    [SerializeField] float damageTick = 0.1f;
    [SerializeField] int damageTaken = 1;
    [SerializeField] int health = 100;
    [SerializeField] float moveSpeed = 2f;

    float damageTimer;
    Rigidbody rb;
    [SerializeField] Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    [SerializeField] float rayLength;

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Vector3 step = direction;

            Ray rayWilliamJohnson = new Ray(transform.position, direction);
            Physics.Raycast(rayWilliamJohnson, out RaycastHit hit, rayLength);

            if (hit.transform != target)
            {
                Vector3 projectedVector = Vector3.ProjectOnPlane(direction, hit.normal);
                step = projectedVector.normalized * Time.deltaTime * moveSpeed;
            }
            else
            {
                step = direction.normalized * Time.deltaTime * moveSpeed; 
            }

            rb.MovePosition(transform.position + step);
            transform.LookAt(target, transform.up);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(enemyTag) && target == null) { target = other.transform; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target) { target = null; }
    }

    private void OnParticleCollision(GameObject other)
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
