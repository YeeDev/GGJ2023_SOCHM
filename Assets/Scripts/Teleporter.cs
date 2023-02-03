using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform enemyTiedTo;
    [SerializeField] Renderer lightPost;
    [SerializeField] ParticleSystem activatedEffect;

    private void Awake() => StartCoroutine(ActivateTeleporter());

    public bool IsActive { get => enemyTiedTo == null; }
    public Vector3 TeleportPoint { get => transform.GetChild(0).position; }

    private IEnumerator ActivateTeleporter()
    {
        yield return new WaitUntil(() => enemyTiedTo == null);

        lightPost.materials[1].SetColor("_EmissionColor", Color.green);
        activatedEffect.Play();
    }
}
