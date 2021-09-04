// NO OVERWRITE

namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkeletalMeshComponent : MeshComponent/*
		native
		editinlinenew
		noexport
		hidecategories(Object)*/{
	public enum ERootMotionMode 
	{
		RMM_Translate,
		RMM_Velocity,
		RMM_Ignore,
		RMM_Accel,
		RMM_MAX
	};
	
	public enum ERootMotionRotationMode 
	{
		RMRM_Ignore,
		RMRM_RotateActor,
		RMRM_MAX
	};
	
	public enum EFaceFXBlendMode 
	{
		FXBM_Overwrite,
		FXBM_Additive,
		FXBM_MAX
	};
	
	public enum EFaceFXRegOp 
	{
		FXRO_Add,
		FXRO_Multiply,
		FXRO_Replace,
		FXRO_MAX
	};
	
	public partial struct ActiveMorph
	{
		public MorphTarget Target;
		public float Weight;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002EF976
	//		Target = default;
	//		Weight = 0.0f;
	//	}
	};
	
	public partial struct Attachment
	{
		[Category] [export, editinline] public ActorComponent Component;
		[Category] public name BoneName;
		[Category] public Object.Vector RelativeLocation;
		[Category] public Object.Rotator RelativeRotation;
		[Category] public Object.Vector RelativeScale;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002EFAD2
	//		Component = default;
	//		BoneName = (name)"None";
	//		RelativeLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RelativeRotation = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		RelativeScale = new Vector
	//		{
	//			X=1.0f,
	//			Y=1.0f,
	//			Z=1.0f
	//		};
	//	}
	};
	
	[Category] public SkeletalMesh SkeletalMesh;
	[export, editinline] public SkeletalMeshComponent AttachedToSkelComponent;
	public Object.Matrix LocalToLegRotatedWorld;
	public bool bUseLegRotationHack1;
	[Category] [Const] public AnimTree AnimTreeTemplate;
	[Category] [Const, export, editinline] public AnimNode Animations;
	[Const, transient] public array<AnimNode> AnimTickArray;
	[Category] [Const] public PhysicsAsset PhysicsAsset;
	[Const, export, editinline, transient] public PhysicsAssetInstance PhysicsAssetInstance;
	[Category] public float PhysicsWeight;
	[Category] public float GlobalAnimRateScale;
	[native, Const, transient] public Object.Pointer MeshObject;
	[Category] public Object.Color WireframeColor;
	[native, Const, transient] public array<Object.Matrix> SpaceBases;
	[native, Const, transient] public array<AnimNode.BoneAtom> LocalAtoms;
	[native, Const, transient] public array<byte> RequiredBones;
	[Category] [Const, export, editinline] public SkeletalMeshComponent ParentAnimComponent;
	[native, Const, transient] public array<int> ParentBoneMap;
	[Category] public array<AnimSet> AnimSets;
	[native, Const, transient] public array<AnimSet> TemporarySavedAnimSets;
	[Category] public array<MorphTargetSet> MorphSets;
	public array<SkeletalMeshComponent.ActiveMorph> ActiveMorphs;
	[duplicatetransient, Const] public array<SkeletalMeshComponent.Attachment> Attachments;
	[Const, transient] public array<byte> SkelControlIndex;
	[Category] public int ForcedLodModel;
	public int PredictedLODLevel;
	public int OldPredictedLODLevel;
	[Const] public float MaxDistanceFactor;
	public int bForceWireframe;
	public int bForceRefpose;
	public int bOldForceRefPose;
	public int bNoSkeletonUpdate;
	public int bDisplayBones;
	public int bShowPrePhysBones;
	public int bHideSkin;
	public int bForceRawOffset;
	public int bIgnoreControllers;
	public int bTransformFromAnimParent;
	[Const, transient] public int TickTag;
	[Const, transient] public int CachedAtomsTag;
	[Const] public int bUseSingleBodyPhysics;
	[transient] public int bRequiredBonesUpToDate;
	public float MinDistFactorForKinematicUpdate;
	public name PhysicsBlendZeroDriftBoneName;
	[transient] public int FramesPhysicsAsleep;
	public bool bSkipAllUpdateWhenPhysicsAsleep;
	public bool bUpdateSkelWhenNotRendered;
	public bool bIgnoreControllersWhenNotRendered;
	[Const] public bool bNotUpdatingKinematicDueToDistance;
	[Category] public bool bForceDiscardRootMotion;
	public bool bRootMotionModeChangeNotify;
	public bool bRootMotionExtractedNotify;
	[Category] public bool bDisableFaceFXMaterialInstanceCreation;
	[Const, transient] public bool bAnimTreeInitialised;
	[Category] [Const] public bool bHasPhysicsAssetInstance;
	[Category] public bool bUpdateKinematicBonesFromAnimation;
	[Category] public bool bUpdateJointsFromAnimation;
	[Const] public bool bSkelCompFixed;
	[Const] public bool bHasHadPhysicsBlendedIn;
	[Category] public bool bForceUpdateAttachmentsInTick;
	[Category] public bool bEnableFullAnimWeightBodies;
	[Category] public bool bPerBoneVolumeEffects;
	[Category] public bool bSyncActorLocationToRootRigidBody;
	[Const] public bool bUseRawData;
	public bool bDisableWarningWhenAnimNotFound;
	public bool bOverrideAttachmentOwnerVisibility;
	public bool bPauseAnims;
	public bool bChartDistanceFactor;
	public bool bEnableLineCheckWithBounds;
	public Object.Vector LineCheckBoundsScale;
	[Category("Cloth")] [Const] public bool bEnableClothSimulation;
	[Category("Cloth")] [Const] public bool bDisableClothCollision;
	[Category("Cloth")] [Const] public bool bClothFrozen;
	[Category("Cloth")] public bool bAutoFreezeClothWhenNotRendered;
	[Category("Cloth")] public bool bClothBaseVelClamp;
	[Category("Cloth")] public bool bAttachClothVertsToBaseBody;
	public bool bCacheAnimSequenceNodes;
	public bool bForceMeshObjectUpdates;
	[Category("Cloth")] [Const] public Object.Vector ClothExternalForce;
	[Category("Cloth")] public Object.Vector ClothWind;
	[Category("Cloth")] public Object.Vector ClothBaseVelClampRange;
	[Category("Cloth")] public float ClothBlendWeight;
	public float ClothDynamicBlendWeight;
	[Category("Cloth")] public float ClothMinBlendDistance;
	[Category("Cloth")] public float ClothMaxBlendDistance;
	[native, Const, transient] public Object.Pointer ClothSim;
	[native, Const, transient] public int SceneIndex;
	[Const] public array<Object.Vector> ClothMeshPosData;
	[Const] public array<Object.Vector> ClothMeshNormalData;
	[Const] public array<int> ClothMeshIndexData;
	public int NumClothMeshVerts;
	public int NumClothMeshIndices;
	[Const] public array<int> ClothMeshParentData;
	public int NumClothMeshParentIndices;
	[native, Const, transient] public array<Object.Vector> ClothMeshWeldedPosData;
	[native, Const, transient] public array<Object.Vector> ClothMeshWeldedNormalData;
	[native, Const, transient] public array<int> ClothMeshWeldedIndexData;
	public int ClothDirtyBufferFlag;
	[Category("Cloth")] [Const] public PrimitiveComponent.ERBCollisionChannel ClothRBChannel;
	[Category("Cloth")] [Const] public PrimitiveComponent.RBCollisionChannelContainer ClothRBCollideWithChannels;
	[Category("Cloth")] [Const] public float ClothForceScale;
	[Category("Cloth")] public bool bEnableValidBounds;
	[Category("Cloth")] public Object.Vector ValidBoundsMin;
	[Category("Cloth")] public Object.Vector ValidBoundsMax;
	[Category("Cloth")] [Const] public float ClothAttachmentTearFactor;
	public Material LimitMaterial;
	[Const, transient] public AnimNode.BoneAtom RootMotionDelta;
	[transient] public Object.Vector RootMotionVelocity;
	[Const, transient] public Object.Vector RootBoneTranslation;
	public Object.Vector RootMotionAccelScale;
	[Category] public SkeletalMeshComponent.ERootMotionMode RootMotionMode;
	[Const] public SkeletalMeshComponent.ERootMotionMode PreviousRMM;
	public SkeletalMeshComponent.ERootMotionMode PendingRMM;
	public SkeletalMeshComponent.ERootMotionMode OldPendingRMM;
	[Const] public int bRMMOneFrameDelay;
	[Category] public SkeletalMeshComponent.ERootMotionRotationMode RootMotionRotationMode;
	[Category] public SkeletalMeshComponent.EFaceFXBlendMode FaceFXBlendMode;
	[native, transient] public Object.Pointer FaceFXActorInstance;
	[export, editinline] public AudioComponent CachedFaceFXAudioComp;
	
	// Export USkeletalMeshComponent::execAttachComponent(FFrame&, void* const)
	public virtual /*native final function */void AttachComponent(ActorComponent Component, name BoneName, /*optional */Object.Vector? _RelativeLocation = default, /*optional */Object.Rotator? _RelativeRotation = default, /*optional */Object.Vector? _RelativeScale = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execDetachComponent(FFrame&, void* const)
	public virtual /*native final function */void DetachComponent(ActorComponent Component)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execAttachComponentToSocket(FFrame&, void* const)
	public virtual /*native final function */void AttachComponentToSocket(ActorComponent Component, name SocketName)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execGetSocketWorldLocationAndRotation(FFrame&, void* const)
	public virtual /*native final function */bool GetSocketWorldLocationAndRotation(name InSocketName, ref Object.Vector OutLocation, /*optional */ref Object.Rotator OutRotation/* = default*/)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetSocketByName(FFrame&, void* const)
	public virtual /*native final function */SkeletalMeshSocket GetSocketByName(name InSocketName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindComponentAttachedToBone(FFrame&, void* const)
	public virtual /*native final function */ActorComponent FindComponentAttachedToBone(name InBoneName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execIsComponentAttached(FFrame&, void* const)
	public virtual /*native final function */bool IsComponentAttached(ActorComponent Component, /*optional */name? _BoneName = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execAttachedComponents(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* OutComponent*/> AttachedComponents(Core.ClassT<ActorComponent> BaseClass)
	{
		NativeMarkers.MarkUnimplemented();
		yield break;
	}
	
	// Export USkeletalMeshComponent::execSetSkeletalMesh(FFrame&, void* const)
	public virtual /*native final simulated function */void SetSkeletalMesh(SkeletalMesh NewMesh, /*optional */bool? _bKeepSpaceBases = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetPhysicsAsset(FFrame&, void* const)
	public virtual /*native final simulated function */void SetPhysicsAsset(PhysicsAsset NewPhysicsAsset, /*optional */bool? _bForceReInit = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetForceRefPose(FFrame&, void* const)
	public virtual /*native final simulated function */void SetForceRefPose(bool bNewForceRefPose)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetEnableClothSimulation(FFrame&, void* const)
	public virtual /*native final simulated function */void SetEnableClothSimulation(bool bInEnable)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothFrozen(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothFrozen(bool bNewFrozen)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execUpdateClothParams(FFrame&, void* const)
	public virtual /*native final simulated function */void UpdateClothParams()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothExternalForce(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothExternalForce(Object.Vector InForce)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetAttachClothVertsToBaseBody(FFrame&, void* const)
	public virtual /*native final simulated function */void SetAttachClothVertsToBaseBody(bool bAttachVerts)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execResetClothVertsToRefPose(FFrame&, void* const)
	public virtual /*native final simulated function */void ResetClothVertsToRefPose()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execAddImpulseAtClothPos(FFrame&, void* const)
	public virtual /*native final simulated function */void AddImpulseAtClothPos(Object.Vector Position, Object.Vector Impulse, float Radius)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execGetClothAttachmentResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothAttachmentResponseCoefficient()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothAttachmentTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothAttachmentTearFactor()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothBendingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothBendingStiffness()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothCollisionResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothCollisionResponseCoefficient()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothDampingCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothDampingCoefficient()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothFlags(FFrame&, void* const)
	public virtual /*native final simulated function */int GetClothFlags()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothFriction(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothFriction()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothPressure(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothPressure()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothSleepLinearVelocity(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothSleepLinearVelocity()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothSolverIterations(FFrame&, void* const)
	public virtual /*native final simulated function */int GetClothSolverIterations()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothStretchingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothStretchingStiffness()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothTearFactor()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothThickness(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothThickness()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetClothAttachmentResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothAttachmentResponseCoefficient(float ClothAttachmentResponseCoefficient)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothAttachmentTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothAttachmentTearFactor(float ClothAttachTearFactor)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothBendingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothBendingStiffness(float ClothBendingStiffness)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothCollisionResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothCollisionResponseCoefficient(float ClothCollisionResponseCoefficient)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothDampingCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothDampingCoefficient(float ClothDampingCoefficient)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothFlags(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothFlags(int ClothFlags)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothFriction(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothFriction(float ClothFriction)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothPressure(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothPressure(float ClothPressure)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothSleepLinearVelocity(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothSleepLinearVelocity(float ClothSleepLinearVelocity)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothSolverIterations(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothSolverIterations(int ClothSolverIterations)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothStretchingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothStretchingStiffness(float ClothStretchingStiffness)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothTearFactor(float ClothTearFactor)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothThickness(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothThickness(float ClothThickness)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothSleep(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothSleep(bool IfClothSleep)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothPosition(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothPosition(Object.Vector ClothOffSet)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothVelocity(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothVelocity(Object.Vector VelocityOffSet)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execAttachClothToCollidingShapes(FFrame&, void* const)
	public virtual /*native final simulated function */void AttachClothToCollidingShapes(bool AttatchTwoWay, bool AttachTearable)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execEnableClothValidBounds(FFrame&, void* const)
	public virtual /*native final simulated function */void EnableClothValidBounds(bool IfEnableClothValidBounds)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetClothValidBounds(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothValidBounds(Object.Vector ClothValidBoundsMin, Object.Vector ClothValidBoundsMax)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execFindAnimSequence(FFrame&, void* const)
	//public virtual /*native final function */AnimSequence FindAnimSequence(name AnimSeqName)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export USkeletalMeshComponent::execSaveAnimSets(FFrame&, void* const)
	public virtual /*native final function */void SaveAnimSets()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execRestoreSavedAnimSets(FFrame&, void* const)
	public virtual /*native final function */void RestoreSavedAnimSets()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*final function */float GetAnimRateByDuration(name AnimSeqName, float Duration)
	{
		/*local */AnimSequence AnimSeq = default;
	
		AnimSeq = FindAnimSequence(AnimSeqName);
		if(AnimSeq == default)
		{
			return 1.0f;
		}
		return AnimSeq.SequenceLength / Duration;
	}
	
	public virtual /*final function */float GetAnimLength(name AnimSeqName)
	{
		/*local */AnimSequence AnimSeq = default;
	
		AnimSeq = FindAnimSequence(AnimSeqName);
		if(AnimSeq == default)
		{
			return 0.0f;
		}
		return AnimSeq.SequenceLength / AnimSeq.RateScale;
	}
	
	// Export USkeletalMeshComponent::execFindMorphTarget(FFrame&, void* const)
	public virtual /*native final function */MorphTarget FindMorphTarget(name MorphTargetName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	//// Export USkeletalMeshComponent::execFindAnimNode(FFrame&, void* const)
	//public virtual /*native final function */AnimNode FindAnimNode(name InNodeName)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	//
	//// Export USkeletalMeshComponent::execAllAnimNodes(FFrame&, void* const)
	//public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<AnimNode/* Node*/> AllAnimNodes(Core.ClassT<AnimNode> BaseClass)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	yield break;
	//}
	//
	//// Export USkeletalMeshComponent::execFindSkelControl(FFrame&, void* const)
	//public virtual /*native final function */SkelControlBase FindSkelControl(name InControlName)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	//
	//// Export USkeletalMeshComponent::execFindMorphNode(FFrame&, void* const)
	//public virtual /*native final function */MorphNodeBase FindMorphNode(name InNodeName)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	//
	//// Export USkeletalMeshComponent::execGetBoneQuaternion(FFrame&, void* const)
	//public virtual /*native final function */Object.Quat GetBoneQuaternion(name BoneName, /*optional */int? _Space = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	//
	//// Export USkeletalMeshComponent::execGetBoneLocation(FFrame&, void* const)
	//public virtual /*native final function */Object.Vector GetBoneLocation(name BoneName, /*optional */int? _Space = default)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	//
	//// Export USkeletalMeshComponent::execMatchRefBone(FFrame&, void* const)
	//public virtual /*native final function */int MatchRefBone(name BoneName)
	//{
	//	NativeMarkers.MarkUnimplemented();
	//	return default;
	//}
	
	// Export USkeletalMeshComponent::execGetBoneMatrix(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetBoneMatrix(int BoneIndex)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetParentBone(FFrame&, void* const)
	public virtual /*native final function */name GetParentBone(name BoneName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetBoneNames(FFrame&, void* const)
	public virtual /*native final function */void GetBoneNames(ref array<name> BoneNames)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execGetBoneAxis(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetBoneAxis(name BoneName, Object.EAxis Axis)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execTransformToBoneSpace(FFrame&, void* const)
	public virtual /*native final function */void TransformToBoneSpace(name BoneName, Object.Vector InPosition, Object.Rotator InRotation, ref Object.Vector OutPosition, ref Object.Rotator OutRotation)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execTransformFromBoneSpace(FFrame&, void* const)
	public virtual /*native final function */void TransformFromBoneSpace(name BoneName, Object.Vector InPosition, Object.Rotator InRotation, ref Object.Vector OutPosition, ref Object.Rotator OutRotation)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execFindClosestBone(FFrame&, void* const)
	public virtual /*native final function */name FindClosestBone(Object.Vector TestLocation, /*optional */ref Object.Vector BoneLocation/* = default*/, /*optional */float? _IgnoreScale = default)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetAnimTreeTemplate(FFrame&, void* const)
	public virtual /*native final function */void SetAnimTreeTemplate(AnimTree NewTemplate)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetParentAnimComponent(FFrame&, void* const)
	public virtual /*native final function */void SetParentAnimComponent(SkeletalMeshComponent NewParentAnimComp)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execUpdateParentBoneMap(FFrame&, void* const)
	public virtual /*native final function */void UpdateParentBoneMap()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execInitSkelControls(FFrame&, void* const)
	public virtual /*native final function */void InitSkelControls()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execFindConstraintIndex(FFrame&, void* const)
	public virtual /*native final function */int FindConstraintIndex(name ConstraintName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindConstraintBoneName(FFrame&, void* const)
	public virtual /*native final function */name FindConstraintBoneName(int ConstraintIndex)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindBodyInstanceNamed(FFrame&, void* const)
	public virtual /*native final function */RB_BodyInstance FindBodyInstanceNamed(name BoneName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetHasPhysicsAssetInstance(FFrame&, void* const)
	public virtual /*native final function */void SetHasPhysicsAssetInstance(bool bHasInstance)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execUpdateRBBonesFromSpaceBases(FFrame&, void* const)
	public virtual /*native final function */void UpdateRBBonesFromSpaceBases(bool bMoveUnfixedBodies, bool bTeleport)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	//// Export USkeletalMeshComponent::execForceSkelUpdate(FFrame&, void* const)
	//public virtual /*native final function */void ForceSkelUpdate()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	//
	//// Export USkeletalMeshComponent::execUpdateAnimations(FFrame&, void* const)
	//public virtual /*native final function */void UpdateAnimations()
	//{
	//	NativeMarkers.MarkUnimplemented();
	//}
	
	// Export USkeletalMeshComponent::execGetBonesWithinRadius(FFrame&, void* const)
	public virtual /*native final function */bool GetBonesWithinRadius(Object.Vector Origin, float Radius, int TraceFlags, ref array<name> out_Bones)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execPlayFaceFXAnim(FFrame&, void* const)
	public virtual /*native final function */bool PlayFaceFXAnim(FaceFXAnimSet FaceFXAnimSetRef, String AnimName, String GroupName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execStopFaceFXAnim(FFrame&, void* const)
	public virtual /*native final function */void StopFaceFXAnim()
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execIsPlayingFaceFXAnim(FFrame&, void* const)
	public virtual /*native final function */bool IsPlayingFaceFXAnim()
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execDeclareFaceFXRegister(FFrame&, void* const)
	public virtual /*native final function */void DeclareFaceFXRegister(String RegName)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execGetFaceFXRegister(FFrame&, void* const)
	public virtual /*native final function */float GetFaceFXRegister(String RegName)
	{
		NativeMarkers.MarkUnimplemented();
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetFaceFXRegister(FFrame&, void* const)
	public virtual /*native final function */void SetFaceFXRegister(String RegName, float RegVal, SkeletalMeshComponent.EFaceFXRegOp RegOp, /*optional */float? _InterpDuration = default)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	// Export USkeletalMeshComponent::execSetFaceFXRegisterEx(FFrame&, void* const)
	public virtual /*native final function */void SetFaceFXRegisterEx(String RegName, SkeletalMeshComponent.EFaceFXRegOp RegOp, float FirstValue, float FirstInterpDuration, float NextValue, float NextInterpDuration)
	{
		NativeMarkers.MarkUnimplemented();
	}
	
	public virtual /*function */void PlayAnim(name AnimName, /*optional */float? _Duration = default, /*optional */bool? _bLoop = default, /*optional */bool? _bRestartIfAlreadyPlaying = default)
	{
		/*local */AnimNodeSequence AnimNode = default;
		/*local */float DesiredRate = default;
	
		var Duration = _Duration ?? default;
		var bLoop = _bLoop ?? default;
		var bRestartIfAlreadyPlaying = _bRestartIfAlreadyPlaying ?? true;
		AnimNode = ((Animations) as AnimNodeSequence);
		if((AnimNode == default) && Animations.IsA("AnimTree"))
		{
			AnimNode = ((((Animations) as AnimTree).Children[0].Anim) as AnimNodeSequence);
		}
		if(AnimNode == default)
		{		
		}
		else
		{
			if((AnimNode.AnimSeq != default) && AnimNode.AnimSeq.SequenceName == AnimName)
			{
				DesiredRate = ((Duration > 0.0f) ? AnimNode.AnimSeq.SequenceLength / Duration : 1.0f);
				if((bRestartIfAlreadyPlaying || !AnimNode.bPlaying))
				{
					AnimNode.PlayAnim(bLoop, DesiredRate, default(float?));				
				}
				else
				{
					AnimNode.Rate = DesiredRate;
					AnimNode.bLooping = bLoop;
				}			
			}
			else
			{
				AnimNode.SetAnim(AnimName);
				if(AnimNode.AnimSeq != default)
				{
					DesiredRate = ((Duration > 0.0f) ? AnimNode.AnimSeq.SequenceLength / Duration : 1.0f);
					AnimNode.PlayAnim(bLoop, DesiredRate, default(float?));
				}
			}
		}
	}
	
	public virtual /*function */void StopAnim()
	{
		/*local */AnimNodeSequence AnimNode = default;
	
		AnimNode = ((Animations) as AnimNodeSequence);
		if((AnimNode == default) && Animations.IsA("AnimTree"))
		{
			AnimNode = ((((Animations) as AnimTree).Children[0].Anim) as AnimNodeSequence);
		}
		if(AnimNode == default)
		{		
		}
		else
		{
			AnimNode.StopAnim();
		}
	}
	
	public SkeletalMeshComponent()
	{
		// Object Offset:0x002F339B
		GlobalAnimRateScale = 1.0f;
		WireframeColor = new Color
		{
			R=221,
			G=221,
			B=28,
			A=255
		};
		bTransformFromAnimParent = 1;
		bUpdateSkelWhenNotRendered = true;
		bUpdateKinematicBonesFromAnimation = true;
		bSyncActorLocationToRootRigidBody = true;
		LineCheckBoundsScale = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		bCacheAnimSequenceNodes = true;
		ClothBlendWeight = 1.0f;
		ClothMaxBlendDistance = -1.0f;
		ClothRBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_Cloth;
		ValidBoundsMin = new Vector
		{
			X=-500.0f,
			Y=-500.0f,
			Z=-500.0f
		};
		ValidBoundsMax = new Vector
		{
			X=500.0f,
			Y=500.0f,
			Z=500.0f
		};
		ClothAttachmentTearFactor = -1.0f;
		RootMotionAccelScale = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		RootMotionMode = SkeletalMeshComponent.ERootMotionMode.RMM_Ignore;
		PreviousRMM = SkeletalMeshComponent.ERootMotionMode.RMM_Ignore;
		FaceFXBlendMode = SkeletalMeshComponent.EFaceFXBlendMode.FXBM_Additive;
		TickGroup = Object.ETickingGroup.TG_PreAsyncWork;
		
		// Not sure where this is supposed to be assigned but I need this to not be null for now
		PhysicsAssetInstance = new PhysicsAssetInstance();
	}
}
}