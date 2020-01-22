using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    private int damage;

    public void UpdateDamageValue(int damageValue)
    {
        damage = damageValue;
    }
}
