using UnityEngine;

[RequireComponent(typeof(Veggie))]
public class VeggieCollisionHandler : AICollisionHandler
{
    [SerializeField] string targetTag = "Player";

    Veggie veggie;

    protected override void Awake()
    {
        base.Awake();
        veggie = GetComponent<Veggie>();
    }

    private void OnTriggerStay(Collider other) { if (other.CompareTag(targetTag)) { veggie.SetTarget(other.transform); } }
    private void OnTriggerExit(Collider other) { veggie.RemoveTarget(other.transform); }
}
