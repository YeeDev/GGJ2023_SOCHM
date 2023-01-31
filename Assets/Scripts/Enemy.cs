using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.5f;
    [SerializeField] int health = 50;
    [SerializeField] float damageTick = 0.1f;
    [SerializeField] int damageTaken = 1;

    float damageTimer;
    Rigidbody rb;
    Transform target;

    public void SetTarget(Transform possibleTarget) { if (target == null) { target = possibleTarget; } }
    public void RemoveTarget(Transform targetToCheck) { if (target == targetToCheck) { target = null; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Vector3 step = CalculateStep(direction);

            rb.MovePosition(transform.position + step);
            transform.LookAt(target, transform.up);
        }
    }

    private Vector3 CalculateStep(Vector3 direction)
    {
        Vector3 step;
        Ray rayWilliamJohnson = new Ray(transform.position, direction);
        Physics.Raycast(rayWilliamJohnson, out RaycastHit hit, 1);

        if (hit.transform != target)
        {
            Vector3 projectedVector = Vector3.ProjectOnPlane(direction, hit.normal);
            step = projectedVector.normalized * Time.deltaTime * moveSpeed;
        }
        else
        {
            step = direction.normalized * Time.deltaTime * moveSpeed;
        }

        return step;
    }

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
