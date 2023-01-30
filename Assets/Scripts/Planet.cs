using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] string unit = "Unit";
    [SerializeField] float gravityForce = 9.18f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(unit))
        {
            Vector3 gravityUp = (transform.position - other.transform.position).normalized;
            Vector3 bodyUp = other.transform.up;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(gravityUp * gravityForce);

            Quaternion rotation = Quaternion.FromToRotation(bodyUp, gravityUp) * other.transform.rotation;
            other.transform.rotation = Quaternion.Slerp(other.transform.rotation, rotation, 50 * Time.deltaTime);
        }
    }
}
