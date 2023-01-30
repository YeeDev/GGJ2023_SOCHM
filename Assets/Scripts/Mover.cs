using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 moveDirection;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDirection = transform.forward * -Input.GetAxisRaw("Vertical") * speed;
        rb.MovePosition(transform.position + moveDirection);
    }
}
