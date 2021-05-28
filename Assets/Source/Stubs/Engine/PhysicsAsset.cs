namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhysicsAsset : Object/*
		native
		hidecategories(Object)*/{
	public /*editoronly const */SkeletalMesh DefaultSkelMesh;
	public /*const export editinline */array</*export editinline */RB_BodySetup> BodySetup;
	public /*const export editinline */array</*export editinline */RB_ConstraintSetup> ConstraintSetup;
	public /*const export editinline */PhysicsAssetInstance DefaultInstance;
	
}
}