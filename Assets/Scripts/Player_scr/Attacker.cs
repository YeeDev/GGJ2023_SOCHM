using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Attacker : MonoBehaviour
{
    [SerializeField] float timeToOverheat = 3f;
    [SerializeField] float regularCoolRate = 5f;
    [SerializeField] float timeToCool = 6f;
    [SerializeField] float timeToStartCooling = 0.5f;
    [SerializeField] Color coldColor;
    [SerializeField] Color overheatColor;
    [SerializeField] Image flamethrowerBar;
    [SerializeField] ParticleSystem flame;

    bool cooling;

    public void StopAttacking() { flame.Stop(); }

    public void Attack()
    {
        if (cooling) { return; }

        if (flame.isStopped) { flame.Play(); }

        UpdateBar(timeToOverheat);

        if (flamethrowerBar.fillAmount >= 1) { StartCoroutine(Cool()); }
    }

    public void OvertimeCool()
    {
        if (cooling) { return; }

        if (flame.isPlaying) { flame.Stop(); }

        UpdateBar(-regularCoolRate);
    }

    private IEnumerator Cool()
    {
        cooling = true;
        flame.Stop();

        yield return new WaitForSeconds(timeToStartCooling);

        while (flamethrowerBar.fillAmount > 0)
        {
            yield return new WaitForEndOfFrame();
            UpdateBar(-timeToCool);
        }

        cooling = false;
    }

    private void UpdateBar(float time)
    { 
        flamethrowerBar.fillAmount += 1.0f / time * Time.deltaTime;
        if (!cooling) { flamethrowerBar.color = Color.Lerp(coldColor, overheatColor, flamethrowerBar.fillAmount); }
    }
}
