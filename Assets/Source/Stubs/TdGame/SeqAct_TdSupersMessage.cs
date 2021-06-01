namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdSupersMessage : SequenceAction/*
		hidecategories(Object)*/{
	public/*()*/ String SupersMessage;
	public/*()*/ float Duration;
	public /*private */TdGameUISceneClient SceneClient;
	public /*private */LocalPlayer Player;
	
	public override /*event */void Activated()
	{
	
	}
	
	public virtual /*private final function */void OnSupersSceneClosed(UIScene ClosedScene)
	{
	
	}
	
	public virtual /*private final function */void OpenNextSupersScene()
	{
	
	}
	
	public virtual /*private final function */void OnSupersSceneOpened(UIScene OpenedScene, bool bInitialActivation)
	{
	
	}
	
	public virtual /*function */LocalPlayer GetFirstLocalPlayer()
	{
	
		return default;
	}
	
	public SeqAct_TdSupersMessage()
	{
		// Object Offset:0x004A179C
		Duration = 3.0f;
		OutputLinks = default;
		VariableLinks = default;
		ObjName = "Supers Message";
		ObjCategory = "Takedown";
	}
}
}