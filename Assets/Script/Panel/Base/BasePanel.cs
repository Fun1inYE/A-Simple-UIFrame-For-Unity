using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Panel�ĸ���
/// </summary>
public class BasePanel
{
    /// <summary>
    /// UI��Ϣ
    /// </summary>
    public UIType UIType { get; private set; }

    /// <summary>
    /// UI������
    /// </summary>
    public UITool UITool { get; private set; }

    /// <summary>
    /// ��������
    /// </summary>  
    public PanelManager PanelManager { get; private set; }

    /// <summary>
    /// UI������
    /// </summary>
    public UIManager UIManager { get; private set; }


    public BasePanel(UIType uIType)
    {
        UIType = uIType;
    }

    /// <summary>
    /// ��ʼ��UI������
    /// </summary>
    public void Initialize(UITool tool)
    {
        UITool = tool;
    }

    /// <summary>
    /// ��ʼ����������
    /// </summary>
    public void Initialize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }

    /// <summary>
    /// ��ʼ��UI������
    /// </summary>
    /// <param name="uiManager"></param>
    public void Initialize(UIManager uiManager)
    {
        UIManager = uiManager;
    }

    /// <summary>
    /// ����UI�ķ���
    /// </summary>
    public virtual void OnEnter() { }
    /// <summary>
    /// UI��ͣʱ�ķ���
    /// </summary>
    public virtual void OnPause() 
    {
        //��GameObject���CanvasGroup���Ȼ�����е����߼��ر�
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }
    /// <summary>
    /// UI�����ķ���
    /// </summary>
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }
    /// <summary>
    /// UI�˳��ķ���
    /// </summary>
    public virtual void OnExit() 
    {
        UIManager.DestroyUI(UIType);
    }
}
