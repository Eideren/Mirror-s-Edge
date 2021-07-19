namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DecalComponent : PrimitiveComponent/*
		native
		editinlinenew
		hidecategories(Collision,Object,Physics,PrimitiveComponent)*/{
	public enum EFilterMode 
	{
		FM_None,
		FM_Ignore,
		FM_Affect,
		FM_MAX
	};
	
	public partial struct /*native */DecalReceiver
	{
		[Const, export, editinline] public PrimitiveComponent Component;
		[native, Const] public Object.Pointer RenderData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003085A6
	//		Component = default;
	//	}
	};
	
	[Category("Decal")] public MaterialInterface DecalMaterial;
	[Category("Decal")] public float Width;
	[Category("Decal")] public float Height;
	[Category("Decal")] public float TileX;
	[Category("Decal")] public float TileY;
	[Category("Decal")] public float OffsetX;
	[Category("Decal")] public float OffsetY;
	[Category("Decal")] public float DecalRotation;
	public float FieldOfView;
	[Category("Decal")] public float NearPlane;
	[Category("Decal")] public float FarPlane;
	public Object.Vector Location;
	public Object.Rotator Orientation;
	public Object.Vector HitLocation;
	public Object.Vector HitNormal;
	public Object.Vector HitTangent;
	public Object.Vector HitBinormal;
	[Category("Decal")] public bool bNoClip;
	[Const] public bool bStaticDecal;
	[Category("DecalRender")] public bool bNeverCull;
	[Category("DecalFilter")] public bool bProjectOnBackfaces;
	[Category("DecalFilter")] public bool bProjectOnHidden;
	[Category("DecalFilter")] public bool bProjectOnBSP;
	[Category("DecalFilter")] public bool bProjectOnStaticMeshes;
	[Category("DecalFilter")] public bool bProjectOnSkeletalMeshes;
	[Category("DecalFilter")] public bool bProjectOnTerrain;
	public bool bFlipBackfaceDirection;
	[export, editinline, transient] public PrimitiveComponent HitComponent;
	[transient] public name HitBone;
	[transient] public int HitNodeIndex;
	[transient] public int HitLevelIndex;
	[Const, transient] public/*private*/ array<int> HitNodeIndices;
	[noimport, duplicatetransient, Const] public/*private*/ array<DecalComponent.DecalReceiver> DecalReceivers;
	[noimport, duplicatetransient, native, Const, transient] public/*private*/ array<Object.Pointer> StaticReceivers;
	[duplicatetransient, native, Const, transient] public Object.Pointer ReleaseResourcesFence;
	[transient] public/*private*/ array<Object.Plane> Planes;
	[Category("DecalRender")] public float DepthBias;
	[Category("DecalRender")] public float SlopeScaleDepthBias;
	[Category("DecalRender")] public int SortOrder;
	[Category("DecalRender")] public float BackfaceAngle;
	[Category("DecalFilter")] public DecalComponent.EFilterMode FilterMode;
	[Category("DecalFilter")] public array<Actor> Filter;
	[Category("DecalFilter")] [export, editinline] public array</*export editinline */PrimitiveComponent> ReceiverImages;
	
	// Export UDecalComponent::execResetToDefaults(FFrame&, void* const)
	public virtual /*native final function */void ResetToDefaults()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public DecalComponent()
	{
		// Object Offset:0x0030866F
		Width = 200.0f;
		Height = 200.0f;
		TileX = 1.0f;
		TileY = 1.0f;
		FieldOfView = 80.0f;
		FarPlane = 300.0f;
		bProjectOnBSP = true;
		bProjectOnStaticMeshes = true;
		bProjectOnSkeletalMeshes = true;
		bProjectOnTerrain = true;
		HitNodeIndex = -1;
		HitLevelIndex = -1;
		DepthBias = -0.000060f;
		BackfaceAngle = 0.0010f;
		bCastDynamicShadow = false;
		bAcceptsDynamicLights = false;
	}
}
}