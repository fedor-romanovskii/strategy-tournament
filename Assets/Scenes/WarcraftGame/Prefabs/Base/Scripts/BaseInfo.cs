using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInfo : MonoBehaviour
{
    public int Stage { get; private set; }
    public int Hp { get; private set; }

    public void UpgradeStage()
    {
        Stage++;
    }

    public enum BaseSide
    {
        player,
        enemy
    }

    public BaseSide baseSide;

    private void OnEnable()
    {
        if (ParametersContainer.instance != null)
        {
            if (baseSide == BaseSide.player)
            {
                GetComponent<Parameters>().CopyParameters(ParametersContainer.instance.PlayerParameters);
            }
            else
            {
                GetComponent<Parameters>().CopyParameters(ParametersContainer.instance.EnemyParameters);
            }
        }
    }
}
