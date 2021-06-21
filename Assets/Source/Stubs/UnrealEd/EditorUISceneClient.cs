namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class EditorUISceneClient : UISceneClient/*
		transient
		native
		hidecategories(Object,UIRoot)*/{
	public /*const transient */UIScene Scene;
	public /*const transient */UISceneManager SceneManager;
	public /*native const transient */Object.Pointer SceneWindow;
	public /*native const transient */Object.Pointer ClientCanvasScene;
	public /*const transient */bool bIsUIPrimitiveSceneInitialized;
	
	public virtual /*exec function */void ShowDockingStacks()
	{
		// stub
	}
	
}
}