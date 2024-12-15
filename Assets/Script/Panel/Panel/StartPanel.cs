using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 主菜单的Panel
/// </summary>
public class StartPanel : BasePanel
{
    /// <summary>
    /// 重写构造函数
    /// </summary>
    public StartPanel() : base("StartPanel") { }

    /// <summary>
    /// 重写进入方法
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        FindAndMoveObject.FindChildRecursive(activePanel.transform, "Button").GetComponent<Button>().onClick.AddListener(() => 
        {
            panelManager.Push(new AnotherPanel());
        });
         
    }

    public override void OnExit()
    {
        //重写退出方法
    }
}
