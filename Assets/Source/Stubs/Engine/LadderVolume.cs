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
	
	}
	
	public virtual /*function */bool InUse(Pawn Ignored)
	{
	
		return default;
	}
	
	public override /*simulated event */void PawnEnteredVolume(Pawn P)
	{
	
	}
	
	public override /*simulated event */void PawnLeavingVolume(Pawn P)
	{
	
	}
	
	public override /*simulated event */void PhysicsChangedFor(Actor Other)
	{
	
	}
	
	public LadderVolume()
	{
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
		BrushComponent = LoadAsset<BrushComponent>("Default__LadderVolume.BrushComponent0")/*Ref BrushComponent'Default__LadderVolume.BrushComponent0'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<BrushComponent>("Default__LadderVolume.BrushComponent0")/*Ref BrushComponent'Default__LadderVolume.BrushComponent0'*/,
			Default__LadderVolume_Arrow,
		};
		RemoteRole = Actor.ENetRole.ROLE_SimulatedProxy;
		CollisionComponent = LoadAsset<BrushComponent>("Default__LadderVolume.BrushComponent0")/*Ref BrushComponent'Default__LadderVolume.BrushComponent0'*/;
	}
}
}