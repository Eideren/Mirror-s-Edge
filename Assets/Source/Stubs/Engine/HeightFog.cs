namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class HeightFog : Info/*
		placeable
		hidecategories(Navigation,Collision)*/{
	public/*()*/ /*const editconst export editinline */HeightFogComponent Component;
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
	
	public HeightFog()
	{
		// Object Offset:0x0033DE96
		Component = LoadAsset<HeightFogComponent>("Default__HeightFog.HeightFogComponent0")/*Ref HeightFogComponent'Default__HeightFog.HeightFogComponent0'*/;
		bNoDelete = true;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__HeightFog.Sprite")/*Ref SpriteComponent'Default__HeightFog.Sprite'*/,
			LoadAsset<HeightFogComponent>("Default__HeightFog.HeightFogComponent0")/*Ref HeightFogComponent'Default__HeightFog.HeightFogComponent0'*/,
		};
	}
}
}