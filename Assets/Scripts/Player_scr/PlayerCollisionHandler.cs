using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] string teleporterTag = "Teleporter";

    PlayerController controller;

    private void Awake() => controller = GetComponent<PlayerController>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(teleporterTag)) { controller.SetTeleporter = other.GetComponent<Teleporter>(); }
    }

    private void OnTriggerExit(Collider other) { if (other.CompareTag(teleporterTag)) { controller.RemoveTeleporter(); } }

}
