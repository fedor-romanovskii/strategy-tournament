using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneUnitHealthBar : MonoBehaviour
{
    [SerializeField] private Image health = null;
    public float maxHealth;
    public float currentHealth;

    public void RefreshImageFill(float _health)
    {
        currentHealth = _health;
        float fillAmount = (float)currentHealth / (float)maxHealth;
        health.fillAmount = fillAmount;
    }
}
