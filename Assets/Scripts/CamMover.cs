using UnityEngine;

public class CamMover : MonoBehaviour
{
    [SerializeField] Transform target;

    private void LateUpdate()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}