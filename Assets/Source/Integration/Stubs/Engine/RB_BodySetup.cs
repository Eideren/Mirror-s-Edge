namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_BodySetup : KMeshProps/*
		native
		hidecategories(Object)*/{
	public enum ESleepFamily 
	{
		SF_Normal,
		SF_Sensitive,
		SF_MAX
	};
	
	public partial struct KCachedConvexDataElement
	{
		[native] public array<byte> ConvexElementData;
	};
	
	public partial struct KCachedConvexData
	{
		[native] public array<RB_BodySetup.KCachedConvexDataElement> CachedConvexElements;
	};
	
	[Category] public RB_BodySetup.ESleepFamily SleepFamily;
	[Category] [editconst] public name BoneName;
	[Category] public bool bFixed;
	[Category] public bool bNoCollision;
	[Category] public bool bBlockZeroExtent;
	[Category] public bool bBlockNonZeroExtent;
	[Category] public bool bEnableContinuousCollisionDetection;
	[Category] public bool bAlwaysFullAnimWeight;
	[Category] public PhysicalMaterial PhysMaterial;
	[Category] public float MassScale;
	[native, Const] public array<Object.Pointer> CollisionGeom;
	[native, Const] public array<Object.Vector> CollisionGeomScale3D;
	[Category] [Const] public array<Object.Vector> PreCachedPhysScale;
	[native, Const] public array<RB_BodySetup.KCachedConvexData> PreCachedPhysData;
	[Const] public int PreCachedPhysDataVersion;
	
	public RB_BodySetup()
	{
		// Object Offset:0x003AAA44
		bBlockZeroExtent = true;
		bBlockNonZeroExtent = true;
		MassScale = 1.0f;
	}
}
}