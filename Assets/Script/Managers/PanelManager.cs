using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������ջ���洢UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// �洢����ջ
    /// </summary>
    private Stack<BasePanel> stackPanel;
    /// <summary>
    /// UI������
    /// </summary>
    private UIManager uiManager;
    private BasePanel panel;

    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uiManager = new UIManager();
    }

    /// <summary>
    /// UI����ջ�������˲�������ʾһ�����
    /// </summary>
    /// <param name="nextPanel">��һ�����</param>
    public void Push(BasePanel nextPanel)
    {
        if(stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }

        stackPanel.Push(nextPanel);

        //��ʾ��ǰUI�����Ҽ�¼���panel
        GameObject displayPanel = uiManager.GetSingleUI(nextPanel.UIType);
        //����ǰUI��panel����ʼ��UITool
        nextPanel.Initialize(new UITool(displayPanel));
        //����ǰUI��panel����ʼ��PanelManager
        nextPanel.Initialize(this);
        //����ǰUI��panel����ʼ��UIManager
        nextPanel.Initialize(uiManager);
        //����ǰUI��panel����ʼ��
        nextPanel.OnEnter();
    }

    /// <summary>
    /// �˳���ǰ���,�˷������������OnExit����
    /// </summary>
    public void Pop()
    {
        //�˳���ǰUI
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnExit();
            stackPanel.Pop();
        }
        //�ָ���һ��UI��״̬
        if(stackPanel.Count > 0)
            stackPanel.Peek().OnResume();
    }

    /// <summary>
    /// ִ����������OnExit����
    /// </summary>
    public void AllPop()
    {
        while(stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
    }
}
