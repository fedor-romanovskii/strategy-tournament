using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsGroupBuilder : MonoBehaviour, IPlayerSideDepedable
{
    private List<GameObject> units = new List<GameObject>();
    [SerializeField] private int numberOfUnitsInGroup = 5;
    private BaseInfo.BaseSide baseSide;

    private void OnEnable()
    {
        GetComponent<LumberCollector>().onStageUp += UpdateNumberOfUnitsInGroup;
    }

    private void OnDisable()
    {
        GetComponent<LumberCollector>().onStageUp -= UpdateNumberOfUnitsInGroup;
    }

    private void UpdateNumberOfUnitsInGroup(int stage)
    {
        numberOfUnitsInGroup = stage * 5;
    }

    public void SetupWithPlayerSide(BaseInfo.BaseSide reference)
    {
        baseSide = reference;
    }

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
        newUnitsGroup.transform.localPosition = Vector2.zero;
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

        var unitGroup = newUnitsGroup.AddComponent<UnitGroup>();
    
        var unitsGroupFightDetector = newUnitsGroup.AddComponent<UnitsGroupFightDetector>();
        unitsGroupFightDetector.SetSide(baseSide);
    }

    public void ExtraGroupBuild()
    {
        if (units.Count == 0) return;
        var newUnitsGroup = new GameObject();
        newUnitsGroup.name = "UnitsGroup";
        newUnitsGroup.transform.parent = transform;
        newUnitsGroup.transform.localPosition = Vector2.zero;
        foreach (GameObject unit in units)
        {
            unit.transform.parent = newUnitsGroup.transform;
            unit.transform.localPosition = new Vector2(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        }
        units.Clear();

        var unitsGroupFollow = newUnitsGroup.AddComponent<UnitGroupFollow>();
        unitsGroupFollow.SetUnitGroupSide(baseSide);

        var unitsGroupRb = newUnitsGroup.AddComponent<Rigidbody2D>();
        unitsGroupRb.isKinematic = true;

        var unitsGroupCollider = newUnitsGroup.AddComponent<CircleCollider2D>();
        unitsGroupCollider.isTrigger = true;
        unitsGroupCollider.radius = 2f;

        var unitGroup = newUnitsGroup.AddComponent<UnitGroup>();

        var unitsGroupFightDetector = newUnitsGroup.AddComponent<UnitsGroupFightDetector>();
        unitsGroupFightDetector.SetSide(baseSide);

    }
}
