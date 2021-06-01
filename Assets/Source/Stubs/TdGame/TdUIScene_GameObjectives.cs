namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUIScene_GameObjectives : TdUIScene_ObjectivesScene/*
		config(UI)
		hidecategories(Object,UIRoot,Object)*/{
	public /*transient */UILabel BagStatusLabel;
	public /*transient */UILabel NumGiveBulletDamageLabel;
	public UIDataStore_TdGameData TdGameData;
	public TdProfileSettings Profile;
	public String CurrentMap;
	
	public override /*event */void Initialized()
	{
	
	}
	
	public override /*event */void PostInitialize()
	{
	
	}
	
	public virtual /*function */void InitSceneLabels()
	{
	
	}
	
	public TdUIScene_GameObjectives()
	{
		// Object Offset:0x0069A21F
		ObjectivesToReadFieldName = (name)"Objectives";
		FinishedObjectivesToReadFieldName = (name)"FinishedObjectives";
		EventProvider = LoadAsset<UIComp_Event>("Default__TdUIScene_GameObjectives.SceneEventComponent")/*Ref UIComp_Event'Default__TdUIScene_GameObjectives.SceneEventComponent'*/;
	}
}
}