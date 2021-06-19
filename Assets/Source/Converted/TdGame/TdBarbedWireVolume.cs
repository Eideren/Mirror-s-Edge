namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBarbedWireVolume : TdMovementVolume/*
		placeable
		hidecategories(Navigation,Object,Movement,Display,AI,Interaction,PhysicsVolume,Volume)*/{
	public /*private transient */Object.Vector LatestHitLocation;
	public /*private transient */Object.Vector LatestHitNormal;
	
	public override Touch_del Touch { get => bfield_Touch ?? TdBarbedWireVolume_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdBarbedWireVolume_Touch;
	public /*simulated event */void TdBarbedWireVolume_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
		/*local */TdPlayerPawn PlayerPawn = default;
		/*local */TdMove_StumbleBase StumbleMove = default;
	
		PlayerPawn = ((Other) as TdPlayerPawn);
		if((((PlayerPawn == default) || PlayerPawn.Health <= 0) || ((int)PlayerPawn.MovementState) == ((int)TdPawn.EMovement.MOVE_Stumble/*35*/)) || !PlayerPawn.CanDoMove(TdPawn.EMovement.MOVE_Stumble/*35*/))
		{
			return;
		}
		if((PlayerPawn.WorldInfo.TimeSeconds - PlayerPawn.LastResetTimeStamp) < 0.10f)
		{
			return;
		}
		StumbleMove = ((PlayerPawn.Moves[35]) as TdMove_StumbleBase);
		StumbleMove.InstigatorLocation = HitLocation;
		StumbleMove.Instigator = default;
		StumbleMove.damageMomentum = HitNormal;
		StumbleMove.DamageLocation = HitLocation;
		StumbleMove.HitDamageType = DamageType;
		PlayerPawn.HandleMoveAction(TdPawn.EMovementAction.MA_Stumble/*17*/);
		/*Transformed 'base.' to specific call*/PhysicsVolume_Touch(Other, OtherComp, HitLocation, HitNormal);
	}
	protected override void RestoreDefaultFunction()
	{
		Touch = null;
	
	}
	public TdBarbedWireVolume()
	{
		var Default__TdBarbedWireVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdBarbedWireVolume.BrushComponent0' */;
		var Default__TdBarbedWireVolume_WallDir = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdBarbedWireVolume.WallDir' */;
		var Default__TdBarbedWireVolume_MovementMesh = new TdMoveVolumeRenderComponent
		{
		}/* Reference: TdMoveVolumeRenderComponent'Default__TdBarbedWireVolume.MovementMesh' */;
		// Object Offset:0x0050E83A
		bPainCausing = true;
		DamagePerSec = 35.0f;
		DamageType = ClassT<TdDmgType_BarbedWire>()/*Ref Class'TdDmgType_BarbedWire'*/;
		BrushComponent = Default__TdBarbedWireVolume_BrushComponent0/*Ref BrushComponent'Default__TdBarbedWireVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdBarbedWireVolume_BrushComponent0/*Ref BrushComponent'Default__TdBarbedWireVolume.BrushComponent0'*/,
			Default__TdBarbedWireVolume_WallDir/*Ref ArrowComponent'Default__TdBarbedWireVolume.WallDir'*/,
			Default__TdBarbedWireVolume_MovementMesh/*Ref TdMoveVolumeRenderComponent'Default__TdBarbedWireVolume.MovementMesh'*/,
		};
		CollisionComponent = Default__TdBarbedWireVolume_BrushComponent0/*Ref BrushComponent'Default__TdBarbedWireVolume.BrushComponent0'*/;
	}
}
}