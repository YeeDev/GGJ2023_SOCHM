using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] string teleporterTag = "Teleporter";
    [SerializeField] string enemyTag = "Enemy";

    PlayerStats stats;
    PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        stats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(teleporterTag)) { controller.SetTeleporter = other.GetComponent<Teleporter>(); }
    }

    private void OnTriggerExit(Collider other) { if (other.CompareTag(teleporterTag)) { controller.RemoveTeleporter(); } }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(enemyTag)) { stats.TakeDamage(); }
    }
}
