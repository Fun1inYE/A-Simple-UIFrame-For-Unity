using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理全局的一些东西（单例模式）
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }

    /// <summary>
    /// 场景管理器
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }

    private void Awake()
    {
        //初始化单例模式
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        //初始化SceneSystem
        SceneSystem = new SceneSystem();

        //将GameObject放入DontDestroyOnLoad，防止转场景的时候被删除
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }
}

