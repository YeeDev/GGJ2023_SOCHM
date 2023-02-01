using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attacker))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] float checkerRadius;
    [SerializeField] Transform groundChecker;

    bool isGrounded;
    Mover mover;
    Attacker attacker;
    Teleporter teleporter;

    public Teleporter SetTeleporter { set => teleporter = value; }
    public void RemoveTeleporter() { teleporter = null; }

    private void Awake()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
    }

    void Update()
    {
        ReadMoveInput();
        ReadTeleportInput();
        ReadJumpInput();
        ReadRotationInput();
        ReadAttackInput();
    }

    private void FixedUpdate() => isGrounded = Physics.CheckSphere(groundChecker.position, checkerRadius, groundMask);

    private void ReadMoveInput()
    {
        mover.MoveInDirection(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void ReadTeleportInput()
    {
        if (Input.GetButtonDown("Teleport") && teleporter != null && teleporter.IsActive)
        {
            mover.Teleport(teleporter.TeleportPoint);
        }
    }

    private void ReadJumpInput() { if (Input.GetButtonDown("Jump") && isGrounded) { mover.Jump(); } }

    private void ReadRotationInput() => mover.Rotate(Input.GetAxisRaw("Mouse X"));


    private void ReadAttackInput()
    {
        if (Input.GetButton("Fire")) { attacker.Attack(); }
        else if (!Input.GetButton("Fire")) { attacker.OvertimeCool(); }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundChecker.position, checkerRadius);
    }
#endif
}
