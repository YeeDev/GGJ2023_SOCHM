using UnityEngine;

public class Teleporter : MonoBehaviour
{
    bool isActive;

    public bool IsActive { get => isActive; }
    public Vector3 TeleportPoint { get => transform.GetChild(0).position; }

    public void Activate() => isActive = true;
}
