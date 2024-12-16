using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    public static readonly string path = "Prefab/UI/Panel/MainPanel";

    public MainPanel() : base(new UIType(path)) { }

    //��д����
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("ExitBtn").onClick.AddListener(() =>
        {
            Debug.Log("ExitBtn�������");
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
            //��stackPanel�е���MainPanel
            PanelManager.Pop();
        });

    }
}
