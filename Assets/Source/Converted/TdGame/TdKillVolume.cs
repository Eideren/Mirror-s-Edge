namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdKillVolume : PhysicsVolume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public/*()*/ Core.ClassT<DamageType> KillDamageType;
	public/*()*/ bool AffectPlayer;
	public/*()*/ bool AffectAI;
	
	public override /*event */void ActorEnteredVolume(Actor Other)
	{
		if(!Other.bStatic)
		{
			KillActor(Other);
		}
	}
	
	public override /*event */void PawnEnteredVolume(Pawn Other)
	{
		KillActor(Other);
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? TdKillVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdKillVolume_Touch;
	public /*simulated event */void TdKillVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		if(!Other.bStatic)
		{
			KillActor(Other);
		}
	}
	
	public virtual /*simulated event */void KillActor(Actor Other)
	{
		if(!Other.bScriptInitialized)
		{
		}
		if(((Other.IsA("TdBotPawn") && AffectAI) || Other.IsA("TdPlayerPawn") && AffectPlayer) || Other.IsA("TdBagKActor"))
		{
			Other.FellOutOfWorld(KillDamageType);
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public TdKillVolume()
	{
		var Default__TdKillVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdKillVolume.BrushComponent0' */;
		// Object Offset:0x00580C91
		KillDamageType = ClassT<TdDmgType_OutOfBounds>()/*Ref Class'TdDmgType_OutOfBounds'*/;
		AffectPlayer = true;
		AffectAI = true;
		BrushComponent = Default__TdKillVolume_BrushComponent0/*Ref BrushComponent'Default__TdKillVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdKillVolume_BrushComponent0/*Ref BrushComponent'Default__TdKillVolume.BrushComponent0'*/,
		};
		CollisionComponent = Default__TdKillVolume_BrushComponent0/*Ref BrushComponent'Default__TdKillVolume.BrushComponent0'*/;
	}
}
}