using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 500;
    [SerializeField] float lifeTime = 5;

    Rigidbody rb;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void OnEnable() => Destroy(gameObject, lifeTime);

    void Update() => rb.velocity = transform.forward * speed * Time.deltaTime;
}
