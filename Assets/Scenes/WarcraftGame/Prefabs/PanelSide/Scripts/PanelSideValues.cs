using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSideValues : MonoBehaviour
{
    [SerializeField] private Text gold = null;
    [SerializeField] private Text lumber = null;
    [SerializeField] private Text unitLimit = null;
    [SerializeField] private Text stage = null;
    [SerializeField] private Text gpm = null;
    [SerializeField] private Text lpm = null;

    public void UpdateGold(string value) => gold.text = value;
    public void UpdateLumber(string value) => lumber.text = value;
    public void UpdateUnitLimit(string value) => unitLimit.text = value;
    public void UpdateStage(string value) => stage.text = value;
    public void UpdateGPM(string value) => gpm.text = value;
    public void UpdateLPM(string value) => lpm.text = value;
}
