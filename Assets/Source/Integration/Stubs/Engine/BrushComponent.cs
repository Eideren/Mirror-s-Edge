namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class BrushComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport*/{
	public partial struct KCachedConvexData_Mirror
	{
		public array<int> CachedConvexElements;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002B12BF
	//		CachedConvexElements = default;
	//	}
	};
	
	[Const] public Model Brush;
	public KMeshProps.KAggregateGeom BrushAggGeom;
	[noimport, native, Const, transient] public/*private*/ Object.Pointer BrushPhysDesc;
	[noimport, native, Const, transient] public/*private*/ BrushComponent.KCachedConvexData_Mirror CachedPhysBrushData;
	[Const] public/*private*/ int CachedPhysBrushDataVersion;
	
	public BrushComponent()
	{
		// Object Offset:0x002B1313
		HiddenGame = true;
		bUseAsOccluder = true;
		AlwaysLoadOnClient = false;
		AlwaysLoadOnServer = false;
	}
}
}