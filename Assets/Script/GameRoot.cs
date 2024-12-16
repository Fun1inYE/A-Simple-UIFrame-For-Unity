using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ȫ�ֵ�һЩ����������ģʽ��
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }

    /// <summary>
    /// ����������
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }

    private void Awake()
    {
        //��ʼ������ģʽ
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        //��ʼ��SceneSystem
        SceneSystem = new SceneSystem();

        //��GameObject����DontDestroyOnLoad����ֹת������ʱ��ɾ��
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }
}

