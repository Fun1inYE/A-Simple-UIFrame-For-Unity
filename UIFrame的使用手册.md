# 这是什么？
这是一个简易的UI框架，使用了类似于栈结构来模拟UI打开和关闭的类似结构和逻辑，因为构造简单，所以易于扩展和重构。

# 使用方法
## UIManager.cs
	1. 首先在Hierarchy窗口中创建一个空节点用于挂载UIManager.cs
	2. 在实例中我挂好了两个UI的Prefab，这里是可以自己挂载创建的UI面板
	3. 下一个属性是canvas，可以手动拖入canvas或者使用代码控制（具体在UIManager.cs中）
## 如何初始化
	1.首先要调用UIManager.cs中的InitUI方法
	2.然后初始化UIManager中的canvas，具体调用UIManager.cs中的SetCanvas方法
	3.然后就可以压入第一个panel了
```cs
	UIManager.Instance.InitUI();
	UIManager.Instance.SetCanvas(mainCanvas);
	UIManager.Instance.GetPanelManager().PushFirstPanel(new StartPanel());
```

# 如何创建新的UI并且使用呢
	1.首先要在合适的canvas下创建一个UI，然后命好名字兵器将其制成Prefab，然后将其拖入UIManager中的panelList。
	2.创建与UI名字相同的脚本（其他名字也行，只要是好记），让其继承与BasePanel.cs.
	3.先重写BasePanel中的构造方法，名字一定要和自己创建的UI的Prefab名字相同，因为这个框架是靠UI的名字进行寻找对应UI的。BasePanel中有各种UI处于什么阶段的重写方法可供使用，PanelManager中也有各种方法可以控制UI的开关的方法，下面简单介绍两个：
```cs
	PanelManager.Pop() //弹出当前窗口
	PanelManager.Push(BasePanel nextPanel) //打开当前窗口
```

# 自己创建的UI例子
	StartPanel.cs:
```cs
using UnityEngine.UI;
/// <summary>
/// 主菜单的Panel
/// </summary>
public class StartPanel : BasePanel
{
	/// <summary>
	/// 重写构造函数
	/// </summary>
	public StartPanel() : base("StartPanel") { }
	/// <summary>
	/// 重写进入方法
	/// </summary>
	public override void OnEnter()
	{
		//执行窗口进入的父类方法
		base.OnEnter();
		//绑定一个按钮监听器，按下就能打开Another窗口,FindAndMoveObject是我自己写的方法，主要用于寻找Hierarchy窗口中的节点
		FindAndMoveObject.FindChildRecursive(activePanel.transform, "Button").GetComponent<Button>().onClick.AddListener(() =>
		{
			panelManager.Push(new AnotherPanel());
		});
	}
}
```