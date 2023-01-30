using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    Vector3 moveDirection;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical");


        rb.MovePosition(transform.position + moveDirection);
    }
}
