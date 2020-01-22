using UnityEngine;

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

        HP = parameters.baseHP;
        maxHP = HP;

        GoldCollector goldCollector = GetComponent<GoldCollector>();
        goldCollector.UpdateCollectPerSecond(parameters.goldSpeed);
        goldCollector.UpdateUnitPrice(parameters.unitPrice);
        goldCollector.SetPanelSideValuesReference(panelSideValues);

        LumberCollector lumberCollector = GetComponent<LumberCollector>();
        lumberCollector.UpdateCollectPerSecond(parameters.lumberSpeed);
        lumberCollector.UpdateUpgradePrice(parameters.unitPrice);
        lumberCollector.SetPanelSideValuesReference(panelSideValues);

        GetComponent<BaseAttack>().UpdateDamageValue(parameters.baseDamage);
    }
}
