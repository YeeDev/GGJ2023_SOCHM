using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] string unit = "Unit";
    [SerializeField] float gravityForce = -10f;

    Dictionary<Transform, Rigidbody> pulledUnits = new Dictionary<Transform, Rigidbody>();

    private void OnTriggerEnter(Collider other) => CheckIfAddToPulled(other);
    private void OnTriggerExit(Collider other) => pulledUnits.Remove(other.transform);
    private void Update() => RotateAndPull();

    private void CheckIfAddToPulled(Collider other)
    {
        if (other.CompareTag(unit) && !pulledUnits.ContainsKey(other.transform))
        {
            pulledUnits.Add(other.transform, other.GetComponent<Rigidbody>());
        }
    }

    private void RotateAndPull()
    {
        foreach (KeyValuePair<Transform, Rigidbody> unit in pulledUnits)
        {
            Vector3 gravityDirection = (unit.Key.position - transform.position).normalized;
            Rotate(unit.Key, gravityDirection);
            Pull(unit.Value, gravityDirection);
        }
    }

    private void Rotate(Transform unit, Vector3 gravityDirection)
    {
        Quaternion rotation = Quaternion.FromToRotation(unit.up, gravityDirection) * unit.rotation;
        unit.rotation = Quaternion.FromToRotation(unit.up, gravityDirection) * unit.rotation;
    }

    private void Pull(Rigidbody unit, Vector3 gravityDirection) => unit.AddForce(gravityDirection * gravityForce);
}
