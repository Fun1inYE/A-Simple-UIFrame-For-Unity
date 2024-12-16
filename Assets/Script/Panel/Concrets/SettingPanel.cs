using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public static readonly string path = "Prefab/UI/Panel/SettingPanel";

    public SettingPanel() : base(new UIType(path)) { }

    //��д����
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("ExitBtn").onClick.AddListener(() =>
        {
            PanelManager.Pop();
        });
    }
}
