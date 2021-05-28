namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ReachSpec : Object/*
		native*/{
	public const int BLOCKEDPATHCOST = 10000000;
	
	public /*native const editconst transient */Object.Pointer NavOctreeObject;
	public int Distance;
	public Object.Vector Direction;
	public/*()*/ /*const editconst */NavigationPoint Start;
	public/*()*/ /*const editconst */Actor.NavReference End;
	public/*()*/ /*const editconst */int CollisionRadius;
	public/*()*/ /*const editconst */int CollisionHeight;
	public int reachFlags;
	public int MaxLandingVelocity;
	public byte bPruned;
	public byte PathColorIndex;
	public /*const editconst */bool bAddToNavigationOctree;
	public bool bCanCutCorners;
	public bool bCheckForObstructions;
	public /*const */bool bSkipPrune;
	public /*const */array< Core.ClassT<ReachSpec> > PruneSpecList;
	public name ForcedPathSizeName;
	public Actor BlockedBy;
	
	// Export UReachSpec::execCostFor(FFrame&, void* const)
	public virtual /*native final function */int CostFor(Pawn P)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool IsBlockedFor(Pawn P)
	{
	
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