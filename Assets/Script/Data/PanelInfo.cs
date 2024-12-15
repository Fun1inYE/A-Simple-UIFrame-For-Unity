using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI的基础信息
/// </summary>
[Serializable]
public class PanelInfo
{
    /// <summary>
    /// UI的GameObject
    /// </summary>
    public GameObject panelGameObject;
    /// <summary>
    /// 生成的数量（默认为1）
    /// </summary>
    public int amount = 1;
}
