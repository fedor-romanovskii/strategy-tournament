using System;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab = null;
    [SerializeField] private float minSpawnRadius = 1f;
    [SerializeField] private float maxSpawnRadius = 3f;

    private int unitsLimit;
    private int unitsAlive;
    private int unitsIdle;

    private float directionCoefficient;

    private PanelSideValues panelSideValues;

    public void UpdateUnitsLimit(int value)
    {
        unitsLimit = value;
    }

    public void SetPanelSideValuesReference(PanelSideValues reference)
    {
        panelSideValues = reference;
        panelSideValues.UpdateUnitLimit($"{unitsAlive}/{unitsLimit}");
    }


    private void OnEnable()
    {
        if (transform.position.x >= 0f) directionCoefficient = -1f;
        else directionCoefficient = 1f;
    }

    public void SpawnUnit(Action<bool> onSuccsess)
    {
        if (unitsAlive < unitsLimit)
        {
            var xOffset = UnityEngine.Random.Range(minSpawnRadius, maxSpawnRadius) * directionCoefficient;
            var yOffset = UnityEngine.Random.Range(minSpawnRadius, maxSpawnRadius) * directionCoefficient;
            var spawningOffset = new Vector3(xOffset, yOffset, 0f);

            var newUnit = Instantiate(unitPrefab,
                transform.position + spawningOffset,
                Quaternion.identity,
                transform);
            unitsAlive++;
            unitsIdle++;
            panelSideValues.UpdateUnitLimit($"{unitsAlive}/{unitsLimit}");
            onSuccsess(true);
        }
    }
}
