using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : SceneState
{
    /// <summary>
    /// 场景的名字
    /// </summary>
    private readonly string sceneName = "MainScene";

    PanelManager panelManager;

    public override void OnEnter()
    {
        //panelManager初始化
        panelManager = new PanelManager();

        //如果当前场景不是MainScene，就加载到MainScene中
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);

            SceneManager.sceneLoaded += SceneLoaded;
        }
        else
        {
            
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
        panelManager.Push(new MainPanel());
        Debug.Log($"{sceneName}场景加载完毕！");
    }
}
