using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public static readonly string path = "Prefab/UI/Panel/SettingPanel";

    public SettingPanel() : base(new UIType(path)) { }

    //÷ÿ–¥≤ø∑÷
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("ExitBtn").onClick.AddListener(() =>
        {
            PanelManager.Pop();
        });
    }
}
