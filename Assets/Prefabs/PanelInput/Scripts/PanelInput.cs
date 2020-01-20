using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInput : MonoBehaviour
{
    public int baseHP { get; private set; } = 100;
    public int baseDamage { get; private set; } = 1;
    public float goldSpeed { get; private set; } = 5f;
    public float lumberSpeed { get; private set; } = 1f;
    public int unitPrice { get; private set; } = 10;
    public int upgradePrice { get; private set; } = 15;
    public float moveSpeed { get; private set; } = 1f;
    public float detectionRange { get; private set; } = 1f;

    [SerializeField] private InputField inputBaseHP = null;
    [SerializeField] private InputField inputBaseDamage = null;
    [SerializeField] private InputField inputGoldSpeed = null;
    [SerializeField] private InputField inputLumberSpeed = null;
    [SerializeField] private InputField inputUnitPrice = null;
    [SerializeField] private InputField inputUpgradePrice = null;
    [SerializeField] private InputField inputMoveSpeed = null;
    [SerializeField] private InputField inputDetectionRange = null;

    private void OnEnable()
    {
        SetDefaultValues();
        AddInputListeners();
    }

    private void OnDisable()
    {
        RemoveInputListeners();
    }

    private void RemoveInputListeners()
    {
        inputBaseHP.onEndEdit.RemoveAllListeners();
        inputBaseDamage.onEndEdit.RemoveAllListeners();
        inputGoldSpeed.onEndEdit.RemoveAllListeners();
        inputLumberSpeed.onEndEdit.RemoveAllListeners();
        inputUnitPrice.onEndEdit.RemoveAllListeners();
        inputUpgradePrice.onEndEdit.RemoveAllListeners();
        inputMoveSpeed.onEndEdit.RemoveAllListeners();
        inputDetectionRange.onEndEdit.RemoveAllListeners();
    }

    private void AddInputListeners()
    {
        inputBaseHP.onEndEdit.AddListener((value) => baseHP = int.Parse(value));
        inputBaseDamage.onEndEdit.AddListener((value) => baseDamage = int.Parse(value));
        inputGoldSpeed.onEndEdit.AddListener((value) => goldSpeed = float.Parse(value));
        inputLumberSpeed.onEndEdit.AddListener((value) => lumberSpeed = float.Parse(value));
        inputUnitPrice.onEndEdit.AddListener((value) => unitPrice = int.Parse(value));
        inputUpgradePrice.onEndEdit.AddListener((value) => upgradePrice = int.Parse(value));
        inputMoveSpeed.onEndEdit.AddListener((value) => moveSpeed = float.Parse(value));
        inputDetectionRange.onEndEdit.AddListener((value) => detectionRange = float.Parse(value));
    }

    private void SetDefaultValues()
    {
        inputBaseHP.text = baseHP.ToString();
        inputBaseDamage.text = baseDamage.ToString();
        inputGoldSpeed.text = goldSpeed.ToString();
        inputLumberSpeed.text = lumberSpeed.ToString();
        inputUnitPrice.text = unitPrice.ToString();
        inputUpgradePrice.text = upgradePrice.ToString();
        inputMoveSpeed.text = moveSpeed.ToString();
        inputDetectionRange.text = detectionRange.ToString();
    }
}
