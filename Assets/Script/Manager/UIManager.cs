using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI管理器
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// UI要生成在的Canvas
    /// </summary>
    public GameObject canvas;
    /// <summary>
    /// 等待初始化的UI的List(在这里的UI全部都是单个窗体，数量默认为1个)
    /// </summary>
    public List<PanelInfo> waitInitPanelList;
    /// <summary>
    /// 需要初始化的特殊UI（常常是因为数量不是1，例如可以初始化存档界面的存档块的UI）
    /// </summary>
    public List<PanelInfo> waitInitSpecialPanelList;

    /// <summary>
    /// 创建PanelManager实例
    /// </summary>
    private PanelManager panelManager;

    /// <summary>
    /// UIManager的单例
    /// </summary>
    public static UIManager Instance;

    /// <summary>
    /// 脚本的初始化
    /// </summary>
    private void Awake()
    {
        //单例初始化
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        panelManager = new PanelManager();
    }

    /// <summary>
    /// 初始化UIDic
    /// </summary>
    public void InitUI()
    {
        if(canvas == null)
        {
            Debug.LogError("UIcanvas是空的！请检查Hierarchy窗口是否绑定了UICanvas！");
            return;
        }
        if(waitInitSpecialPanelList == null || waitInitPanelList.Count == 0)
        {
            Debug.LogWarning("waitInitPanelList是空的");
        }
        else
        {
            //遍历待初始化的UI列表
            foreach(PanelInfo panelInfo in waitInitPanelList)
            {
                //从遍历到的panelInfo中提取GameObject，需要生成的数量，需要在哪里生成
                PoolManager.Instance.CreatGameObjectPool(panelInfo.panelGameObject, panelInfo.amount, canvas.name);
            }
        }
        if(waitInitSpecialPanelList == null || waitInitSpecialPanelList.Count == 0)
        {
            Debug.LogWarning("waitInitSpecialPanelList是空的");
        }
        else
        {
            //初始化特殊UI的方法
            foreach(PanelInfo panelInfo in waitInitSpecialPanelList)
            {
                PoolManager.Instance.CreatGameObjectPool(panelInfo.panelGameObject, panelInfo.amount, canvas.name);
            }
        }

    }

    /// <summary>
    /// 压入第一个脚本的方法
    /// </summary>
    public void PushFirstPanel(BasePanel firstPanel)
    {
        panelManager.Push(firstPanel);
    }

    /// <summary>
    /// 每帧执行当前活跃的窗口
    /// </summary>
    public void Update()
    {
        panelManager.OnUpdate();
    }

    /// <summary>
    /// 返回并且显示对应名字的UI
    /// </summary>
    /// <param name="name"></param>
    public GameObject GetAndDisPlayPoolUI(string name)
    {
        GameObject obj = PoolManager.Instance.GetGameObjectFromPool(name);
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// 关闭UI的代码
    /// </summary>
    /// <param name="obj"></param>
    public void HideUI(GameObject obj)
    {
        PoolManager.Instance.ReturnGameObjectToPool(obj);
        obj.SetActive(false);
    }
}
