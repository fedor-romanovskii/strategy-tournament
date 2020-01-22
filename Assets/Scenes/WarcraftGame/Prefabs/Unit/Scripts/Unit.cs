using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int Hp { get; set; }
    public int Damage { get; set; }

    // In next virtual methods can be some overriding. e.g. fighter cant attack flying type of enemies.
    public virtual void Attack(Unit target)
    {
        target.TakeDamage(Damage);
    }

    public virtual void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
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

