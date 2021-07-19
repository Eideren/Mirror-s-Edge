namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdMovementVolume : PhysicsVolume/*
		abstract
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public Object.Vector FloorNormal;
	public Object.Vector WallNormal;
	public Object.Vector MoveDirection;
	public Object.Vector Start;
	public Object.Vector End;
	public/*private*/ Object.Vector Middle;
	public Object.Vector Center;
	[Category] public bool bAutoPath;
	[Category] [noimport, transient] public bool bHideSplineMarkers;
	[Category] public bool bAllowSplineControl;
	public bool bLatent;
	[noimport, Const, transient] public/*private*/ array<TdMovementSplineMarker> SplineMarkers;
	[Category] public int NumSplineSegments;
	[editoronly] public/*private*/ Object.Vector OldScale;
	[editoronly] public/*private*/ Object.Vector OldLocation;
	[editoronly] public/*private*/ Object.Rotator OldRotation;
	public float SplineLength;
	public array<Object.Vector> SplineLocations;
	
	// Export UTdMovementVolume::execGetLocationOnSpline(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetLocationOnSpline(float ParamT)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMovementVolume::execGetSlopeOnSpline(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetSlopeOnSpline(float ParamT)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UTdMovementVolume::execFindClosestPointOnDSpline(FFrame&, void* const)
	public virtual /*native function */void FindClosestPointOnDSpline(Object.Vector InLocation, ref Object.Vector ClosestLocation, ref float NParamT, /*optional */int? _LowestIndexHint = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export UTdMovementVolume::execIsSplineMarkerSelected(FFrame&, void* const)
	public virtual /*native function */bool IsSplineMarkerSelected()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		base.PostBeginPlay();
	}
	
	public virtual /*function */bool InUse(Pawn Ignored)
	{
		return false;
	}
	
	public override /*simulated event */void PawnEnteredVolume(Pawn P)
	{
		/*local */TdPawn TdP = default;
	
		if(bLatent)
		{
			TdP = ((P) as TdPawn);
			if(TdP != default)
			{
				TdP.ActiveMovementVolume = this;
			}
		}
	}
	
	public override /*simulated event */void PawnLeavingVolume(Pawn P)
	{
		/*local */TdPawn TdP = default;
	
		if(bLatent)
		{
			TdP = ((P) as TdPawn);
			if((TdP != default) && TdP.ActiveMovementVolume == this)
			{
				TdP.ActiveMovementVolume = default;
			}
		}
	}
	
	public virtual /*simulated function */void PawnUpdate(TdPawn TdP)
	{
	
	}
	
	public TdMovementVolume()
	{
		var Default__TdMovementVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__TdMovementVolume.BrushComponent0' */;
		var Default__TdMovementVolume_WallDir = new ArrowComponent
		{
			// Object Offset:0x0050E0F3
			ArrowColor = new Color
			{
				R=150,
				G=100,
				B=150,
				A=255
			},
			ArrowSize = 5.0f,
		}/* Reference: ArrowComponent'Default__TdMovementVolume.WallDir' */;
		var Default__TdMovementVolume_MovementMesh = new TdMoveVolumeRenderComponent
		{
			// Object Offset:0x0050E14B
			bUseAsOccluder = false,
			bUsePrecomputedShadows = false,
		}/* Reference: TdMoveVolumeRenderComponent'Default__TdMovementVolume.MovementMesh' */;
		// Object Offset:0x0050DEE4
		bAutoPath = true;
		bHideSplineMarkers = true;
		NumSplineSegments = 10;
		BrushComponent = Default__TdMovementVolume_BrushComponent0/*Ref BrushComponent'Default__TdMovementVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdMovementVolume_BrushComponent0/*Ref BrushComponent'Default__TdMovementVolume.BrushComponent0'*/,
			Default__TdMovementVolume_WallDir/*Ref ArrowComponent'Default__TdMovementVolume.WallDir'*/,
			Default__TdMovementVolume_MovementMesh/*Ref TdMoveVolumeRenderComponent'Default__TdMovementVolume.MovementMesh'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		CollisionComponent = Default__TdMovementVolume_BrushComponent0/*Ref BrushComponent'Default__TdMovementVolume.BrushComponent0'*/;
	}
}
}