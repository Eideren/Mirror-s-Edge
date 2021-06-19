namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class FogVolumeDensityInfo : Info/*
		abstract
		native
		notplaceable
		hidecategories(Navigation,Collision)*/{
	public/*()*/ /*const export editinline */FogVolumeDensityComponent DensityComponent;
	public /*repnotify */bool bEnabled;
	
	//replication
	//{
	//	 if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		bEnabled;
	//}
	
	public override /*event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
	
	}
	
	public virtual /*simulated function */void OnToggle(SeqAct_Toggle Action)
	{
	
	}
	
	public FogVolumeDensityInfo()
	{
		var Default__FogVolumeDensityInfo_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__FogVolumeDensityInfo.Sprite' */;
		// Object Offset:0x0031E475
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__FogVolumeDensityInfo_Sprite/*Ref SpriteComponent'Default__FogVolumeDensityInfo.Sprite'*/,
		};
	}
}
}