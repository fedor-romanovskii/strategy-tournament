public class LumberCollector : ResourcesCollector, ISidePanelChangeable, IParameterable
{
    private int lumber;
    private int upgradePrice;
    private int stage = 1;
    private int maxStage = 3;

    private PanelSideValues panelSideValues;
    private UnitSpawner unitSpawner;

    public void SetupWithParameters(Parameters parameters)
    {
        UpdateCollectPerSecond(parameters.lumberSpeed);
        UpdateUpgradePrice(parameters.upgradePrice);
    }

    public void SetupSidePanel(PanelSideValues reference)
    {
        panelSideValues = reference;
        panelSideValues.UpdateLumber(lumber.ToString());
        panelSideValues.UpdateLPM(collectPerSecond.ToString());
        panelSideValues.UpdateStage(stage.ToString());
    }

    private void UpdateUpgradePrice(int value) => upgradePrice = value;

    private void OnEnable()
    {
        unitSpawner = GetComponent<UnitSpawner>();
        UpdateUnitSpawnerLimit();
        onResourceCollect += CollectLumber;
    }

    private void OnDisable()
    {
        onResourceCollect -= CollectLumber;
    }

    private void CollectLumber()
    {
        lumber++;
        panelSideValues.UpdateLumber(lumber.ToString());
        UpgradeCheck();
    }

    private void UpgradeCheck()
    {
        bool MaxStageIsNotReached = stage < maxStage;
        if (!MaxStageIsNotReached) return;

        bool enoughLumberForUpgrade = lumber >= upgradePrice;
        if (enoughLumberForUpgrade)
        {
            lumber -= upgradePrice;
            panelSideValues.UpdateLumber(lumber.ToString());
            UpgradeStage();
        }
    }

    private void UpgradeStage()
    {
        stage++;
        panelSideValues.UpdateStage(stage.ToString());
        upgradePrice += 5;
        UpdateUnitSpawnerLimit();
        unitSpawner.UpdatePanelSideValues();
    }

    private void UpdateUnitSpawnerLimit()
    {
        unitSpawner.UpdateUnitsLimit(stage * 5);
    }
}
