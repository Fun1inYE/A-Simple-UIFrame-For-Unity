using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI的名字
/// </summary>
public class UIType
{
    /// <summary>
    /// UI的名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// UI的路径
    /// </summary>
    public string Path { get; private set; }

    /// <summary>
    /// UIType的构造函数
    /// </summary>
    /// <param name="path">UI的路径</param>
    public UIType(string path)
    {
        Path = path;
        Name = path.Substring(path.LastIndexOf('/') + 1);
    }
}
