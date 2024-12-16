using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI������
/// </summary>
public class UIType
{
    /// <summary>
    /// UI������
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// UI��·��
    /// </summary>
    public string Path { get; private set; }

    /// <summary>
    /// UIType�Ĺ��캯��
    /// </summary>
    /// <param name="path">UI��·��</param>
    public UIType(string path)
    {
        Path = path;
        Name = path.Substring(path.LastIndexOf('/') + 1);
    }
}
