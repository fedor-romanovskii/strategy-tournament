using UnityEngine;

public class BaseInfo : MonoBehaviour
{
    [SerializeField] private PanelSideValues panelSideValues = null;

    public PanelSideValues GetPanelSideValues() => panelSideValues;

    public int Stage { get; private set; }

    public void UpgradeStage()
    {
        Stage++;
        panelSideValues.UpdateStage((Stage + 1).ToString());
    }

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

        panelSideValues.UpdateStage((Stage + 1).ToString());
        GetComponent<GoldCollector>().UpdateCollectPerSecond(parameters.goldSpeed);
        GetComponent<LumberCollector>().UpdateCollectPerSecond(parameters.lumberSpeed);
    }
}
