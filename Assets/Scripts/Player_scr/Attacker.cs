using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] ParticleSystem flame;

    public void PlayParticles() => flame.Play();
    public void StopParticles() => flame.Stop();
}
