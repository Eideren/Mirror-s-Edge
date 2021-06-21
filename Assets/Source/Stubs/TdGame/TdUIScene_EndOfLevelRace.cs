namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_EndOfLevelRace : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */OnlineSubsystem.UniqueNetId GamerCardId;
	
	public override /*function */void SetupButtonBar()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_Continue(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool OnButtonBar_Restart(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnContinue()
	{
		// stub
	}
	
	public virtual /*function */void OnRestart()
	{
		// stub
	}
	
	public virtual /*function */bool OnButtonBar_ShowGamerCard(UIScreenObject Sender, int PlayerIndex)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnShowGamerCard()
	{
		// stub
	}
	
	public override /*function */bool HandleInputKey(/*const */ref UIRoot.InputEventParameters EventParms)
	{
		// stub
		return default;
	}
	
	public TdUIScene_EndOfLevelRace()
	{
		var Default__TdUIScene_EndOfLevelRace_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_EndOfLevelRace.SceneEventComponent' */;
		// Object Offset:0x00695E41
		EventProvider = Default__TdUIScene_EndOfLevelRace_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_EndOfLevelRace.SceneEventComponent'*/;
	}
}
}