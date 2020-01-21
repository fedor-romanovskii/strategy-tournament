using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberCollector : ResourcesCollector
{
    private int lumber;
    private BaseInfo myBase;
    private List<int> upgradePrices = new List<int>();

    private void OnEnable()
    {
        myBase = GetComponent<BaseInfo>();
        onResourceCollect += CollectLumber;
    }

    private void OnDisable()
    {
        onResourceCollect -= CollectLumber;
    }

    private void CollectLumber()
    {
        lumber++;
        UpgradeCheck();
    }

    private void UpgradeCheck()
    {
        if (myBase.Stage < upgradePrices.Count && lumber > upgradePrices[myBase.Stage])
        {
            lumber -= upgradePrices[myBase.Stage];
            myBase.UpgradeStage();
        }
    }
}
