using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �洢����UI����Ϣ�����ҿ���ʵ�ִ�������ʱ����UI
/// </summary>
public class UIManager
{
    /// <summary>
    /// �洢����UI����Ϣ
    /// </summary>
    private Dictionary<UIType, GameObject> dicUI;

    //��ʼ���ֵ�
    public UIManager()
    {
        dicUI = new Dictionary<UIType, GameObject>();
    }

    /// <summary>
    /// ��hierarchy�����������µ�UI
    /// </summary>
    /// <param name="type">UI��Ϣ</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        //����hierarchy���Ƿ���Canvas
        GameObject parent = GameObject.Find("Canvas");
        if(!parent)
        {
            Debug.LogError("����������Ϊ��Canvas����Canvas������ϸ����hierarchy����");
            return null;
        }

        //������ж�Ӧ��Key
        if(dicUI.ContainsKey(type))
        {
            return dicUI[type];
        }

        //��hierarchy�����д����µ�ui
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        //�����µ�UI����
        ui.name = type.Name;
        //������ui֮����ӵ��ֵ��н��м�¼
        dicUI.Add(type, ui);
        return ui;
    }

    /// <summary>
    /// ����һ��UI����
    /// </summary>
    /// <param name="type">UI��Ϣ</param>
    public void DestroyUI(UIType type)
    {
        if(dicUI.ContainsKey(type))
        {
            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }

    /// <summary>
    /// ��ѯUIManager���м���key
    /// </summary>
    public void InquireDicCount()
    {
        foreach(UIType key in dicUI.Keys)
        {
            Debug.Log(key.Name);
        }
    }
}
