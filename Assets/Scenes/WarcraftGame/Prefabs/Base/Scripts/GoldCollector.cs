public class GoldCollector : ResourcesCollector, IParameterable, ISidePanelChangeable
{
    private int gold;
    private int unitPrice;

    private UnitSpawner unitSpawner;
    private PanelSideValues panelSideValues;

    public void SetupWithParameters(Parameters parameters)
    {
        UpdateCollectPerSecond(parameters.goldSpeed);
        UpdateUnitPrice(parameters.unitPrice);
    }

    public void SetupSidePanel(PanelSideValues reference)
    {
        panelSideValues = reference;
        panelSideValues.UpdateGold(gold.ToString());
        panelSideValues.UpdateGPM(collectPerSecond.ToString());
    }

    public void SetPanelSideValuesReference(PanelSideValues reference)
    {
        panelSideValues = reference;
        panelSideValues.UpdateGold(gold.ToString());
        panelSideValues.UpdateGPM(collectPerSecond.ToString());
    }

    private void UpdateUnitPrice(int value) => unitPrice = value;

    private void OnEnable()
    {
        unitSpawner = GetComponent<UnitSpawner>();
        onResourceCollect += CollectGold;
    }

    private void OnDisable()
    {
        onResourceCollect -= CollectGold;
    }

    private void CollectGold()
    {
        gold++;
        panelSideValues.UpdateGold(gold.ToString());
        UnitBuingCheck();
    }

    private void UnitBuingCheck()
    {
        bool enoughGoldForBuing = gold >= unitPrice;
        if (enoughGoldForBuing)
            BuyUnit();
    }

    private void BuyUnit()
    {
        panelSideValues.UpdateGold(gold.ToString());
        unitSpawner.SpawnUnit(OnUnitBuy);
    }

    private void OnUnitBuy(bool success)
    {
        if (success) gold -= unitPrice;
    }
}
