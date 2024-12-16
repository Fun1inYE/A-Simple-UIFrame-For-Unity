using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    public static readonly string path = "Prefab/UI/Panel/MainPanel";

    public MainPanel() : base(new UIType(path)) { }

    //重写部分
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("ExitBtn").onClick.AddListener(() =>
        {
            Debug.Log("ExitBtn被点击了");
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
            //在stackPanel中弹出MainPanel
            PanelManager.Pop();
        });

    }
}
