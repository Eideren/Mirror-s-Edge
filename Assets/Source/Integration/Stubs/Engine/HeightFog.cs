namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class HeightFog : Info/*
		placeable
		hidecategories(Navigation,Collision)*/{
	[Category] [Const, editconst, export, editinline] public HeightFogComponent Component;
	[repnotify] public bool bEnabled;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bEnabled;
	//}
	
	public override /*event */void PostBeginPlay()
	{
		// stub
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		// stub
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
		// stub
	}
	
	public HeightFog()
	{
		var Default__HeightFog_HeightFogComponent0 = new HeightFogComponent
		{
		}/* Reference: HeightFogComponent'Default__HeightFog.HeightFogComponent0' */;
		var Default__HeightFog_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__HeightFog.Sprite' */;
		// Object Offset:0x0033DE96
		Component = Default__HeightFog_HeightFogComponent0/*Ref HeightFogComponent'Default__HeightFog.HeightFogComponent0'*/;
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__HeightFog_Sprite/*Ref SpriteComponent'Default__HeightFog.Sprite'*/,
			Default__HeightFog_HeightFogComponent0/*Ref HeightFogComponent'Default__HeightFog.HeightFogComponent0'*/,
		};
	}
}
}