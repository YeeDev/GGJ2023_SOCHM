using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2f;
    [SerializeField] float strafeSpeed = 1f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Jump() => rb.velocity = transform.up.normalized * jumpForce;

    public void Rotate(float mouseAxis) => transform.Rotate(Vector3.up * mouseAxis * rotationSpeed * Time.deltaTime);

    public void MoveInDirection(float hAxis, float vAxis)
    {
        Vector3 moveDirection = transform.forward * vAxis * strafeSpeed * Time.deltaTime;
        moveDirection += transform.right * hAxis * walkSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + moveDirection);
    }

    public void Teleport(Vector3 teleportPoint)
    {
        transform.position = teleportPoint;
    }
}
