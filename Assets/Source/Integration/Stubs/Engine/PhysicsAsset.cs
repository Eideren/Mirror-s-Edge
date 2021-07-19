namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PhysicsAsset : Object/*
		native
		hidecategories(Object)*/{
	[editoronly, Const] public SkeletalMesh DefaultSkelMesh;
	[Const, export, editinline] public array</*export editinline */RB_BodySetup> BodySetup;
	[Const, export, editinline] public array</*export editinline */RB_ConstraintSetup> ConstraintSetup;
	[Const, export, editinline] public PhysicsAssetInstance DefaultInstance;
	
}
}