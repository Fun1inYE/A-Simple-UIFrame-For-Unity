using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : SceneState
{
    /// <summary>
    /// ����������
    /// </summary>
    private readonly string sceneName = "MainScene";

    PanelManager panelManager;

    public override void OnEnter()
    {
        //panelManager��ʼ��
        panelManager = new PanelManager();

        //�����ǰ��������MainScene���ͼ��ص�MainScene��
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
    /// ����������Ϻ�ִ�еķ���
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new MainPanel());
        Debug.Log($"{sceneName}����������ϣ�");
    }
}
