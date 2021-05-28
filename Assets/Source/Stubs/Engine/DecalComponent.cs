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
		public /*const export editinline */PrimitiveComponent Component;
		public /*native const */Object.Pointer RenderData;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003085A6
	//		Component = default;
	//	}
	};
	
	public/*(Decal)*/ MaterialInterface DecalMaterial;
	public/*(Decal)*/ float Width;
	public/*(Decal)*/ float Height;
	public/*(Decal)*/ float TileX;
	public/*(Decal)*/ float TileY;
	public/*(Decal)*/ float OffsetX;
	public/*(Decal)*/ float OffsetY;
	public/*(Decal)*/ float DecalRotation;
	public float FieldOfView;
	public/*(Decal)*/ float NearPlane;
	public/*(Decal)*/ float FarPlane;
	public Object.Vector Location;
	public Object.Rotator Orientation;
	public Object.Vector HitLocation;
	public Object.Vector HitNormal;
	public Object.Vector HitTangent;
	public Object.Vector HitBinormal;
	public/*(Decal)*/ bool bNoClip;
	public /*const */bool bStaticDecal;
	public/*(DecalRender)*/ bool bNeverCull;
	public/*(DecalFilter)*/ bool bProjectOnBackfaces;
	public/*(DecalFilter)*/ bool bProjectOnHidden;
	public/*(DecalFilter)*/ bool bProjectOnBSP;
	public/*(DecalFilter)*/ bool bProjectOnStaticMeshes;
	public/*(DecalFilter)*/ bool bProjectOnSkeletalMeshes;
	public/*(DecalFilter)*/ bool bProjectOnTerrain;
	public bool bFlipBackfaceDirection;
	public /*export editinline transient */PrimitiveComponent HitComponent;
	public /*transient */name HitBone;
	public /*transient */int HitNodeIndex;
	public /*transient */int HitLevelIndex;
	public /*private const transient */array<int> HitNodeIndices;
	public /*private noimport duplicatetransient const */array<DecalComponent.DecalReceiver> DecalReceivers;
	public /*private noimport duplicatetransient native const transient */array<Object.Pointer> StaticReceivers;
	public /*duplicatetransient native const transient */Object.Pointer ReleaseResourcesFence;
	public /*private transient */array<Object.Plane> Planes;
	public/*(DecalRender)*/ float DepthBias;
	public/*(DecalRender)*/ float SlopeScaleDepthBias;
	public/*(DecalRender)*/ int SortOrder;
	public/*(DecalRender)*/ float BackfaceAngle;
	public/*(DecalFilter)*/ DecalComponent.EFilterMode FilterMode;
	public/*(DecalFilter)*/ array<Actor> Filter;
	public/*(DecalFilter)*/ /*export editinline */array</*export editinline */PrimitiveComponent> ReceiverImages;
	
	// Export UDecalComponent::execResetToDefaults(FFrame&, void* const)
	public virtual /*native final function */void ResetToDefaults()
	{
		#warning NATIVE FUNCTION !
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