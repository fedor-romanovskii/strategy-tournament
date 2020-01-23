﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsGroupBuilder : MonoBehaviour
{
    private List<GameObject> units = new List<GameObject>();
    private int numberOfUnitsInGroup = 5;
    private BaseInfo.BaseSide baseSide;

    public void SetBaseSide(BaseInfo.BaseSide _baseSide) => baseSide = _baseSide;

    public void AddUnitToList(GameObject unit)
    {
        units.Add(unit);
        CheckGroupCreate();
    }

    private void CheckGroupCreate()
    {
        if (units.Count >= numberOfUnitsInGroup)
        {
            BuildGroup();
        }
    }

    private void BuildGroup()
    {
        var newUnitsGroup = new GameObject();
        newUnitsGroup.name = "UnitsGroup";
        newUnitsGroup.transform.parent = transform;
        for (int i = 0; i < numberOfUnitsInGroup; i++)
        {
            units[i].transform.parent = newUnitsGroup.transform;
            units[i].transform.localPosition = new Vector2(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        }
        units.RemoveRange(0, numberOfUnitsInGroup);
        var unitsGroupFollow = newUnitsGroup.AddComponent<UnitGroupFollow>();
        unitsGroupFollow.SetUnitGroupSide(baseSide);
        var unitsGroupRb = newUnitsGroup.AddComponent<Rigidbody2D>();
        unitsGroupRb.isKinematic = true;
        var unitsGroupCollider = newUnitsGroup.AddComponent<CircleCollider2D>();
        unitsGroupCollider.isTrigger = true;
        unitsGroupCollider.radius = 2f;
    }
}
