namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class GenericBrowserType_UIScene : GenericBrowserType/*
		native
		hidecategories(Object,GenericBrowserType)*/{
	[Const, transient] public UISceneManager SceneManager;
	
	public GenericBrowserType_UIScene()
	{
		// Object Offset:0x000234A1
		Description = "UI Scenes";
	}
}
}