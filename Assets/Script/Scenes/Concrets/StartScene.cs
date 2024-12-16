using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��ʼ�����Ĺ���
/// </summary>
public class StartScene : SceneState
{
    /// <summary>
    /// ����������
    /// </summary>
    private readonly string sceneName = "Start";

    PanelManager panelManager;

    public override void OnEnter()
    {
        //panelManager��ʼ��
        panelManager = new PanelManager();

        //�����ǰ��������Start���ͼ��ص�Start��
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
    /// ����������Ϻ�ִ�еķ���
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new StartPanel());
        Debug.Log($"{sceneName}����������ϣ�");
    }
}
