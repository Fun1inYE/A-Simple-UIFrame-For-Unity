using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private PanelManager panelManager;
    private void Awake()
    {
        panelManager = new PanelManager();
    }

    private void Start()
    {
        panelManager.Push(new StartPanel());
    }
}
