using System;
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
        var parametersContainer = new GameObject();
        parametersContainer.name = "ParametersContainer";
        DontDestroyOnLoad(parametersContainer);

        var type = Type.GetType("Parameters");

        var player = new GameObject();
        player.name = "PlayerParameters";
        player.transform.SetParent(parametersContainer.transform);
        var playerParameters = player.AddComponent<Parameters>();
        playerParameters.SetParameters(playerInputPanel.GetOptions());

        var enemy = new GameObject();
        enemy.name = "EnemyParameters";
        enemy.transform.SetParent(parametersContainer.transform);
        var enemyParameters = enemy.AddComponent<Parameters>();
        enemyParameters.SetParameters(enemyInputPanel.GetOptions());

        SceneManager.LoadScene(1);
    }
}
