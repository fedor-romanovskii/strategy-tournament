using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInput : MonoBehaviour
{
    [SerializeField] private int baseHP = 100;
    [SerializeField] private int baseDamage = 1;
    [SerializeField] private float goldSpeed = 5f;
    [SerializeField] private float lumberSpeed = 1f;
    [SerializeField] private int unitPrice = 10;
    [SerializeField] private int upgradePrice = 15;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float detectionRange = 1f;

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
        inputBaseHP.text = baseHP.ToString();
        inputBaseDamage.text = baseDamage.ToString();
        inputGoldSpeed.text = goldSpeed.ToString();
        inputLumberSpeed.text = lumberSpeed.ToString();
        inputUnitPrice.text = unitPrice.ToString();
        inputUpgradePrice.text = upgradePrice.ToString();
        inputMoveSpeed.text = moveSpeed.ToString();
        inputDetectionRange.text = detectionRange.ToString();


        inputBaseHP.onEndEdit.AddListener((value) => baseHP = int.Parse(value));
        inputBaseDamage.onEndEdit.AddListener((value) => baseDamage = int.Parse(value));
        inputGoldSpeed.onEndEdit.AddListener((value) => goldSpeed = float.Parse(value));
        inputLumberSpeed.onEndEdit.AddListener((value) => lumberSpeed = float.Parse(value));
        inputUnitPrice.onEndEdit.AddListener((value) => unitPrice = int.Parse(value));
        inputUpgradePrice.onEndEdit.AddListener((value) => upgradePrice = int.Parse(value));
        inputMoveSpeed.onEndEdit.AddListener((value) => moveSpeed = float.Parse(value));
        inputDetectionRange.onEndEdit.AddListener((value) => detectionRange = float.Parse(value));
    }
}
