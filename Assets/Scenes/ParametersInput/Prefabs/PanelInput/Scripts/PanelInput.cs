using System.Collections.Generic;
using UnityEngine;

public class PanelInput : MonoBehaviour
{ 
    private PanelOption[] optionPanels;

    private void OnEnable()
    {
        optionPanels = GetComponentsInChildren<PanelOption>();
    }

    public Dictionary<PanelOption.OptionType,string> GetOptions()
    {
        var options = new Dictionary<PanelOption.OptionType, string>();

        foreach(PanelOption po in optionPanels)
        {
            if (string.IsNullOrEmpty(po.optionValue)) po.optionValue = "0";
            options.Add(po.optionType, po.optionValue);
        }

        return options;
    }
}
