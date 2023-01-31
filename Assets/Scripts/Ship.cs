using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] float constantThrust = 2f;
    [SerializeField] float boost = 1.1f;
    [SerializeField] float pitchSpeed = 2f;
    [SerializeField] float rollSpeed = 1f;
    [SerializeField] ParticleSystem thrustParticles;
    [SerializeField] float maxParticlesLength;

    float initialParticlesLength;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initialParticlesLength = thrustParticles.main.startLifetime.constant;
    }

    private void Update()
    {
        Pitch(Input.GetAxisRaw("Vertical") * pitchSpeed * Time.deltaTime);
        Roll(Input.GetAxisRaw("Horizontal") * rollSpeed * Time.deltaTime);
    }

    void FixedUpdate() => Thrust();

    private void Thrust()
    {
        Vector3 thrustSpeed = transform.forward * constantThrust;

        if (Input.GetButton("Jump/Thrust"))
        {
            thrustSpeed *= boost;
            ChangeParticlesLength(maxParticlesLength);
        }
        else { ChangeParticlesLength(initialParticlesLength); }

        rb.velocity = thrustSpeed;
    }

    private void ChangeParticlesLength(float lenght)
    {
        var main = thrustParticles.main;
        main.startLifetime = lenght;
    }

    public void Pitch(float angle) => transform.Rotate(transform.right, angle, Space.World);
    public void Roll(float angle) => transform.Rotate(-transform.forward, angle, Space.World);
}
