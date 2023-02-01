using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Attacker : MonoBehaviour
{
    [SerializeField] float timeToOverheat = 3f;
    [SerializeField] float regularCoolRate = 5f;
    [SerializeField] float timeToCool = 6f;
    [SerializeField] float timeToStartCooling = 0.5f;
    [SerializeField] Image flamethrowerBar;
    [SerializeField] ParticleSystem flame;

    bool cooling;

    public void Attack()
    {
        if (cooling) { return; }

        if (flame.isStopped && flamethrowerBar.fillAmount > 0) { flame.Play(); }

        flamethrowerBar.fillAmount -= 1.0f / timeToOverheat * Time.deltaTime;

        if (flamethrowerBar.fillAmount <= 0)
        {
            cooling = true;
            flame.Stop();
            StartCoroutine(Cool());
        }
    }

    public void OvertimeCool()
    {
        if (cooling || flamethrowerBar.fillAmount >= 1) { return; }

        if (flame.isPlaying) { flame.Stop(); }

        flamethrowerBar.fillAmount += 1.0f / regularCoolRate * Time.deltaTime;
    }

    private IEnumerator Cool()
    {
        yield return new WaitForSeconds(timeToStartCooling);

        while (flamethrowerBar.fillAmount < 1)
        {
            yield return new WaitForEndOfFrame();
            flamethrowerBar.fillAmount += 1.0f / timeToCool * Time.deltaTime;
        }

        cooling = false;
    }
}
