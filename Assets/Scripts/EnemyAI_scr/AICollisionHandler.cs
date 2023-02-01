using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class AICollisionHandler : MonoBehaviour
{
    [SerializeField] string damagerTag = "Flame";

    EnemyStats stats;

    protected virtual void Awake() => stats = GetComponent<EnemyStats>();

    private void OnParticleCollision(GameObject other) { if (other.CompareTag(damagerTag)) { stats.TakeDamage(other); } }
}
