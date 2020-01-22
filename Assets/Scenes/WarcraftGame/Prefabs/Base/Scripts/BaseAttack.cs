using UnityEngine;
using System.Collections;

public class BaseAttack : MonoBehaviour
{
    private int damage;

    public void UpdateDamageValue(int damageValue)
    {
        damage = damageValue;
    }
}
