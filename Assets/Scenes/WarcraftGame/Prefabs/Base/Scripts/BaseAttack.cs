using UnityEngine;

public class BaseAttack : MonoBehaviour, IParameterable
{
    private int damage;

    public void SetupWithParameters(Parameters parameters)
    {
        UpdateDamageValue(parameters.baseDamage);
    }

    private void UpdateDamageValue(int damageValue)
    {
        damage = damageValue;
    }
}
