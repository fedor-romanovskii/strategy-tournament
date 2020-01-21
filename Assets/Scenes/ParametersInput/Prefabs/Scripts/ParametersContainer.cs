using UnityEngine;

public class ParametersContainer : MonoBehaviour
{
    public static ParametersContainer instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public Parameters PlayerParameters { get; private set; }
    public Parameters EnemyParameters { get; private set; }

    public void SetParametersContainer(Parameters player, Parameters enemy)
    {
        PlayerParameters = player;
        EnemyParameters = enemy;
    }
}
