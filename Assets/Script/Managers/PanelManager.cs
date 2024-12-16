using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 面板管理器，用栈来存储UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// 存储面板的栈
    /// </summary>
    private Stack<BasePanel> stackPanel;
    /// <summary>
    /// UI管理器
    /// </summary>
    private UIManager uiManager;
    private BasePanel panel;

    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uiManager = new UIManager();
    }

    /// <summary>
    /// UI的入栈操作，此操作会显示一个面板
    /// </summary>
    /// <param name="nextPanel">下一个面板</param>
    public void Push(BasePanel nextPanel)
    {
        if(stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }

        stackPanel.Push(nextPanel);

        //显示当前UI，并且记录这个panel
        GameObject displayPanel = uiManager.GetSingleUI(nextPanel.UIType);
        //给当前UI（panel）初始化UITool
        nextPanel.Initialize(new UITool(displayPanel));
        //给当前UI（panel）初始化PanelManager
        nextPanel.Initialize(this);
        //给当前UI（panel）初始化UIManager
        nextPanel.Initialize(uiManager);
        //给当前UI（panel）初始化
        nextPanel.OnEnter();
    }

    /// <summary>
    /// 退出当前面板,此方法会调用面板的OnExit方法
    /// </summary>
    public void Pop()
    {
        //退出当前UI
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnExit();
            stackPanel.Pop();
        }
        //恢复后一个UI的状态
        if(stackPanel.Count > 0)
            stackPanel.Peek().OnResume();
    }

    /// <summary>
    /// 执行所有面板的OnExit方法
    /// </summary>
    public void AllPop()
    {
        while(stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
    }
}
