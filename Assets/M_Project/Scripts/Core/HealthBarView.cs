using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
        slider.maxValue = health.MaxHealth;
        slider.value = health.MaxHealth;
        health.OnHit += UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        slider.value = health.CurrentHealth;
    }

    private void OnDisable()
    {
        health.OnHit -= UpdateHealthBar;
    }
}
