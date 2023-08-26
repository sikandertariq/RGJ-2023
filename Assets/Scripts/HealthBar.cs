using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TowerHealth towerHealth;
    public Slider healthSlider;

    private void Start()
    {
        healthSlider.maxValue = towerHealth.maxHealth;
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        healthSlider.value = towerHealth.currentHealth;
    }
}
