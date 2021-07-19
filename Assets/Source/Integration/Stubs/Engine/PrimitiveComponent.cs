// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class PrimitiveComponent : ActorComponent/*
		abstract
		native
		noexport*/{
	public enum ERBCollisionChannel 
	{
		RBCC_Default,
		RBCC_Nothing,
		RBCC_Pawn,
		RBCC_Vehicle,
		RBCC_Water,
		RBCC_GameplayPhysics,
		RBCC_EffectPhysics,
		RBCC_Untitled1,
		RBCC_Untitled2,
		RBCC_Untitled3,
		RBCC_Untitled4,
		RBCC_Cloth,
		RBCC_FluidDrain,
		RBCC_MAX
	};
	
	public enum ERadialImpulseFalloff 
	{
		RIF_Constant,
		RIF_Linear,
		RIF_MAX
	};
	
	public partial struct MaterialViewRelevance
	{
		public bool bOpaque;
		public bool bTranslucent;
		public bool bDistortion;
		public bool bLit;
		public bool bUsesSceneColor;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0025973C
	//		bOpaque = false;
	//		bTranslucent = false;
	//		bDistortion = false;
	//		bLit = false;
	//		bUsesSceneColor = false;
	//	}
	};
	
	public partial struct RBCollisionChannelContainer
	{
		[Category] [Const] public bool Default;
		[Const] public bool Nothing;
		[Category] [Const] public bool Pawn;
		[Category] [Const] public bool Vehicle;
		[Category] [Const] public bool Water;
		[Category] [Const] public bool GameplayPhysics;
		[Category] [Const] public bool EffectPhysics;
		[Category] [Const] public bool Untitled1;
		[Category] [Const] public bool Untitled2;
		[Category] [Const] public bool Untitled3;
		[Category] [Const] public bool Untitled4;
		[Category] [Const] public bool Cloth;
		[Category] [Const] public bool FluidDrain;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0025A988
	//		Default = false;
	//		Nothing = false;
	//		Pawn = false;
	//		Vehicle = false;
	//		Water = false;
	//		GameplayPhysics = false;
	//		EffectPhysics = false;
	//		Untitled1 = false;
	//		Untitled2 = false;
	//		Untitled3 = false;
	//		Untitled4 = false;
	//		Cloth = false;
	//		FluidDrain = false;
	//	}
	};
	
	[native, Const, transient] public/*private*/ Object.Pointer SceneInfo;
	[native, Const] public/*private*/ int DetachFence;
	[native, Const, transient] public float LocalToWorldDeterminant;
	[native, Const, transient] public Object.Matrix LocalToWorld;
	[native, Const, transient] public int MotionBlurInfoIndex;
	[noimport, native, Const] public/*private*/ array<Object.Pointer> DecalList;
	[native, Const, transient] public int Tag;
	[Const, export, editinline] public PrimitiveComponent ShadowParent;
	[Const, export, editinline, transient] public FogVolumeDensityComponent FogVolumeComponent;
	[native, Const, transient] public Object.BoxSphereBounds Bounds;
	[Const, export, editinline] public LightEnvironmentComponent LightEnvironment;
	[Category("Rendering")] [Const, noexport] public/*private*/ float CullDistance;
	[Category("Rendering")] [editconst] public float CachedCullDistance;
	[Category("Rendering")] [Const] public Scene.ESceneDepthPriorityGroup DepthPriorityGroup;
	[Const] public Scene.ESceneDepthPriorityGroup ViewOwnerDepthPriorityGroup;
	[Category("Rendering")] [Const] public Scene.EDetailMode DetailMode;
	[Category("Rendering")] public float MotionBlurScale;
	[Const] public bool bUseViewOwnerDepthPriorityGroup;
	[Category("Rendering")] [Const] public bool bAllowCullDistanceVolume;
	[Category("Rendering")] [Const] public bool HiddenGame;
	[Category("Rendering")] [Const] public bool HiddenEditor;
	public bool bOwnerNoSeeWithShadow;
	public bool bRenderInLiteMirror;
	public bool bForceOcclusionTest;
	[Const] public bool bIsTransparentToPlayerAndAI;
	[Const] public bool bDenyHandMoves;
	[Const] public bool bDenyFootMoves;
	[Category("Rendering")] [Const] public bool bOwnerNoSee;
	[Category("Rendering")] [Const] public bool bOnlyOwnerSee;
	[Category("Rendering")] [Const] public bool bIgnoreOwnerHidden;
	[Category("Rendering")] public bool bUseAsOccluder;
	[Category("Rendering")] public bool bUseAsOccluderAlways;
	[Category("Rendering")] public bool bAllowApproximateOcclusion;
	[Category("Rendering")] [Const] public bool bForceMipStreaming;
	[Category("Rendering")] [Const] public bool bAcceptsDecals;
	[Category("Rendering")] [Const] public bool bAcceptsDecalsDuringGameplay;
	[native, Const, transient] public bool bIsRefreshingDecals;
	[Category("Rendering")] [Const] public bool bAcceptsFoliage;
	[Category("Rendering")] public int TranslucencySortPriority;
	[Category("Lighting")] public bool CastShadow;
	[Category("Lighting")] [Const] public bool bForceDirectLightMap;
	[Category("Lighting")] public bool bCastDynamicShadow;
	[Category("Lighting")] public bool bCastHiddenShadow;
	[Category("Lighting")] [Const] public bool bAcceptsLights;
	[Category("Lighting")] [Const] public bool bAcceptsDynamicLights;
	[Category("Lighting")] [Const] public LightComponent.LightingChannelContainer LightingChannels;
	[Category("Lighting")] [Const] public bool bUsePrecomputedShadows;
	[Category("Lighting")] public bool bCullModulatedShadowOnBackfaces;
	[Const] public bool CollideActors;
	[Const] public bool BlockActors;
	[Const] public bool BlockZeroExtent;
	[Const] public bool BlockNonZeroExtent;
	[Category("Collision")] [Const] public bool BlockRigidBody;
	[Const] public bool RigidBodyIgnorePawns;
	[Category("Collision")] [Const] public PrimitiveComponent.ERBCollisionChannel RBChannel;
	[Category("Collision")] [Const] public PrimitiveComponent.RBCollisionChannelContainer RBCollideWithChannels;
	[Category("Physics")] [Const] public bool bDisableAllRigidBody;
	[Category("Physics")] [Const] public bool bNotifyRigidBodyCollision;
	[Category("Physics")] [Const] public bool bFluidDrain;
	[Category("Physics")] [Const] public bool bFluidTwoWay;
	[Category("Physics")] public bool bIgnoreRadialImpulse;
	[Category("Physics")] public bool bIgnoreRadialForce;
	[Category("Physics")] public bool bIgnoreForceField;
	[Category("Physics")] [Const] public bool bUseCompartment;
	[Const] public/*private*/ bool AlwaysLoadOnClient;
	[Const] public/*private*/ bool AlwaysLoadOnServer;
	[Category] public bool bIgnoreHiddenActorsMembership;
	[native, Const, transient] public bool bWasSNFiltered;
	[native, Const, transient] public array<int> OctreeNodes;
	[Category("Physics")] [Const] public PhysicalMaterial PhysMaterialOverride;
	[native, Const] public RB_BodyInstance BodyInstance;
	[Category("Physics")] public byte RBDominanceGroup;
	[native, Const, transient] public Object.Matrix CachedParentToWorld;
	[Category] [Const] public Object.Vector Translation;
	[Category] [Const] public Object.Rotator Rotation;
	[Category] [Const] public float Scale;
	[Category] [Const] public Object.Vector Scale3D;
	[Category] [Const] public bool AbsoluteTranslation;
	[Category] [Const] public bool AbsoluteRotation;
	[Category] [Const] public bool AbsoluteScale;
	[Const, transient] public float LastSubmitTime;
	[transient] public float LastRenderTime;
	[transient] public bool PendingRenderCommandExecution;
	public float ScriptRigidBodyCollisionThreshold;
	
	// Export UPrimitiveComponent::execAddImpulse(FFrame&, void* const)
	public virtual /*native final function */void AddImpulse(Object.Vector Impulse, /*optional */Object.Vector? _Position = default, /*optional */name? _BoneName = default, /*optional */bool? _bVelChange = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execAddRadialImpulse(FFrame&, void* const)
	public virtual /*native final function */void AddRadialImpulse(Object.Vector Origin, float Radius, float Strength, PrimitiveComponent.ERadialImpulseFalloff Falloff, /*optional */bool? _bVelChange = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execAddForce(FFrame&, void* const)
	public virtual /*native final function */void AddForce(Object.Vector Force, /*optional */Object.Vector? _Position = default, /*optional */name? _BoneName = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execAddRadialForce(FFrame&, void* const)
	public virtual /*native final function */void AddRadialForce(Object.Vector Origin, float Radius, float Strength, PrimitiveComponent.ERadialImpulseFalloff Falloff)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetRBLinearVelocity(FFrame&, void* const)
	public virtual /*native final function */void SetRBLinearVelocity(Object.Vector NewVel, /*optional */bool? _bAddToCurrent = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetRBAngularVelocity(FFrame&, void* const)
	public virtual /*native final function */void SetRBAngularVelocity(Object.Vector NewAngVel, /*optional */bool? _bAddToCurrent = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetRBPosition(FFrame&, void* const)
	public virtual /*native final function */void SetRBPosition(Object.Vector NewPos, /*optional */name? _BoneName = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetRBRotation(FFrame&, void* const)
	public virtual /*native final function */void SetRBRotation(Object.Rotator NewRot, /*optional */name? _BoneName = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execWakeRigidBody(FFrame&, void* const)
	public virtual /*native final function */void WakeRigidBody(/*optional */name? _BoneName = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execPutRigidBodyToSleep(FFrame&, void* const)
	public virtual /*native final function */void PutRigidBodyToSleep(/*optional */name? _BoneName = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execRigidBodyIsAwake(FFrame&, void* const)
	public virtual /*native final function */bool RigidBodyIsAwake(/*optional */name? _BoneName = default)
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UPrimitiveComponent::execSetBlockRigidBody(FFrame&, void* const)
	public virtual /*native final function */void SetBlockRigidBody(bool bNewBlockRigidBody)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetRBCollidesWithChannel(FFrame&, void* const)
	public virtual /*native final function */void SetRBCollidesWithChannel(PrimitiveComponent.ERBCollisionChannel Channel, bool bNewCollides)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetRBChannel(FFrame&, void* const)
	public virtual /*native final function */void SetRBChannel(PrimitiveComponent.ERBCollisionChannel Channel)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetNotifyRigidBodyCollision(FFrame&, void* const)
	public virtual /*native final function */void SetNotifyRigidBodyCollision(bool bNewNotifyRigidBodyCollision)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetPhysMaterialOverride(FFrame&, void* const)
	public virtual /*native final function */void SetPhysMaterialOverride(PhysicalMaterial NewPhysMaterial)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execGetRootBodyInstance(FFrame&, void* const)
	public virtual /*native final function */RB_BodyInstance GetRootBodyInstance()
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export UPrimitiveComponent::execSetRBDominanceGroup(FFrame&, void* const)
	public virtual /*native final function */void SetRBDominanceGroup(byte InDomGroup)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetHidden(FFrame&, void* const)
	public virtual /*native final function */void SetHidden(bool NewHidden)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetOwnerNoSee(FFrame&, void* const)
	public virtual /*native final function */void SetOwnerNoSee(bool bNewOwnerNoSee)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetOnlyOwnerSee(FFrame&, void* const)
	public virtual /*native final function */void SetOnlyOwnerSee(bool bNewOnlyOwnerSee)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetOwnerNoSeeWithShadow(FFrame&, void* const)
	public virtual /*native final function */void SetOwnerNoSeeWithShadow(bool bNewOwnerNoSeeWithShadow)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetIgnoreOwnerHidden(FFrame&, void* const)
	public virtual /*native final function */void SetIgnoreOwnerHidden(bool bNewIgnoreOwnerHidden)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetShadowParent(FFrame&, void* const)
	public virtual /*native final function */void SetShadowParent(PrimitiveComponent NewShadowParent)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetLightEnvironment(FFrame&, void* const)
	public virtual /*native final function */void SetLightEnvironment(LightEnvironmentComponent NewLightEnvironment)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetCullDistance(FFrame&, void* const)
	public virtual /*native final function */void SetCullDistance(float NewCullDistance)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetLightingChannels(FFrame&, void* const)
	public virtual /*native final function */void SetLightingChannels(LightComponent.LightingChannelContainer NewLightingChannels)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetDepthPriorityGroup(FFrame&, void* const)
	public virtual /*native final function */void SetDepthPriorityGroup(Scene.ESceneDepthPriorityGroup NewDepthPriorityGroup)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetViewOwnerDepthPriorityGroup(FFrame&, void* const)
	public virtual /*native final function */void SetViewOwnerDepthPriorityGroup(bool bNewUseViewOwnerDepthPriorityGroup, Scene.ESceneDepthPriorityGroup NewViewOwnerDepthPriorityGroup)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetTraceBlocking(FFrame&, void* const)
	public virtual /*native final function */void SetTraceBlocking(bool NewBlockZeroExtent, bool NewBlockNonZeroExtent)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetActorCollision(FFrame&, void* const)
	public virtual /*native final function */void SetActorCollision(bool NewCollideActors, bool NewBlockActors)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetTranslation(FFrame&, void* const)
	public virtual /*native function */void SetTranslation(Object.Vector NewTranslation)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetRotation(FFrame&, void* const)
	public virtual /*native function */void SetRotation(Object.Rotator NewRotation)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetScale(FFrame&, void* const)
	public virtual /*native function */void SetScale(float NewScale)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetScale3D(FFrame&, void* const)
	public virtual /*native function */void SetScale3D(Object.Vector NewScale3D)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	// Export UPrimitiveComponent::execSetAbsolute(FFrame&, void* const)
	public virtual /*native function */void SetAbsolute(/*optional */bool? _NewAbsoluteTranslation = default, /*optional */bool? _NewAbsoluteRotation = default, /*optional */bool? _NewAbsoluteScale = default)
	{
		 NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*final function */Object.Vector GetPosition()
	{
	
		return default;
	}
	
	// Export UPrimitiveComponent::execGetRotation(FFrame&, void* const)
	public virtual /*native final function */Object.Rotator GetRotation()
	{
		 NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	public PrimitiveComponent()
	{
		// Object Offset:0x0025C7E6
		DepthPriorityGroup = MEdge.Engine.Scene.ESceneDepthPriorityGroup.SDPG_World;
		MotionBlurScale = 1.0f;
		bAllowCullDistanceVolume = true;
		bAcceptsDecalsDuringGameplay = true;
		bAcceptsFoliage = true;
		bCastDynamicShadow = true;
		bAcceptsDynamicLights = true;
		AlwaysLoadOnClient = true;
		AlwaysLoadOnServer = true;
		RBDominanceGroup = 15;
		Scale = 1.0f;
		Scale3D = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
	}
}
}