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
		public /*native */array<byte> ConvexElementData;
	};
	
	public partial struct KCachedConvexData
	{
		public /*native */array<RB_BodySetup.KCachedConvexDataElement> CachedConvexElements;
	};
	
	public/*()*/ RB_BodySetup.ESleepFamily SleepFamily;
	public/*()*/ /*editconst */name BoneName;
	public/*()*/ bool bFixed;
	public/*()*/ bool bNoCollision;
	public/*()*/ bool bBlockZeroExtent;
	public/*()*/ bool bBlockNonZeroExtent;
	public/*()*/ bool bEnableContinuousCollisionDetection;
	public/*()*/ bool bAlwaysFullAnimWeight;
	public/*()*/ PhysicalMaterial PhysMaterial;
	public/*()*/ float MassScale;
	public /*native const */array<Object.Pointer> CollisionGeom;
	public /*native const */array<Object.Vector> CollisionGeomScale3D;
	public/*()*/ /*const */array<Object.Vector> PreCachedPhysScale;
	public /*native const */array<RB_BodySetup.KCachedConvexData> PreCachedPhysData;
	public /*const */int PreCachedPhysDataVersion;
	
	public RB_BodySetup()
	{
		// Object Offset:0x003AAA44
		bBlockZeroExtent = true;
		bBlockNonZeroExtent = true;
		MassScale = 1.0f;
	}
}
}