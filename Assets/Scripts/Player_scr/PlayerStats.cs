using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int maxhealth = 3;
    [SerializeField] float invulnerabilityTime = 1f;
    [SerializeField] Image hearts;
    [SerializeField] int heartSize = 32;

    float currentHealth;
    float invulnerabilityTimer;

    public bool IsDead { get => currentHealth < 0.5f; }

    private void Awake() => currentHealth = maxhealth;

    public void TakeDamage()
    {
        if (Time.time < invulnerabilityTimer) { return; }
        invulnerabilityTimer = Time.time + invulnerabilityTime;

        currentHealth--;
        hearts.rectTransform.sizeDelta = new Vector2(currentHealth * heartSize, hearts.rectTransform.sizeDelta.y);

        if (currentHealth <= 0)
        {
            Debug.Log("You lost!");
        }
    }
}
