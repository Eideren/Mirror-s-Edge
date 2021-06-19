namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_EOR : TdUIScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel TimeUntilRestartLabel;
	public /*transient */UILabel WinningTeamLabel;
	public /*transient */UILabel WinConditionLabel;
	public /*transient */TdUIDrawPlayersPanel PlayersPanel;
	public /*transient */UILabel RoundCountLabel;
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void UpdateRoundTimer(TdGameReplicationInfo GRI, TdPlayerReplicationInfo Winner)
	{
	
	}
	
	public virtual /*function */void UpdateRoundScore(TdGameReplicationInfo GRI, TdPlayerReplicationInfo Winner)
	{
	
	}
	
	public virtual /*function */void PlayersPanel_OnPlayerSlotClicked(TdPlayerReplicationInfo TdPRI)
	{
	
	}
	
	public virtual /*function */void OnCompare()
	{
	
	}
	
	public TdUIScene_EOR()
	{
		var Default__TdUIScene_EOR_SceneEventComponent = new UIComp_Event
		{
		}/* Reference: UIComp_Event'Default__TdUIScene_EOR.SceneEventComponent' */;
		// Object Offset:0x00698884
		EventProvider = Default__TdUIScene_EOR_SceneEventComponent/*Ref UIComp_Event'Default__TdUIScene_EOR.SceneEventComponent'*/;
	}
}
}