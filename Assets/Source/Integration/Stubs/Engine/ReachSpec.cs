namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ReachSpec : Object/*
		native*/{
	public const int BLOCKEDPATHCOST = 10000000;
	
	[native, Const, editconst, transient] public Object.Pointer NavOctreeObject;
	public int Distance;
	public Object.Vector Direction;
	[Category] [Const, editconst] public NavigationPoint Start;
	[Category] [Const, editconst] public Actor.NavReference End;
	[Category] [Const, editconst] public int CollisionRadius;
	[Category] [Const, editconst] public int CollisionHeight;
	public int reachFlags;
	public int MaxLandingVelocity;
	public byte bPruned;
	public byte PathColorIndex;
	[Const, editconst] public bool bAddToNavigationOctree;
	public bool bCanCutCorners;
	public bool bCheckForObstructions;
	[Const] public bool bSkipPrune;
	[Const] public array< Core.ClassT<ReachSpec> > PruneSpecList;
	public name ForcedPathSizeName;
	public Actor BlockedBy;
	
	// Export UReachSpec::execCostFor(FFrame&, void* const)
	public virtual /*native final function */int CostFor(Pawn P)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */bool IsBlockedFor(Pawn P)
	{
		// stub
		return default;
	}
	
	public ReachSpec()
	{
		// Object Offset:0x0028B6F8
		bAddToNavigationOctree = true;
		bCanCutCorners = true;
		bCheckForObstructions = true;
		ForcedPathSizeName = (name)"Common";
	}
}
}