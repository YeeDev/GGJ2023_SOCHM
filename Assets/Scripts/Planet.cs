using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] string[] tagsAffected;
    [SerializeField] float gravityForce = -10f;

    bool needsCleaning;
    Dictionary<Transform, Rigidbody> pulledUnits = new Dictionary<Transform, Rigidbody>();

    private void OnTriggerEnter(Collider other) => CheckIfAddToPulled(other);
    private void OnTriggerExit(Collider other) => pulledUnits.Remove(other.transform);
    private void Update() => RotateAndPull();

    private void CheckIfAddToPulled(Collider other)
    {
        if (IsValidTag(other.tag) && !pulledUnits.ContainsKey(other.transform))
        {
            pulledUnits.Add(other.transform, other.GetComponent<Rigidbody>());
        }
    }

    private bool IsValidTag(string tag) { return tagsAffected.Any(t => t == tag); }

    private void RotateAndPull()
    {
        foreach (KeyValuePair<Transform, Rigidbody> unit in pulledUnits)
        {
            if (unit.Value == null) { needsCleaning = true; continue; }

            Vector3 gravityDirection = (unit.Key.position - transform.position).normalized;
            unit.Key.rotation = Quaternion.FromToRotation(unit.Key.up, gravityDirection) * unit.Key.rotation;
            unit.Value.AddForce(gravityDirection * gravityForce);
        }

        if (needsCleaning) { CleanDictionary(); }
    }

    private void CleanDictionary()
    {
        needsCleaning = false;

        pulledUnits = pulledUnits.Where(k => k.Value != null).ToDictionary(x => x.Key, x => x.Value);
    }
}
