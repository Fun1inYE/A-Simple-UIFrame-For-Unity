using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ʼ�����
/// </summary>
public class StartPanel : BasePanel
{
    public static readonly string path = "Prefab/UI/Panel/StartPanel";

    public StartPanel() : base(new UIType(path)) { }

    //��д����
    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("SettingBtn").onClick.AddListener(() =>
        {
            Debug.Log("SettingButton�������");
            PanelManager.Push(new SettingPanel());
        });

        //��ת����Ϸ����֮��
        UITool.GetOrAddComponentInChildren<Button>("NewGameBtn").onClick.AddListener(() =>
        {
            Debug.Log("NewGameButton�������");
            GameRoot.Instance.SceneSystem.SetScene(new MainScene());
        });

    }
}
