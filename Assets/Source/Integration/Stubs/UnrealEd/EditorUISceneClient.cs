namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EditorUISceneClient : UISceneClient/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	[Const, transient] public UIScene Scene;
	[Const, transient] public UISceneManager SceneManager;
	[native, Const, transient] public Object.Pointer SceneWindow;
	[native, Const, transient] public Object.Pointer ClientCanvasScene;
	[Const, transient] public bool bIsUIPrimitiveSceneInitialized;
	
	public virtual /*exec function */void ShowDockingStacks()
	{
		// stub
	}
	
}
}