using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 开始主面板
/// </summary>
public class StartPanel : BasePanel
{
    public static readonly string path = "Prefab/UI/Panel/StartPanel";

    public StartPanel() : base(new UIType(path)) { }

    //重写部分
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("SettingBtn").onClick.AddListener(() =>
        {
            Debug.Log("SettingButton被点击了");
            PanelManager.Push(new SettingPanel());
        });

        //跳转到游戏场景之中
        UITool.GetOrAddComponentInChildren<Button>("NewGameBtn").onClick.AddListener(() =>
        {
            Debug.Log("NewGameButton被点击了");
            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
        });

    }
}
