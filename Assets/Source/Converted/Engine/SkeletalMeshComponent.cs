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
		public/*()*/ /*export editinline */ActorComponent Component;
		public/*()*/ name BoneName;
		public/*()*/ Object.Vector RelativeLocation;
		public/*()*/ Object.Rotator RelativeRotation;
		public/*()*/ Object.Vector RelativeScale;
	
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
	
	public/*()*/ SkeletalMesh SkeletalMesh;
	public /*export editinline */SkeletalMeshComponent AttachedToSkelComponent;
	public Object.Matrix LocalToLegRotatedWorld;
	public bool bUseLegRotationHack1;
	public/*()*/ /*const */AnimTree AnimTreeTemplate;
	public/*()*/ /*const export editinline */AnimNode Animations;
	public /*const transient */array<AnimNode> AnimTickArray;
	public/*()*/ /*const */PhysicsAsset PhysicsAsset;
	public /*const export editinline transient */PhysicsAssetInstance PhysicsAssetInstance;
	public/*()*/ float PhysicsWeight;
	public/*()*/ float GlobalAnimRateScale;
	public /*native const transient */Object.Pointer MeshObject;
	public/*()*/ Object.Color WireframeColor;
	public /*native const transient */array<Object.Matrix> SpaceBases;
	public /*native const transient */array<AnimNode.BoneAtom> LocalAtoms;
	public /*native const transient */array<byte> RequiredBones;
	public/*()*/ /*const export editinline */SkeletalMeshComponent ParentAnimComponent;
	public /*native const transient */array<int> ParentBoneMap;
	public/*()*/ array<AnimSet> AnimSets;
	public /*native const transient */array<AnimSet> TemporarySavedAnimSets;
	public/*()*/ array<MorphTargetSet> MorphSets;
	public array<SkeletalMeshComponent.ActiveMorph> ActiveMorphs;
	public /*duplicatetransient const */array<SkeletalMeshComponent.Attachment> Attachments;
	public /*const transient */array<byte> SkelControlIndex;
	public/*()*/ int ForcedLodModel;
	public int PredictedLODLevel;
	public int OldPredictedLODLevel;
	public /*const */float MaxDistanceFactor;
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
	public /*const transient */int TickTag;
	public /*const transient */int CachedAtomsTag;
	public /*const */int bUseSingleBodyPhysics;
	public /*transient */int bRequiredBonesUpToDate;
	public float MinDistFactorForKinematicUpdate;
	public name PhysicsBlendZeroDriftBoneName;
	public /*transient */int FramesPhysicsAsleep;
	public bool bSkipAllUpdateWhenPhysicsAsleep;
	public bool bUpdateSkelWhenNotRendered;
	public bool bIgnoreControllersWhenNotRendered;
	public /*const */bool bNotUpdatingKinematicDueToDistance;
	public/*()*/ bool bForceDiscardRootMotion;
	public bool bRootMotionModeChangeNotify;
	public bool bRootMotionExtractedNotify;
	public/*()*/ bool bDisableFaceFXMaterialInstanceCreation;
	public /*const transient */bool bAnimTreeInitialised;
	public/*()*/ /*const */bool bHasPhysicsAssetInstance;
	public/*()*/ bool bUpdateKinematicBonesFromAnimation;
	public/*()*/ bool bUpdateJointsFromAnimation;
	public /*const */bool bSkelCompFixed;
	public /*const */bool bHasHadPhysicsBlendedIn;
	public/*()*/ bool bForceUpdateAttachmentsInTick;
	public/*()*/ bool bEnableFullAnimWeightBodies;
	public/*()*/ bool bPerBoneVolumeEffects;
	public/*()*/ bool bSyncActorLocationToRootRigidBody;
	public /*const */bool bUseRawData;
	public bool bDisableWarningWhenAnimNotFound;
	public bool bOverrideAttachmentOwnerVisibility;
	public bool bPauseAnims;
	public bool bChartDistanceFactor;
	public bool bEnableLineCheckWithBounds;
	public Object.Vector LineCheckBoundsScale;
	public/*(Cloth)*/ /*const */bool bEnableClothSimulation;
	public/*(Cloth)*/ /*const */bool bDisableClothCollision;
	public/*(Cloth)*/ /*const */bool bClothFrozen;
	public/*(Cloth)*/ bool bAutoFreezeClothWhenNotRendered;
	public/*(Cloth)*/ bool bClothBaseVelClamp;
	public/*(Cloth)*/ bool bAttachClothVertsToBaseBody;
	public bool bCacheAnimSequenceNodes;
	public bool bForceMeshObjectUpdates;
	public/*(Cloth)*/ /*const */Object.Vector ClothExternalForce;
	public/*(Cloth)*/ Object.Vector ClothWind;
	public/*(Cloth)*/ Object.Vector ClothBaseVelClampRange;
	public/*(Cloth)*/ float ClothBlendWeight;
	public float ClothDynamicBlendWeight;
	public/*(Cloth)*/ float ClothMinBlendDistance;
	public/*(Cloth)*/ float ClothMaxBlendDistance;
	public /*native const transient */Object.Pointer ClothSim;
	public /*native const transient */int SceneIndex;
	public /*const */array<Object.Vector> ClothMeshPosData;
	public /*const */array<Object.Vector> ClothMeshNormalData;
	public /*const */array<int> ClothMeshIndexData;
	public int NumClothMeshVerts;
	public int NumClothMeshIndices;
	public /*const */array<int> ClothMeshParentData;
	public int NumClothMeshParentIndices;
	public /*native const transient */array<Object.Vector> ClothMeshWeldedPosData;
	public /*native const transient */array<Object.Vector> ClothMeshWeldedNormalData;
	public /*native const transient */array<int> ClothMeshWeldedIndexData;
	public int ClothDirtyBufferFlag;
	public/*(Cloth)*/ /*const */PrimitiveComponent.ERBCollisionChannel ClothRBChannel;
	public/*(Cloth)*/ /*const */PrimitiveComponent.RBCollisionChannelContainer ClothRBCollideWithChannels;
	public/*(Cloth)*/ /*const */float ClothForceScale;
	public/*(Cloth)*/ bool bEnableValidBounds;
	public/*(Cloth)*/ Object.Vector ValidBoundsMin;
	public/*(Cloth)*/ Object.Vector ValidBoundsMax;
	public/*(Cloth)*/ /*const */float ClothAttachmentTearFactor;
	public Material LimitMaterial;
	public /*const transient */AnimNode.BoneAtom RootMotionDelta;
	public /*transient */Object.Vector RootMotionVelocity;
	public /*const transient */Object.Vector RootBoneTranslation;
	public Object.Vector RootMotionAccelScale;
	public/*()*/ SkeletalMeshComponent.ERootMotionMode RootMotionMode;
	public /*const */SkeletalMeshComponent.ERootMotionMode PreviousRMM;
	public SkeletalMeshComponent.ERootMotionMode PendingRMM;
	public SkeletalMeshComponent.ERootMotionMode OldPendingRMM;
	public /*const */int bRMMOneFrameDelay;
	public/*()*/ SkeletalMeshComponent.ERootMotionRotationMode RootMotionRotationMode;
	public/*()*/ SkeletalMeshComponent.EFaceFXBlendMode FaceFXBlendMode;
	public /*native transient */Object.Pointer FaceFXActorInstance;
	public /*export editinline */AudioComponent CachedFaceFXAudioComp;
	
	// Export USkeletalMeshComponent::execAttachComponent(FFrame&, void* const)
	public virtual /*native final function */void AttachComponent(ActorComponent Component, name BoneName, /*optional */Object.Vector RelativeLocation = default, /*optional */Object.Rotator RelativeRotation = default, /*optional */Object.Vector RelativeScale = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execDetachComponent(FFrame&, void* const)
	public virtual /*native final function */void DetachComponent(ActorComponent Component)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execAttachComponentToSocket(FFrame&, void* const)
	public virtual /*native final function */void AttachComponentToSocket(ActorComponent Component, name SocketName)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execGetSocketWorldLocationAndRotation(FFrame&, void* const)
	public virtual /*native final function */bool GetSocketWorldLocationAndRotation(name InSocketName, ref Object.Vector OutLocation, /*optional */ref Object.Rotator OutRotation/* = default*/)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetSocketByName(FFrame&, void* const)
	public virtual /*native final function */SkeletalMeshSocket GetSocketByName(name InSocketName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindComponentAttachedToBone(FFrame&, void* const)
	public virtual /*native final function */ActorComponent FindComponentAttachedToBone(name InBoneName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execIsComponentAttached(FFrame&, void* const)
	public virtual /*native final function */bool IsComponentAttached(ActorComponent Component, /*optional */name BoneName = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execAttachedComponents(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<ActorComponent/* OutComponent*/> AttachedComponents(Core.ClassT<ActorComponent> BaseClass)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	// Export USkeletalMeshComponent::execSetSkeletalMesh(FFrame&, void* const)
	public virtual /*native final simulated function */void SetSkeletalMesh(SkeletalMesh NewMesh, /*optional */bool bKeepSpaceBases = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetPhysicsAsset(FFrame&, void* const)
	public virtual /*native final simulated function */void SetPhysicsAsset(PhysicsAsset NewPhysicsAsset, /*optional */bool bForceReInit = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetForceRefPose(FFrame&, void* const)
	public virtual /*native final simulated function */void SetForceRefPose(bool bNewForceRefPose)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetEnableClothSimulation(FFrame&, void* const)
	public virtual /*native final simulated function */void SetEnableClothSimulation(bool bInEnable)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothFrozen(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothFrozen(bool bNewFrozen)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execUpdateClothParams(FFrame&, void* const)
	public virtual /*native final simulated function */void UpdateClothParams()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothExternalForce(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothExternalForce(Object.Vector InForce)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetAttachClothVertsToBaseBody(FFrame&, void* const)
	public virtual /*native final simulated function */void SetAttachClothVertsToBaseBody(bool bAttachVerts)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execResetClothVertsToRefPose(FFrame&, void* const)
	public virtual /*native final simulated function */void ResetClothVertsToRefPose()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execAddImpulseAtClothPos(FFrame&, void* const)
	public virtual /*native final simulated function */void AddImpulseAtClothPos(Object.Vector Position, Object.Vector Impulse, float Radius)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execGetClothAttachmentResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothAttachmentResponseCoefficient()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothAttachmentTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothAttachmentTearFactor()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothBendingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothBendingStiffness()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothCollisionResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothCollisionResponseCoefficient()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothDampingCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothDampingCoefficient()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothFlags(FFrame&, void* const)
	public virtual /*native final simulated function */int GetClothFlags()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothFriction(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothFriction()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothPressure(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothPressure()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothSleepLinearVelocity(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothSleepLinearVelocity()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothSolverIterations(FFrame&, void* const)
	public virtual /*native final simulated function */int GetClothSolverIterations()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothStretchingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothStretchingStiffness()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothTearFactor()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetClothThickness(FFrame&, void* const)
	public virtual /*native final simulated function */float GetClothThickness()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetClothAttachmentResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothAttachmentResponseCoefficient(float ClothAttachmentResponseCoefficient)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothAttachmentTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothAttachmentTearFactor(float ClothAttachTearFactor)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothBendingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothBendingStiffness(float ClothBendingStiffness)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothCollisionResponseCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothCollisionResponseCoefficient(float ClothCollisionResponseCoefficient)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothDampingCoefficient(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothDampingCoefficient(float ClothDampingCoefficient)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothFlags(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothFlags(int ClothFlags)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothFriction(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothFriction(float ClothFriction)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothPressure(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothPressure(float ClothPressure)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothSleepLinearVelocity(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothSleepLinearVelocity(float ClothSleepLinearVelocity)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothSolverIterations(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothSolverIterations(int ClothSolverIterations)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothStretchingStiffness(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothStretchingStiffness(float ClothStretchingStiffness)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothTearFactor(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothTearFactor(float ClothTearFactor)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothThickness(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothThickness(float ClothThickness)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothSleep(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothSleep(bool IfClothSleep)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothPosition(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothPosition(Object.Vector ClothOffSet)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothVelocity(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothVelocity(Object.Vector VelocityOffSet)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execAttachClothToCollidingShapes(FFrame&, void* const)
	public virtual /*native final simulated function */void AttachClothToCollidingShapes(bool AttatchTwoWay, bool AttachTearable)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execEnableClothValidBounds(FFrame&, void* const)
	public virtual /*native final simulated function */void EnableClothValidBounds(bool IfEnableClothValidBounds)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetClothValidBounds(FFrame&, void* const)
	public virtual /*native final simulated function */void SetClothValidBounds(Object.Vector ClothValidBoundsMin, Object.Vector ClothValidBoundsMax)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execFindAnimSequence(FFrame&, void* const)
	public virtual /*native final function */AnimSequence FindAnimSequence(name AnimSeqName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execSaveAnimSets(FFrame&, void* const)
	public virtual /*native final function */void SaveAnimSets()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execRestoreSavedAnimSets(FFrame&, void* const)
	public virtual /*native final function */void RestoreSavedAnimSets()
	{
		#warning NATIVE FUNCTION !
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
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindAnimNode(FFrame&, void* const)
	public virtual /*native final function */AnimNode FindAnimNode(name InNodeName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execAllAnimNodes(FFrame&, void* const)
	public virtual /*native final iterator function */System.Collections.Generic.IEnumerable<AnimNode/* Node*/> AllAnimNodes(Core.ClassT<AnimNode> BaseClass)
	{
		#warning NATIVE FUNCTION !
		yield return default;
	}
	
	// Export USkeletalMeshComponent::execFindSkelControl(FFrame&, void* const)
	public virtual /*native final function */SkelControlBase FindSkelControl(name InControlName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindMorphNode(FFrame&, void* const)
	public virtual /*native final function */MorphNodeBase FindMorphNode(name InNodeName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetBoneQuaternion(FFrame&, void* const)
	public virtual /*native final function */Object.Quat GetBoneQuaternion(name BoneName, /*optional */int Space = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetBoneLocation(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetBoneLocation(name BoneName, /*optional */int Space = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execMatchRefBone(FFrame&, void* const)
	public virtual /*native final function */int MatchRefBone(name BoneName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetBoneMatrix(FFrame&, void* const)
	public virtual /*native final function */Object.Matrix GetBoneMatrix(int BoneIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetParentBone(FFrame&, void* const)
	public virtual /*native final function */name GetParentBone(name BoneName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execGetBoneNames(FFrame&, void* const)
	public virtual /*native final function */void GetBoneNames(ref array<name> BoneNames)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execGetBoneAxis(FFrame&, void* const)
	public virtual /*native final function */Object.Vector GetBoneAxis(name BoneName, Object.EAxis Axis)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execTransformToBoneSpace(FFrame&, void* const)
	public virtual /*native final function */void TransformToBoneSpace(name BoneName, Object.Vector InPosition, Object.Rotator InRotation, ref Object.Vector OutPosition, ref Object.Rotator OutRotation)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execTransformFromBoneSpace(FFrame&, void* const)
	public virtual /*native final function */void TransformFromBoneSpace(name BoneName, Object.Vector InPosition, Object.Rotator InRotation, ref Object.Vector OutPosition, ref Object.Rotator OutRotation)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execFindClosestBone(FFrame&, void* const)
	public virtual /*native final function */name FindClosestBone(Object.Vector TestLocation, /*optional */ref Object.Vector BoneLocation/* = default*/, /*optional */float IgnoreScale = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetAnimTreeTemplate(FFrame&, void* const)
	public virtual /*native final function */void SetAnimTreeTemplate(AnimTree NewTemplate)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetParentAnimComponent(FFrame&, void* const)
	public virtual /*native final function */void SetParentAnimComponent(SkeletalMeshComponent NewParentAnimComp)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execUpdateParentBoneMap(FFrame&, void* const)
	public virtual /*native final function */void UpdateParentBoneMap()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execInitSkelControls(FFrame&, void* const)
	public virtual /*native final function */void InitSkelControls()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execFindConstraintIndex(FFrame&, void* const)
	public virtual /*native final function */int FindConstraintIndex(name ConstraintName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindConstraintBoneName(FFrame&, void* const)
	public virtual /*native final function */name FindConstraintBoneName(int ConstraintIndex)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execFindBodyInstanceNamed(FFrame&, void* const)
	public virtual /*native final function */RB_BodyInstance FindBodyInstanceNamed(name BoneName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetHasPhysicsAssetInstance(FFrame&, void* const)
	public virtual /*native final function */void SetHasPhysicsAssetInstance(bool bHasInstance)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execUpdateRBBonesFromSpaceBases(FFrame&, void* const)
	public virtual /*native final function */void UpdateRBBonesFromSpaceBases(bool bMoveUnfixedBodies, bool bTeleport)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execForceSkelUpdate(FFrame&, void* const)
	public virtual /*native final function */void ForceSkelUpdate()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execUpdateAnimations(FFrame&, void* const)
	public virtual /*native final function */void UpdateAnimations()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execGetBonesWithinRadius(FFrame&, void* const)
	public virtual /*native final function */bool GetBonesWithinRadius(Object.Vector Origin, float Radius, int TraceFlags, ref array<name> out_Bones)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execPlayFaceFXAnim(FFrame&, void* const)
	public virtual /*native final function */bool PlayFaceFXAnim(FaceFXAnimSet FaceFXAnimSetRef, string AnimName, string GroupName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execStopFaceFXAnim(FFrame&, void* const)
	public virtual /*native final function */void StopFaceFXAnim()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execIsPlayingFaceFXAnim(FFrame&, void* const)
	public virtual /*native final function */bool IsPlayingFaceFXAnim()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execDeclareFaceFXRegister(FFrame&, void* const)
	public virtual /*native final function */void DeclareFaceFXRegister(string RegName)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execGetFaceFXRegister(FFrame&, void* const)
	public virtual /*native final function */float GetFaceFXRegister(string RegName)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export USkeletalMeshComponent::execSetFaceFXRegister(FFrame&, void* const)
	public virtual /*native final function */void SetFaceFXRegister(string RegName, float RegVal, SkeletalMeshComponent.EFaceFXRegOp RegOp, /*optional */float InterpDuration = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export USkeletalMeshComponent::execSetFaceFXRegisterEx(FFrame&, void* const)
	public virtual /*native final function */void SetFaceFXRegisterEx(string RegName, SkeletalMeshComponent.EFaceFXRegOp RegOp, float FirstValue, float FirstInterpDuration, float NextValue, float NextInterpDuration)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void PlayAnim(name AnimName, /*optional */float Duration = default, /*optional */bool bLoop = default, /*optional */bool bRestartIfAlreadyPlaying = default)
	{
		/*local */AnimNodeSequence AnimNode = default;
		/*local */float DesiredRate = default;
	
		bRestartIfAlreadyPlaying = true;
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
				if(bRestartIfAlreadyPlaying || !AnimNode.bPlaying)
				{
					AnimNode.PlayAnim(bLoop, DesiredRate, default(float));				
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
					AnimNode.PlayAnim(bLoop, DesiredRate, default(float));
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
	}
}
}