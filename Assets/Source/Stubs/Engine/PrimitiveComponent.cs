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
		public/*()*/ /*const */bool Default;
		public /*const */bool Nothing;
		public/*()*/ /*const */bool Pawn;
		public/*()*/ /*const */bool Vehicle;
		public/*()*/ /*const */bool Water;
		public/*()*/ /*const */bool GameplayPhysics;
		public/*()*/ /*const */bool EffectPhysics;
		public/*()*/ /*const */bool Untitled1;
		public/*()*/ /*const */bool Untitled2;
		public/*()*/ /*const */bool Untitled3;
		public/*()*/ /*const */bool Untitled4;
		public/*()*/ /*const */bool Cloth;
		public/*()*/ /*const */bool FluidDrain;
	
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
	
	public /*private native const transient */Object.Pointer SceneInfo;
	public /*private native const */int DetachFence;
	public /*native const transient */float LocalToWorldDeterminant;
	public /*native const transient */Object.Matrix LocalToWorld;
	public /*native const transient */int MotionBlurInfoIndex;
	public /*private noimport native const */array<Object.Pointer> DecalList;
	public /*native const transient */int Tag;
	public /*const export editinline */PrimitiveComponent ShadowParent;
	public /*const export editinline transient */FogVolumeDensityComponent FogVolumeComponent;
	public /*native const transient */Object.BoxSphereBounds Bounds;
	public /*const export editinline */LightEnvironmentComponent LightEnvironment;
	public/*(Rendering)*/ /*private const noexport */float CullDistance;
	public/*(Rendering)*/ /*editconst */float CachedCullDistance;
	public/*(Rendering)*/ /*const */Scene.ESceneDepthPriorityGroup DepthPriorityGroup;
	public /*const */Scene.ESceneDepthPriorityGroup ViewOwnerDepthPriorityGroup;
	public/*(Rendering)*/ /*const */Scene.EDetailMode DetailMode;
	public/*(Rendering)*/ float MotionBlurScale;
	public /*const */bool bUseViewOwnerDepthPriorityGroup;
	public/*(Rendering)*/ /*const */bool bAllowCullDistanceVolume;
	public/*(Rendering)*/ /*const */bool HiddenGame;
	public/*(Rendering)*/ /*const */bool HiddenEditor;
	public bool bOwnerNoSeeWithShadow;
	public bool bRenderInLiteMirror;
	public bool bForceOcclusionTest;
	public /*const */bool bIsTransparentToPlayerAndAI;
	public /*const */bool bDenyHandMoves;
	public /*const */bool bDenyFootMoves;
	public/*(Rendering)*/ /*const */bool bOwnerNoSee;
	public/*(Rendering)*/ /*const */bool bOnlyOwnerSee;
	public/*(Rendering)*/ /*const */bool bIgnoreOwnerHidden;
	public/*(Rendering)*/ bool bUseAsOccluder;
	public/*(Rendering)*/ bool bUseAsOccluderAlways;
	public/*(Rendering)*/ bool bAllowApproximateOcclusion;
	public/*(Rendering)*/ /*const */bool bForceMipStreaming;
	public/*(Rendering)*/ /*const */bool bAcceptsDecals;
	public/*(Rendering)*/ /*const */bool bAcceptsDecalsDuringGameplay;
	public /*native const transient */bool bIsRefreshingDecals;
	public/*(Rendering)*/ /*const */bool bAcceptsFoliage;
	public/*(Rendering)*/ int TranslucencySortPriority;
	public/*(Lighting)*/ bool CastShadow;
	public/*(Lighting)*/ /*const */bool bForceDirectLightMap;
	public/*(Lighting)*/ bool bCastDynamicShadow;
	public/*(Lighting)*/ bool bCastHiddenShadow;
	public/*(Lighting)*/ /*const */bool bAcceptsLights;
	public/*(Lighting)*/ /*const */bool bAcceptsDynamicLights;
	public/*(Lighting)*/ /*const */LightComponent.LightingChannelContainer LightingChannels;
	public/*(Lighting)*/ /*const */bool bUsePrecomputedShadows;
	public/*(Lighting)*/ bool bCullModulatedShadowOnBackfaces;
	public /*const */bool CollideActors;
	public /*const */bool BlockActors;
	public /*const */bool BlockZeroExtent;
	public /*const */bool BlockNonZeroExtent;
	public/*(Collision)*/ /*const */bool BlockRigidBody;
	public /*const */bool RigidBodyIgnorePawns;
	public/*(Collision)*/ /*const */PrimitiveComponent.ERBCollisionChannel RBChannel;
	public/*(Collision)*/ /*const */PrimitiveComponent.RBCollisionChannelContainer RBCollideWithChannels;
	public/*(Physics)*/ /*const */bool bDisableAllRigidBody;
	public/*(Physics)*/ /*const */bool bNotifyRigidBodyCollision;
	public/*(Physics)*/ /*const */bool bFluidDrain;
	public/*(Physics)*/ /*const */bool bFluidTwoWay;
	public/*(Physics)*/ bool bIgnoreRadialImpulse;
	public/*(Physics)*/ bool bIgnoreRadialForce;
	public/*(Physics)*/ bool bIgnoreForceField;
	public/*(Physics)*/ /*const */bool bUseCompartment;
	public /*private const */bool AlwaysLoadOnClient;
	public /*private const */bool AlwaysLoadOnServer;
	public/*()*/ bool bIgnoreHiddenActorsMembership;
	public /*native const transient */bool bWasSNFiltered;
	public /*native const transient */array<int> OctreeNodes;
	public/*(Physics)*/ /*const */PhysicalMaterial PhysMaterialOverride;
	public /*native const */RB_BodyInstance BodyInstance;
	public/*(Physics)*/ byte RBDominanceGroup;
	public /*native const transient */Object.Matrix CachedParentToWorld;
	public/*()*/ /*const */Object.Vector Translation;
	public/*()*/ /*const */Object.Rotator Rotation;
	public/*()*/ /*const */float Scale;
	public/*()*/ /*const */Object.Vector Scale3D;
	public/*()*/ /*const */bool AbsoluteTranslation;
	public/*()*/ /*const */bool AbsoluteRotation;
	public/*()*/ /*const */bool AbsoluteScale;
	public /*const transient */float LastSubmitTime;
	public /*transient */float LastRenderTime;
	public /*transient */bool PendingRenderCommandExecution;
	public float ScriptRigidBodyCollisionThreshold;
	
	// Export UPrimitiveComponent::execAddImpulse(FFrame&, void* const)
	public virtual /*native final function */void AddImpulse(Object.Vector Impulse, /*optional */Object.Vector? _Position = default, /*optional */name? _BoneName = default, /*optional */bool? _bVelChange = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execAddRadialImpulse(FFrame&, void* const)
	public virtual /*native final function */void AddRadialImpulse(Object.Vector Origin, float Radius, float Strength, PrimitiveComponent.ERadialImpulseFalloff Falloff, /*optional */bool? _bVelChange = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execAddForce(FFrame&, void* const)
	public virtual /*native final function */void AddForce(Object.Vector Force, /*optional */Object.Vector? _Position = default, /*optional */name? _BoneName = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execAddRadialForce(FFrame&, void* const)
	public virtual /*native final function */void AddRadialForce(Object.Vector Origin, float Radius, float Strength, PrimitiveComponent.ERadialImpulseFalloff Falloff)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetRBLinearVelocity(FFrame&, void* const)
	public virtual /*native final function */void SetRBLinearVelocity(Object.Vector NewVel, /*optional */bool? _bAddToCurrent = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetRBAngularVelocity(FFrame&, void* const)
	public virtual /*native final function */void SetRBAngularVelocity(Object.Vector NewAngVel, /*optional */bool? _bAddToCurrent = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetRBPosition(FFrame&, void* const)
	public virtual /*native final function */void SetRBPosition(Object.Vector NewPos, /*optional */name? _BoneName = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetRBRotation(FFrame&, void* const)
	public virtual /*native final function */void SetRBRotation(Object.Rotator NewRot, /*optional */name? _BoneName = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execWakeRigidBody(FFrame&, void* const)
	public virtual /*native final function */void WakeRigidBody(/*optional */name? _BoneName = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execPutRigidBodyToSleep(FFrame&, void* const)
	public virtual /*native final function */void PutRigidBodyToSleep(/*optional */name? _BoneName = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execRigidBodyIsAwake(FFrame&, void* const)
	public virtual /*native final function */bool RigidBodyIsAwake(/*optional */name? _BoneName = default)
	{
		 // #warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPrimitiveComponent::execSetBlockRigidBody(FFrame&, void* const)
	public virtual /*native final function */void SetBlockRigidBody(bool bNewBlockRigidBody)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetRBCollidesWithChannel(FFrame&, void* const)
	public virtual /*native final function */void SetRBCollidesWithChannel(PrimitiveComponent.ERBCollisionChannel Channel, bool bNewCollides)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetRBChannel(FFrame&, void* const)
	public virtual /*native final function */void SetRBChannel(PrimitiveComponent.ERBCollisionChannel Channel)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetNotifyRigidBodyCollision(FFrame&, void* const)
	public virtual /*native final function */void SetNotifyRigidBodyCollision(bool bNewNotifyRigidBodyCollision)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetPhysMaterialOverride(FFrame&, void* const)
	public virtual /*native final function */void SetPhysMaterialOverride(PhysicalMaterial NewPhysMaterial)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execGetRootBodyInstance(FFrame&, void* const)
	public virtual /*native final function */RB_BodyInstance GetRootBodyInstance()
	{
		 // #warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UPrimitiveComponent::execSetRBDominanceGroup(FFrame&, void* const)
	public virtual /*native final function */void SetRBDominanceGroup(byte InDomGroup)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetHidden(FFrame&, void* const)
	public virtual /*native final function */void SetHidden(bool NewHidden)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetOwnerNoSee(FFrame&, void* const)
	public virtual /*native final function */void SetOwnerNoSee(bool bNewOwnerNoSee)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetOnlyOwnerSee(FFrame&, void* const)
	public virtual /*native final function */void SetOnlyOwnerSee(bool bNewOnlyOwnerSee)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetOwnerNoSeeWithShadow(FFrame&, void* const)
	public virtual /*native final function */void SetOwnerNoSeeWithShadow(bool bNewOwnerNoSeeWithShadow)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetIgnoreOwnerHidden(FFrame&, void* const)
	public virtual /*native final function */void SetIgnoreOwnerHidden(bool bNewIgnoreOwnerHidden)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetShadowParent(FFrame&, void* const)
	public virtual /*native final function */void SetShadowParent(PrimitiveComponent NewShadowParent)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetLightEnvironment(FFrame&, void* const)
	public virtual /*native final function */void SetLightEnvironment(LightEnvironmentComponent NewLightEnvironment)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetCullDistance(FFrame&, void* const)
	public virtual /*native final function */void SetCullDistance(float NewCullDistance)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetLightingChannels(FFrame&, void* const)
	public virtual /*native final function */void SetLightingChannels(LightComponent.LightingChannelContainer NewLightingChannels)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetDepthPriorityGroup(FFrame&, void* const)
	public virtual /*native final function */void SetDepthPriorityGroup(Scene.ESceneDepthPriorityGroup NewDepthPriorityGroup)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetViewOwnerDepthPriorityGroup(FFrame&, void* const)
	public virtual /*native final function */void SetViewOwnerDepthPriorityGroup(bool bNewUseViewOwnerDepthPriorityGroup, Scene.ESceneDepthPriorityGroup NewViewOwnerDepthPriorityGroup)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetTraceBlocking(FFrame&, void* const)
	public virtual /*native final function */void SetTraceBlocking(bool NewBlockZeroExtent, bool NewBlockNonZeroExtent)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetActorCollision(FFrame&, void* const)
	public virtual /*native final function */void SetActorCollision(bool NewCollideActors, bool NewBlockActors)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetTranslation(FFrame&, void* const)
	public virtual /*native function */void SetTranslation(Object.Vector NewTranslation)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetRotation(FFrame&, void* const)
	public virtual /*native function */void SetRotation(Object.Rotator NewRotation)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetScale(FFrame&, void* const)
	public virtual /*native function */void SetScale(float NewScale)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetScale3D(FFrame&, void* const)
	public virtual /*native function */void SetScale3D(Object.Vector NewScale3D)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	// Export UPrimitiveComponent::execSetAbsolute(FFrame&, void* const)
	public virtual /*native function */void SetAbsolute(/*optional */bool? _NewAbsoluteTranslation = default, /*optional */bool? _NewAbsoluteRotation = default, /*optional */bool? _NewAbsoluteScale = default)
	{
		 // #warning NATIVE FUNCTION !
	}
	
	public virtual /*final function */Object.Vector GetPosition()
	{
	
		return default;
	}
	
	// Export UPrimitiveComponent::execGetRotation(FFrame&, void* const)
	public virtual /*native final function */Object.Rotator GetRotation()
	{
		 // #warning NATIVE FUNCTION !
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