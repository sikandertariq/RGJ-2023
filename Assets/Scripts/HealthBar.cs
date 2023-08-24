using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TowerHealth towerHealth;
    public Slider healthSlider;

    private void Start()
    {
        if (towerHealth == null)
        {
            Debug.LogWarning("TowerHealth reference not set in HealthBar script.");
            enabled = false;
            return;
        }

        if (healthSlider == null)
        {
            Debug.LogWarning("HealthSlider reference not set in HealthBar script.");
            enabled = false;
            return;
        }

        healthSlider.maxValue = towerHealth.maxHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = towerHealth.currentHealth;
    }

    private void Update()
    {
        UpdateHealthBar();
    }
}
