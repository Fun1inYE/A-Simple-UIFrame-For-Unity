using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 开始场景的管理
/// </summary>
public class StartScene : SceneState
{
    /// <summary>
    /// 场景的名字
    /// </summary>
    private readonly string sceneName = "Start";

    PanelManager panelManager;

    public override void OnEnter()
    {
        //panelManager初始化
        panelManager = new PanelManager();

        //如果当前场景不是Start，就加载到Start中
        if(SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);

            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            panelManager.Push(new StartPanel());
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    /// <summary>
    /// 场景加载完毕后执行的方法
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new StartPanel());
        Debug.Log($"{sceneName}场景加载完毕！");
    }
}
