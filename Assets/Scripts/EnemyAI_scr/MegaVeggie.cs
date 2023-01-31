using System.Collections.Generic;
using UnityEngine;

public class MegaVeggie : MonoBehaviour
{
    EnemyStats stats;
    List<GameObject> roots = new List<GameObject>();

    private void Awake()
    {
        stats = GetComponent<EnemyStats>();
        stats.MakeInvulnerable();

        foreach (Transform child in transform)
        {
            roots.Add(child.gameObject);
        }
    }

    public void RemoveAndCheckRoots(GameObject rootToRemove)
    {
        roots.Remove(rootToRemove);

        if (roots.Count <= 0)
        {
            stats.MakeVulnerable();
        }
    }
}
