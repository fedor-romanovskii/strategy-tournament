using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int hp;
    public int damage;

    // In next virtual methods can be some overriding. e.g. fighter cant attack flying type of enemies.
    public virtual void Attack(Unit target)
    {
        target.TakeDamage(damage);
    }

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    protected void Die()
    {
        Destroy(gameObject); 
    }

    protected void JoinGroup()
    {
        Debug.Log("Unit join group");
    }
}

