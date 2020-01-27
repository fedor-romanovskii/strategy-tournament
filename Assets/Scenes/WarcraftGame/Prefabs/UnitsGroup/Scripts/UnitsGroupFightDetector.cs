using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsGroupFightDetector : MonoBehaviour
{
    public bool IsFighting { get; private set; }

    private BaseInfo.BaseSide unitGroupSide = BaseInfo.BaseSide.player;
    public void SetSide(BaseInfo.BaseSide _unitGroupSide) => unitGroupSide = _unitGroupSide;
    public BaseInfo.BaseSide GetSide() => unitGroupSide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsFighting) return;

        var enemy = collision.gameObject.GetComponent<UnitsGroupFightDetector>();

        if (enemy != null)
        {
            if (enemy.GetSide() == unitGroupSide) return;
            PutsUnitInPositions(enemy.transform);
            GetComponent<UnitGroupFollow>().isFighting = true;
            IsFighting = true;
            GetComponent<UnitGroup>().StartAttack(enemy.GetComponent<UnitGroup>());
        }
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
}
