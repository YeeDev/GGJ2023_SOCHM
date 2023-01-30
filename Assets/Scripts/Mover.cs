using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] GameObject bullet;

    Vector3 moveDirection;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDirection);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
