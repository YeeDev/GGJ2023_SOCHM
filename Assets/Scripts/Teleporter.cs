using UnityEngine;
using System.Collections;
using System.Linq;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform[] enemiesTiedTo;
    [SerializeField] Renderer lightPost;
    [SerializeField] ParticleSystem activatedEffect;

    private void Awake() => StartCoroutine(ActivateTeleporter());

    public bool IsActive { get => enemiesTiedTo.All(t => t == null); }
    public Vector3 TeleportPoint { get => transform.GetChild(0).position; }

    private IEnumerator ActivateTeleporter()
    {
        yield return new WaitUntil(() => IsActive);

        lightPost.materials[1].SetColor("_EmissionColor", Color.green);
        activatedEffect.Play();
    }
}
