using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储所有UI的信息，并且可以实现创建或者时销毁UI
/// </summary>
public class UIManager
{
    /// <summary>
    /// 存储所有UI的信息
    /// </summary>
    private Dictionary<UIType, GameObject> dicUI;

    //初始化字典
    public UIManager()
    {
        dicUI = new Dictionary<UIType, GameObject>();
    }

    /// <summary>
    /// 在hierarchy窗口上生成新的UI
    /// </summary>
    /// <param name="type">UI信息</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        //查找hierarchy中是否有Canvas
        GameObject parent = GameObject.Find("Canvas");
        if(!parent)
        {
            Debug.LogError("不存在名字为“Canvas”的Canvas，请仔细查找hierarchy窗口");
            return null;
        }

        //如果含有对应的Key
        if(dicUI.ContainsKey(type))
        {
            return dicUI[type];
        }

        //在hierarchy窗口中创建新的ui
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        //命名新的UI名字
        ui.name = type.Name;
        //创建完ui之后添加到字典中进行记录
        dicUI.Add(type, ui);
        return ui;
    }

    /// <summary>
    /// 销毁一个UI对象
    /// </summary>
    /// <param name="type">UI信息</param>
    public void DestroyUI(UIType type)
    {
        if(dicUI.ContainsKey(type))
        {
            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }

    /// <summary>
    /// 查询UIManager中有几个key
    /// </summary>
    public void InquireDicCount()
    {
        foreach(UIType key in dicUI.Keys)
        {
            Debug.Log(key.Name);
        }
    }
}
