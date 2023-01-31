using UnityEngine;

public class AICollisionHandler : MonoBehaviour
{
    [SerializeField] string targetTag;
    [SerializeField] string damagerTag;

    Enemy enemy;

    private void Awake() { enemy = GetComponent<Enemy>(); }

    private void OnTriggerStay(Collider other) { if (other.CompareTag(targetTag)) { enemy.SetTarget(other.transform); } }
    private void OnTriggerExit(Collider other) { enemy.RemoveTarget(other.transform); }

    private void OnParticleCollision(GameObject other) { if (other.CompareTag(damagerTag)) { enemy.TakeDamage(); } }
}
