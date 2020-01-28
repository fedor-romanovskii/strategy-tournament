using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsGroupFightDetector : MonoBehaviour
{
    public bool IsFighting { get; private set; }
    public UnitsGroupFightDetector Enemy { get; private set; }

    private BaseInfo.BaseSide unitGroupSide = BaseInfo.BaseSide.player;
    public void SetSide(BaseInfo.BaseSide _unitGroupSide) => unitGroupSide = _unitGroupSide;
    public BaseInfo.BaseSide GetSide() => unitGroupSide;

    private BaseInfo baseToAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsFighting) return;

        var enemy = collision.gameObject.GetComponent<UnitsGroupFightDetector>();

        if (enemy != null && (!enemy.IsFighting || enemy.Enemy == this))
        {
            if (enemy.GetSide() == unitGroupSide) return;
            PutsUnitInPositions(enemy.transform);
            SetAsFighting(true);
            Enemy = enemy;
            GetComponent<UnitGroup>().StartAttack(enemy.GetComponent<UnitGroup>());
            return;
        }

        baseToAttack = collision.GetComponent<BaseInfo>();

        if (baseToAttack != null && collision.GetComponent<BaseInfo>().baseSide != unitGroupSide)
        {
            StartCoroutine(AttackBase(collision.GetComponent<BaseInfo>()));
        }
    }

    public void SetAsFighting(bool value)
    {
        GetComponent<UnitGroupFollow>().isFighting = value;
        IsFighting = value;
    }

    private void PutsUnitInPositions(Transform enemyTransform)
    {
        var distanceBetweenUnits = .5f;
        var row = 0;
        var column = 0;
        var offset = new Vector2(2 * distanceBetweenUnits, -2 * distanceBetweenUnits);
        transform.right = enemyTransform.position - transform.position;

        foreach (Transform unit in GetComponentsInChildren<Transform>())
        {
            if (unit == transform) continue;
            unit.transform.localPosition = new Vector2(-column, row) * distanceBetweenUnits + offset;
            row++;
            if (row == 5)
            {
                column++;
                row = 0;
            }
        }
    }

    public IEnumerator AttackBase(BaseInfo baseToAttack)
    {
        GetComponent<UnitGroup>().SetupUnitGroupHpAndDamage();
        baseToAttack.GetComponent<UnitsGroupBuilder>().ExtraGroupBuild();

        while (true)
        {
            if (!IsFighting)
            {
                print("attacking base" + baseToAttack.name);
                baseToAttack.SetDamage(GetComponentsInChildren<Unit>().Length);
                GetComponent<UnitGroup>().MinusHp(baseToAttack.Damage);
                yield return new WaitForSeconds(.5f);
            }
            yield return new WaitForSeconds(.5f);
        }
    }
}
