using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject unitHealthPrefab = null;
    private int health = 5;
    private int currentHealth = 5;
    private int oneUnitHealth = 5;
    private int unitHealthBarNumber;

    public void SetOneUnitHealth(int _oneUnitHealth)
    {
        oneUnitHealth = _oneUnitHealth;
    }

    public void SetHealth(int _health)
    {
        health = _health;
        currentHealth = health;

        unitHealthBarNumber = health / oneUnitHealth;
        for (int i = 0; i < unitHealthBarNumber - 1; i++)
        {
            Instantiate(unitHealthPrefab, transform);
        }
    }

    public void SetDamage(int damage)
    {
        currentHealth -= damage;
        float currentHealthCounter = currentHealth;
        foreach (OneUnitHealthBar oneUnitHealthBar in GetComponentsInChildren<OneUnitHealthBar>())
        { 
            if ((int)currentHealthCounter / unitHealthBarNumber > 0)
            {
                oneUnitHealthBar.RefreshImageFill(oneUnitHealth);
                currentHealthCounter -= oneUnitHealth;
            }
            else if (currentHealthCounter != 0)
            {
                oneUnitHealthBar.RefreshImageFill(currentHealthCounter);
                currentHealthCounter = 0;
            }
            else
            {
                oneUnitHealthBar.RefreshImageFill(0);
            }
        }
    }
}
