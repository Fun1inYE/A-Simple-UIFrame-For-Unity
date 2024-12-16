using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有Panel的父类
/// </summary>
public class BasePanel
{
    /// <summary>
    /// UI信息
    /// </summary>
    public UIType UIType { get; private set; }

    /// <summary>
    /// UI管理工具
    /// </summary>
    public UITool UITool { get; private set; }

    /// <summary>
    /// 面板管理器
    /// </summary>  
    public PanelManager PanelManager { get; private set; }

    /// <summary>
    /// UI管理器
    /// </summary>
    public UIManager UIManager { get; private set; }


    public BasePanel(UIType uIType)
    {
        UIType = uIType;
    }

    /// <summary>
    /// 初始化UI工具类
    /// </summary>
    public void Initialize(UITool tool)
    {
        UITool = tool;
    }

    /// <summary>
    /// 初始化面板管理器
    /// </summary>
    public void Initialize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }

    /// <summary>
    /// 初始化UI管理器
    /// </summary>
    /// <param name="uiManager"></param>
    public void Initialize(UIManager uiManager)
    {
        UIManager = uiManager;
    }

    /// <summary>
    /// 进入UI的方法
    /// </summary>
    public virtual void OnEnter() { }
    /// <summary>
    /// UI暂停时的方法
    /// </summary>
    public virtual void OnPause() 
    {
        //给GameObject添加CanvasGroup组件然后将其中的射线检测关闭
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }
    /// <summary>
    /// UI继续的方法
    /// </summary>
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }
    /// <summary>
    /// UI退出的方法
    /// </summary>
    public virtual void OnExit() 
    {
        UIManager.DestroyUI(UIType);
    }
}
