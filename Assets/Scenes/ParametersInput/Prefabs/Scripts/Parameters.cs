using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public int baseHP;
    public int baseDamage;
    public float goldSpeed;
    public float lumberSpeed;
    public int unitPrice;
    public int upgradePrice;
    public float moveSpeed;
    public float detectionRange;

    public void SetParameters(Dictionary<PanelOption.OptionType, string> parameters)
    {
        baseHP = int.Parse(parameters[PanelOption.OptionType.baseHP]);
        baseDamage = int.Parse(parameters[PanelOption.OptionType.baseDamage]);
        goldSpeed = float.Parse(parameters[PanelOption.OptionType.goldSpeed]);
        lumberSpeed = float.Parse(parameters[PanelOption.OptionType.lumberSpeed]);
        unitPrice = int.Parse(parameters[PanelOption.OptionType.unitPrice]);
        upgradePrice = int.Parse(parameters[PanelOption.OptionType.upgradePrice]);
        moveSpeed = float.Parse(parameters[PanelOption.OptionType.moveSpeed]);
        detectionRange = float.Parse(parameters[PanelOption.OptionType.detectionRange]);
    }
}
