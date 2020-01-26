using UnityEngine;

public class BaseInfo : MonoBehaviour
{
    [SerializeField] private PanelSideValues panelSideValues = null;

    public int HP { get; private set; }

    private int maxHP;

    public enum BaseSide
    {
        player,
        enemy,
        neutral
    }

    [SerializeField] private BaseSide baseSide = BaseSide.player;

    private void OnEnable()
    {
        var parameters = GetParametersFromData();
        Setup(parameters);
        foreach(IParameterable component in GetComponents<IParameterable>())
        {
            component.SetupWithParameters(parameters);
        }
        foreach(ISidePanelChangeable component in GetComponents<ISidePanelChangeable>())
        {
            component.SetupSidePanel(panelSideValues);
        }
        foreach (IPlayerSideDepedable component in GetComponents<IPlayerSideDepedable>())
        {
            component.SetupWithPlayerSide(baseSide);
        }
    }

    private void Setup(Parameters parameters)
    {
        HP = parameters.baseHP;
        maxHP = HP;
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
