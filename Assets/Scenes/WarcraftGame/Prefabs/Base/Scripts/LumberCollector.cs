using System.Collections.Generic;
using UnityEngine;

public class LumberCollector : ResourcesCollector
{
    [SerializeField] private List<int> upgradePrices = new List<int>();
    [SerializeField] private int lumber;

    private BaseInfo myBase;

    private void OnEnable()
    {
        myBase = GetComponent<BaseInfo>();
        onResourceCollect += CollectLumber;
    }

    public override void UpdateCollectPerSecond(float value)
    {
        base.UpdateCollectPerSecond(value);
        if (myBase == null) myBase = GetComponent<BaseInfo>();
        myBase.GetPanelSideValues().UpdateLumber(lumber.ToString());
        myBase.GetPanelSideValues().UpdateLPM(collectPerSecond.ToString());
    }

    private void OnDisable()
    {
        onResourceCollect -= CollectLumber;
    }

    private void CollectLumber()
    {
        lumber++;
        myBase.GetPanelSideValues().UpdateLumber(lumber.ToString());
        UpgradeCheck();
    }

    private void UpgradeCheck()
    {
        bool MaxStageIsNotReached = myBase.Stage < upgradePrices.Count;
        if (!MaxStageIsNotReached) return;

        bool enoughLumberForUpgrade = lumber > upgradePrices[myBase.Stage];
        if (enoughLumberForUpgrade)
        {
            lumber -= upgradePrices[myBase.Stage];
            myBase.UpgradeStage();
        }
    }
}
