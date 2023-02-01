using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2f;
    [SerializeField] float strafeSpeed = 1f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] string teleporterTag = "Teleporter";
    [SerializeField] float teleportTime = 3f;
    [SerializeField] ParticleSystem flame;

    Transform teleporter;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Teleport") && teleporter != null)
        {
            transform.position = teleporter.GetChild(0).position;
        }

        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime;
        moveDirection += transform.right * Input.GetAxisRaw("Horizontal") * strafeSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDirection);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire")) { flame.Play(); }
        else if (Input.GetButtonUp("Fire")) { flame.Stop(); }
    }

    private void OnTriggerEnter(Collider other) { if (other.CompareTag(teleporterTag)) { teleporter = other.transform; } }
    private void OnTriggerExit(Collider other) { if (other.CompareTag(teleporterTag)) { teleporter = null; } }
}
