using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private PanelInput playerInputPanel = null;
    [SerializeField] private PanelInput enemyInputPanel = null;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonStartClick);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void OnButtonStartClick()
    {
        PlayerParameters.baseHP = playerInputPanel.baseHP;
        PlayerParameters.baseDamage = playerInputPanel.baseDamage;
        PlayerParameters.goldSpeed = playerInputPanel.goldSpeed;
        PlayerParameters.lumberSpeed = playerInputPanel.lumberSpeed;
        PlayerParameters.unitPrice = playerInputPanel.unitPrice;
        PlayerParameters.upgradePrice = playerInputPanel.upgradePrice;
        PlayerParameters.moveSpeed = playerInputPanel.moveSpeed;
        PlayerParameters.detectionRange = playerInputPanel.detectionRange;

        EnemyParameters.baseHP = enemyInputPanel.baseHP;
        EnemyParameters.baseDamage = enemyInputPanel.baseDamage;
        EnemyParameters.goldSpeed = enemyInputPanel.goldSpeed;
        EnemyParameters.lumberSpeed = enemyInputPanel.lumberSpeed;
        EnemyParameters.unitPrice = enemyInputPanel.unitPrice;
        EnemyParameters.upgradePrice = enemyInputPanel.upgradePrice;
        EnemyParameters.moveSpeed = enemyInputPanel.moveSpeed;
        EnemyParameters.detectionRange = enemyInputPanel.detectionRange;

        SceneManager.LoadScene(1);

    }
}
