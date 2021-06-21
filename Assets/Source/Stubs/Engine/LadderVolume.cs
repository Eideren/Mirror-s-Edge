namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LadderVolume : PhysicsVolume/*
		native
		placeable
		hidecategories(Navigation,Object,Movement,Display)*/{
	public Object.Rotator WallDir;
	public Object.Vector LookDir;
	public Object.Vector ClimbDir;
	public /*const */Ladder LadderList;
	public/*()*/ bool bNoPhysicalLadder;
	public/*()*/ bool bAutoPath;
	public/*()*/ bool bAllowLadderStrafing;
	public Pawn PendingClimber;
	
	public override /*simulated event */void PostBeginPlay()
	{
		// stub
	}
	
	public virtual /*function */bool InUse(Pawn Ignored)
	{
		// stub
		return default;
	}
	
	public override /*simulated event */void PawnEnteredVolume(Pawn P)
	{
		// stub
	}
	
	public override /*simulated event */void PawnLeavingVolume(Pawn P)
	{
		// stub
	}
	
	public override /*simulated event */void PhysicsChangedFor(Actor Other)
	{
		// stub
	}
	
	public LadderVolume()
	{
		var Default__LadderVolume_BrushComponent0 = new BrushComponent
		{
		}/* Reference: BrushComponent'Default__LadderVolume.BrushComponent0' */;
		var Default__LadderVolume_Arrow = new ArrowComponent
		{
			// Object Offset:0x00465AF7
			ArrowColor = new Color
			{
				R=150,
				G=100,
				B=150,
				A=255
			},
			ArrowSize = 5.0f,
		}/* Reference: ArrowComponent'Default__LadderVolume.Arrow' */;
		// Object Offset:0x0034D091
		ClimbDir = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=1.0f
		};
		bAutoPath = true;
		bAllowLadderStrafing = true;
		BrushComponent = Default__LadderVolume_BrushComponent0/*Ref BrushComponent'Default__LadderVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__LadderVolume_BrushComponent0/*Ref BrushComponent'Default__LadderVolume.BrushComponent0'*/,
			Default__LadderVolume_Arrow/*Ref ArrowComponent'Default__LadderVolume.Arrow'*/,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		CollisionComponent = Default__LadderVolume_BrushComponent0/*Ref BrushComponent'Default__LadderVolume.BrushComponent0'*/;
	}
}
}