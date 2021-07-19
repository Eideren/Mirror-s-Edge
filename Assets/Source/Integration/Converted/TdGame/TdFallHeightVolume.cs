namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdFallHeightVolume : TdMovementVolume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display,AI,Interaction,PhysicsVolume,Volume)*/{
	[Category] public float FallHeightOffset;
	
	public override Touch_del Touch { get => bfield_Touch ?? TdFallHeightVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdFallHeightVolume_Touch;
	public /*simulated event */void TdFallHeightVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		/*local */TdPawn TdP = default;
	
		/*Transformed 'base.' to specific call*/PhysicsVolume_Touch(Other, OtherComp, HitLocation, HitNormal);
		TdP = ((Other) as TdPawn);
		if(TdP != default)
		{
			TdP.EnterFallingHeight = Center.Z + FallHeightOffset;
			TdP.Moves[((int)TdP.MovementState)].TouchedFallHeightVolume();
		}
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public TdFallHeightVolume()
	{
		var Default__TdFallHeightVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdFallHeightVolume.BrushComponent0' */;
		var Default__TdFallHeightVolume_MovementMesh = new TdMoveVolumeRenderComponent
		{
		}/* Reference: TdMoveVolumeRenderComponent'Default__TdFallHeightVolume.MovementMesh' */;
		// Object Offset:0x005454BD
		BrushComponent = Default__TdFallHeightVolume_BrushComponent0/*Ref BrushComponent'Default__TdFallHeightVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdFallHeightVolume_BrushComponent0/*Ref BrushComponent'Default__TdFallHeightVolume.BrushComponent0'*/,
			Default__TdFallHeightVolume_MovementMesh/*Ref TdMoveVolumeRenderComponent'Default__TdFallHeightVolume.MovementMesh'*/,
		};
		CollisionComponent = Default__TdFallHeightVolume_BrushComponent0/*Ref BrushComponent'Default__TdFallHeightVolume.BrushComponent0'*/;
	}
}
}