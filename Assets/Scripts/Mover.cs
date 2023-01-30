using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2;
    [SerializeField] float strafeSpeed = 1;
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] GameObject flame;

    Vector3 moveDirection;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime;
        moveDirection += transform.right * Input.GetAxisRaw("Horizontal") * strafeSpeed* Time.deltaTime;
        rb.MovePosition(transform.position + moveDirection);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime);

        flame.SetActive(Input.GetButton("Fire"));
    }
}
