namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdTriggerSplashHint : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ int HintNumber;
	public /*private */TdGameUISceneClient SceneClient;
	public /*private */LocalPlayer Player;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public virtual /*private final function */void OnHintSceneClosed(UIScene ClosedScene)
	{
		// stub
	}
	
	public virtual /*private final function */void OpenNextHintScene()
	{
		// stub
	}
	
	public virtual /*private final function */void OnHintSceneOpened(UIScene OpenedScene, bool bInitialActivation)
	{
		// stub
	}
	
	public virtual /*function */LocalPlayer GetFirstLocalPlayer()
	{
		// stub
		return default;
	}
	
	public SeqAct_TdTriggerSplashHint()
	{
		// Object Offset:0x004A31AF
		OutputLinks = default;
		VariableLinks = default;
		ObjName = "Splash Hint";
		ObjCategory = "Takedown";
	}
}
}