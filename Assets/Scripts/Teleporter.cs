using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform enemyTiedTo;

    public bool IsActive { get => enemyTiedTo == null; }
    public Vector3 TeleportPoint { get => transform.GetChild(0).position; }
}
