using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attacker))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] float checkerRadius;
    [SerializeField] Transform groundChecker;
    [SerializeField] string walkParameter = "Walking";

    bool isGrounded;
    Animator anm;
    Mover mover;
    Attacker attacker;
    PlayerStats stats;

    private void Awake()
    {
        anm = GetComponentInChildren<Animator>();
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (stats.IsDead) { attacker.StopAttacking(); return; }

        ReadMoveInput();
        ReadJumpInput();
        ReadRotationInput();
        ReadAttackInput();
    }

    private void FixedUpdate() => isGrounded = Physics.CheckSphere(groundChecker.position, checkerRadius, groundMask);

    private void ReadMoveInput()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        mover.MoveInDirection(hAxis, vAxis);
        anm.SetBool(walkParameter, Mathf.Abs(hAxis) + Mathf.Abs(vAxis) > 0);
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
