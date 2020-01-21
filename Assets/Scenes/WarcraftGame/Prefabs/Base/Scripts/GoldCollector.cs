using UnityEngine;

public class GoldCollector : ResourcesCollector
{
    [SerializeField] private int unitPrice = 10;
    [SerializeField] private int gold;

    private BaseInfo myBase;

    private void OnEnable()
    {
        myBase = GetComponent<BaseInfo>();
        onResourceCollect += CollectGold;
    }

    public override void UpdateCollectPerSecond(float value)
    {
        base.UpdateCollectPerSecond(value);
        if (myBase == null) myBase = GetComponent<BaseInfo>();
        myBase.GetPanelSideValues().UpdateGold(gold.ToString());
        myBase.GetPanelSideValues().UpdateGPM(collectPerSecond.ToString());
    }

    private void OnDisable()
    {
        onResourceCollect -= CollectGold;
    }

    private void CollectGold()
    {
        gold++;
        myBase.GetPanelSideValues().UpdateGold(gold.ToString());
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
        gold -= unitPrice;
        Debug.Log("unit is ready");
    }
}
