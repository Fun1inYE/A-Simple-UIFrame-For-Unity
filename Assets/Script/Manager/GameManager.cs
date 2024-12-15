using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

/// <summary>
/// 游戏管理器
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 脚本初始化
    /// </summary>
    private void Start()
    {
        InitGameUI();
    }

    //初始化游戏的UI
    public void InitGameUI()
    {
        UIManager.Instance.InitUI();
        UIManager.Instance.PushFirstPanel(new StartPanel());
    }
}
