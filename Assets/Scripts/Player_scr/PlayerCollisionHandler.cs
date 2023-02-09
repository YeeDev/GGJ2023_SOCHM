using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] string teleporterTag = "Teleporter";
    [SerializeField] string endTag = "EndTeleporter";
    [SerializeField] string enemyTag = "Enemy";

    PlayerStats stats;

    private void Awake() => stats = GetComponent<PlayerStats>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(teleporterTag))
        {
            Teleporter teleporter = other.GetComponent<Teleporter>();
            if (teleporter.IsActive) { transform.position = teleporter.TeleportPoint; }
        }
        //Kids, do not hardcode this type of things, I'm only doing it because Jam reasons.
        else if (other.CompareTag(endTag))
        {
            Loader loader = FindObjectOfType<Loader>();
            loader.LoadScene(2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(enemyTag)) { stats.TakeDamage(); }
    }
}
