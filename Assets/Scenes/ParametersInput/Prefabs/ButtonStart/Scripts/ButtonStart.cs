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
        var player = new GameObject();
        player.name = "PlayerParameters";
        var playerParameters = player.AddComponent<Parameters>();
        playerParameters.SetParameters(playerInputPanel.GetOptions());

        var enemy = new GameObject();
        enemy.name = "EnemyParameters";
        var enemyParameters = enemy.AddComponent<Parameters>();
        enemyParameters.SetParameters(enemyInputPanel.GetOptions());

        var parametersContainerGameObject = new GameObject();
        parametersContainerGameObject.name = "ParametersContainer";
        player.transform.SetParent(parametersContainerGameObject.transform);
        enemy.transform.SetParent(parametersContainerGameObject.transform);
        DontDestroyOnLoad(parametersContainerGameObject);
        var parametersContainer = parametersContainerGameObject.AddComponent<ParametersContainer>();
        parametersContainer.SetParametersContainer(playerParameters, enemyParameters);

        SceneManager.LoadScene(1);
    }
}
