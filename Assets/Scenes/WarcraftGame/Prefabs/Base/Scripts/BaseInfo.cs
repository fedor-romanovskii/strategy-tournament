﻿using UnityEngine;

public class BaseInfo : MonoBehaviour
{
    [SerializeField] private PanelSideValues panelSideValues = null;

    public int HP { get; private set; }

    private int maxHP;

    public enum BaseSide
    {
        player,
        enemy
    }

    public BaseSide baseSide;

    private void OnEnable()
    {
        Parameters parameters = GetParametersFromData();
        Setup(parameters);
        SetupGoldCollector(parameters);
        SetupLumberCollector(parameters);
        SetupBaseAttack(parameters);
        SetupUnitSpawner(parameters);
    }

    private void SetupUnitSpawner(Parameters parameters)
    {
        UnitSpawner unitSpawner = GetComponent<UnitSpawner>();
        unitSpawner.SetPanelSideValuesReference(panelSideValues);
    }

    private void Setup(Parameters parameters)
    {
        HP = parameters.baseHP;
        maxHP = HP;
    }

    private void SetupBaseAttack(Parameters parameters)
    {
        GetComponent<BaseAttack>().UpdateDamageValue(parameters.baseDamage);
    }

    private void SetupLumberCollector(Parameters parameters)
    {
        LumberCollector lumberCollector = GetComponent<LumberCollector>();
        lumberCollector.UpdateCollectPerSecond(parameters.lumberSpeed);
        lumberCollector.UpdateUpgradePrice(parameters.upgradePrice);
        lumberCollector.SetPanelSideValuesReference(panelSideValues);
    }

    private void SetupGoldCollector(Parameters parameters)
    {
        GoldCollector goldCollector = GetComponent<GoldCollector>();
        goldCollector.UpdateCollectPerSecond(parameters.goldSpeed);
        goldCollector.UpdateUnitPrice(parameters.unitPrice);
        goldCollector.SetPanelSideValuesReference(panelSideValues);
    }

    private Parameters GetParametersFromData()
    {
        Parameters parameters = GetComponent<Parameters>();

        if (ParametersContainer.instance != null)
        {
            if (baseSide == BaseSide.player)
            {
                parameters.CopyParameters(ParametersContainer.instance.PlayerParameters);
            }
            else
            {
                parameters.CopyParameters(ParametersContainer.instance.EnemyParameters);
            }
        }

        return parameters;
    }
}
