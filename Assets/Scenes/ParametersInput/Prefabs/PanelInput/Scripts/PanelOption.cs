using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOption : MonoBehaviour
{
    public enum OptionType
    {
        baseHP,
        baseDamage,
        goldSpeed,
        lumberSpeed,
        unitPrice,
        upgradePrice,
        moveSpeed,
        detectionRange,
    }

    public OptionType optionType;
    public string optionValue;

    private InputField inputField;

    private void OnEnable()
    {
        inputField = GetComponentInChildren<InputField>();
        inputField.text = optionValue.ToString();
        inputField.onEndEdit.AddListener((value) => optionValue = value);
    }

    private void OnDisable()
    {
        inputField.onEndEdit.RemoveAllListeners();
    }
}
