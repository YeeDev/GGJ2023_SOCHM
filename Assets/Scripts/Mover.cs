using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2f;
    [SerializeField] float strafeSpeed = 1f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] string teleporterTag = "Teleporter";
    [SerializeField] float teleportTime = 3f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] ParticleSystem flame;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float checkerRadius;
    [SerializeField] Transform groundChecker;

    bool isGrounded;
    Teleporter teleporter;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Debug.Log(isGrounded);

        if (Input.GetButtonDown("Teleport") && teleporter != null && teleporter.IsActive)
        {
            transform.position = teleporter.TeleportPoint;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = transform.up.normalized * jumpForce;
        }

        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime;
        moveDirection += transform.right * Input.GetAxisRaw("Horizontal") * strafeSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDirection);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire")) { flame.Play(); }
        else if (Input.GetButtonUp("Fire")) { flame.Stop(); }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, checkerRadius, groundMask);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(teleporterTag)) { teleporter = other.GetComponent<Teleporter>(); }
    }

    private void OnTriggerExit(Collider other) { if (other.CompareTag(teleporterTag)) { teleporter = null; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundChecker.position, checkerRadius);
    }
}
