using UnityEngine;

public class BaseInfo : MonoBehaviour
{
    [SerializeField] private PanelSideValues panelSideValues = null;

    public int HP { get; private set; }
    public int Damage { get; private set; }

    private int maxHP;

    public enum BaseSide
    {
        player,
        enemy,
        neutral
    }

    public BaseSide baseSide = BaseSide.player;

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
        Damage = parameters.baseDamage;
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

    private bool wasHit;
    [SerializeField] private GameObject healthBarPrefab = null;
    private GameObject healthBarGameObject;
    private HealthBar healthBar;

    public void SetDamage(int damageToTake)
    {
        if (!wasHit)
        {
            wasHit = true;
            // Create health bar
            var offset = new Vector3();

            if (baseSide == BaseSide.player) offset = new Vector3(0f, -3f);
            else offset = new Vector3(0f, 3f);

            healthBarGameObject = Instantiate(healthBarPrefab, transform.position + offset,
                Quaternion.identity, transform);
            healthBar = healthBarGameObject.GetComponent<HealthBar>();
            healthBar.SetOneUnitHealth(HP);
            healthBar.SetHealth(HP);
        }
        HP -= damageToTake;
        healthBar.SetDamage(damageToTake);
        if (HP <= 0)
        {
            Debug.LogWarning("LOSE:" + baseSide);
        }
    }
}
