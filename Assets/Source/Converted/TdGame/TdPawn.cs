// NO OVERWRITE

namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdPawn : GamePawn/*
		native
		nativereplication
		config(Game)
		notplaceable
		hidecategories(Navigation)*/{
	public const double DEFAULT_ROOTOFFSET_BLENDTIME = 0.3f;
	
	public enum MoveAimMode 
	{
		MAM_Left,
		MAM_Right,
		MAM_TwoHanded,
		MAM_NoHands,
		MAM_Default,
		MAM_MAX
	};
	
	public enum CustomNodeType 
	{
		CNT_Canned,
		CNT_CannedUpperBody,
		CNT_FullBody,
		CNT_FullBody_Dir,
		CNT_UpperBody,
		CNT_LowerBody,
		CNT_Camera,
		CNT_Weapon,
		CNT_Face,
		CNT_MAX
	};
	
	public enum EWeaponAnimState 
	{
		WS_Unarmed,
		WS_Relaxed,
		WS_Ready,
		WS_Reload,
		WS_Throwing,
		WS_HeavyArmed,
		WS_Holster,
		WS_MAX
	};
	
	public enum EAgainstWallState 
	{
		AW_None,
		AW_AgainstWall,
		AW_AgainstWallLeft,
		AW_AgainstWallRight,
		AW_MAX
	};
	
	public enum EGrabTurnType 
	{
		GTT_None,
		GTT_Start,
		GTT_End,
		GTT_Idle,
		GTT_MAX
	};
	
	public enum EMovement 
	{
		MOVE_None,
		MOVE_Walking,
		MOVE_Falling,
		MOVE_Grabbing,
		MOVE_WallRunningRight,
		MOVE_WallRunningLeft,
		MOVE_WallClimbing,
		MOVE_SpringBoarding,
		MOVE_SpeedVaulting,
		MOVE_VaultOver,
		MOVE_GrabPullUp,
		MOVE_Jump,
		MOVE_WallRunJump,
		MOVE_GrabJump,
		MOVE_IntoGrab,
		MOVE_Crouch,
		MOVE_Slide,
		MOVE_Melee,
		MOVE_Snatch,
		MOVE_Barge,
		MOVE_Landing,
		MOVE_Climb,
		MOVE_IntoClimb,
		MOVE_WallKick,
		MOVE_180Turn,
		MOVE_180TurnInAir,
		MOVE_LayOnGround,
		MOVE_IntoZipLine,
		MOVE_ZipLine,
		MOVE_Balance,
		MOVE_LedgeWalk,
		MOVE_GrabTransfer,
		MOVE_MeleeAir,
		MOVE_DodgeJump,
		MOVE_WallRunDodgeJump,
		MOVE_Stumble,
		MOVE_Snatched,
		MOVE_StepUp,
		MOVE_RumpSlide,
		MOVE_Interact,
		MOVE_WallRun,
		MOVE_BotStop,
		MOVE_BotStartWalking,
		MOVE_BotStartRunning,
		MOVE_BotTurnRunning,
		MOVE_BotTurnStanding,
		MOVE_ExitCover,
		MOVE_Vertigo,
		MOVE_MeleeSlide,
		MOVE_WallClimbDodgeJump,
		MOVE_WallClimb180TurnJump,
		MOVE_WallClimbDodgeJumpLeft,
		MOVE_WallClimbDodgeJumpRight,
		MOVE_MeleeVault,
		MOVE_BotMeleeSecondSwing,
		MOVE_StumbleHard,
		MOVE_BotRoll,
		MOVE_BotFlip,
		MOVE_Backflip_OBSOLETE,
		MOVE_BackflipToRun_OBSOLETE,
		MOVE_Swing,
		MOVE_Coil,
		MOVE_MeleeWallrun,
		MOVE_MeleeCrouch,
		MOVE_BotJumpShort,
		MOVE_BotJumpMedium,
		MOVE_BotJumpLong,
		MOVE_JumpIntoGrab,
		MOVE_StandGrabHeaveBot,
		MOVE_BotMeleeDodge,
		MOVE_FinishAttack,
		MOVE_MeleeBarge,
		MOVE_FallingUncontrolled,
		MOVE_SwingJump,
		MOVE_AnimationPlayback,
		MOVE_EnterCover,
		MOVE_Cover,
		MOVE_StumbleFalling,
		MOVE_SoftLanding,
		MOVE_HeadButtedByCeleste,
		MOVE_MeleeOriginalCeleste_OBSOLETE,
		MOVE_AutoStepUp,
		MOVE_MeleeAirAbove,
		MOVE_MeleeCounterAttack_OBSOLETE,
		MOVE_Block,
		MOVE_AirBarge,
		MOVE_RB_Bullrush_OBSOLETE,
		MOVE_RB_Bullrush_End_OBSOLETE,
		MOVE_RB_HitWall_OBSOLETE,
		MOVE_RB_HitFence_OBSOLETE,
		MOVE_RB_Ledge_OBSOLETE,
		MOVE_SkillRoll,
		MOVE_BotGetDistance,
		MOVE_Cutscene,
		MOVE_MAX
	};
	
	public enum EMovementAction 
	{
		MA_None,
		MA_Jump,
		MA_StopJump,
		MA_Melee,
		MA_Snatch,
		MA_Crouch,
		MA_StopCrouch,
		MA_ClimbUp,
		MA_ClimbDown,
		MA_ClimbUpLong,
		MA_ClimbDownLong,
		MA_Abort,
		MA_ShimmyLeft,
		MA_ShimmyLeftLong,
		MA_ShimmyRight,
		MA_ShimmyRightLong,
		MA_Turn,
		MA_Stumble,
		MA_StumbleHard,
		MA_MAX
	};
	
	public enum EMoveActionHint 
	{
		MAH_None,
		MAH_Left,
		MAH_Right,
		MAH_Up,
		MAH_Down,
		MAH_MAX
	};
	
	public enum WalkingState 
	{
		WAS_Idle,
		WAS_Sneak,
		WAS_Walk,
		WAS_Jog,
		WAS_Run,
		WAS_Sprint,
		WAS_None,
		WAS_MAX
	};
	
	public enum EMeleeServerAction 
	{
		MSA_TriggerMove,
		MSA_TriggerHit,
		MSA_TriggerMiss,
		MSA_MAX
	};
	
	public enum EWeaponType 
	{
		EWT_None,
		EWT_Heavy,
		EWT_Light,
		EWT_MAX
	};
	
	public enum EMeleeImpactType 
	{
		MIT_Gun,
		MIT_Fist,
		MIT_Foot,
		MIT_Block,
		MIT_MAX
	};
	
	public partial struct /*native */PawnFootPlacementTrace
	{
		public /*transient */bool bHitLeftFoot;
		public /*transient */bool bHitRightFoot;
		public /*transient */Object.Vector LeftFootLocation;
		public /*transient */Object.Vector RightFootLocation;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004CE3E3
	//		bHitLeftFoot = false;
	//		bHitRightFoot = false;
	//		LeftFootLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		RightFootLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//	}
	};
	
	public partial struct /*native */ReplicatedCustomAnimation
	{
		public String AnimName;
		public TdPawn.CustomNodeType NodeType;
		public float BlendInTime;
		public float BlendOutTime;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004CA852
	//		AnimName = "";
	//		NodeType = TdPawn.CustomNodeType.CNT_Canned;
	//		BlendInTime = 0.0f;
	//		BlendOutTime = 0.0f;
	//	}
	};
	
	public partial struct /*native */LedgeHitInfo
	{
		public Object.Vector LedgeLocation;
		public Object.Vector LedgeNormal;
		public Object.Vector MoveNormal;
		public Actor MoveActor;
		public bool FeetExcluded;
		public bool HandsExcluded;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004CAA16
	//		LedgeLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		LedgeNormal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		MoveNormal = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		MoveActor = default;
	//		FeetExcluded = false;
	//		HandsExcluded = false;
	//	}
	};
	
	public partial struct /*native */PhysicalHitInfo
	{
		public Object.Vector HitLocation;
		public Object.Vector Momentum;
		public float AngularVelocity;
		public Core.ClassT<TdDamageType> DamageType;
		public name HitBone;
		public float HitReactionDuration;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004CACB6
	//		HitLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Momentum = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		AngularVelocity = 0.0f;
	//		DamageType = default;
	//		HitBone = (name)"None";
	//		HitReactionDuration = 0.0f;
	//	}
	};
	
	public partial struct /*native */ArmorSettings
	{
		public float Easy;
		public float Medium;
		public float Hard;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004CAE3E
	//		Easy = 0.0f;
	//		Medium = 0.0f;
	//		Hard = 0.0f;
	//	}
	};
	
	public partial struct /*native */FootstepLogInfo
	{
		public float Time;
		public int FootDown;
		public byte R;
		public byte G;
		public byte B;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004CAFB2
	//		Time = 0.0f;
	//		FootDown = 0;
	//		R = 255;
	//		G = 255;
	//		B = 255;
	//	}
	};
	
	public SkelControlSingleBone RootControl1p;
	public SkelControlSingleBone HipsControl1p;
	public SkelControlSingleBone HipsControl3p;
	public SkelControlSingleBone RootControl3p;
	public SkelControlSingleBone SwingControl1p;
	public SkelControlSingleBone SwingControl3p;
	public SkelControlSingleBone CameraControl1p;
	public SkelControlSingleBone OneHandedRightShoulderOffset1p;
	public TdSkelControlFootPlacement LeftLegControl1p;
	public TdSkelControlFootPlacement LeftLegControl3p;
	public TdSkelControlFootPlacement RightLegControl1p;
	public TdSkelControlFootPlacement RightLegControl3p;
	public TdSkelControlRecoil RecoilControl1p;
	public/*(IK)*/ /*editinline */TdSkelControlLimb LeftHandWorldIKController;
	public/*(IK)*/ /*editinline */TdSkelControlLimb RightHandWorldIKController;
	public/*(IK)*/ /*editinline */SkelControlLimb LeftHandLocalIKController;
	public/*(IK)*/ /*editinline */SkelControlLimb RightHandLocalIKController;
	public/*(IK)*/ /*editinline */SkelControlSingleBone RightHandRotationController;
	public/*(IK)*/ /*editinline */SkelControlSingleBone LeftHandRotationController;
	public/*(IK)*/ /*editinline */TdSkelControlSpring HeavyWeaponSpringController;
	public/*(IK)*/ /*editinline */SkelControlSingleBone RightForeArmRollRotationController;
	public/*(IK)*/ /*editinline */SkelControlSingleBone LeftForeArmRollRotationController;
	public /*const */bool bDisableSkelControlSpring;
	public bool bCanUnCrouch;
	public bool bConstrainLook;
	public bool bGoingForward;
	public bool bClimbLeftHand;
	public bool bClimbDownFast;
	public bool bEnableFootPlacement;
	public bool bMoveActionMax;
	public /*transient */bool bFoundLedgeExcludesHandMoves;
	public /*transient */bool bFoundLedgeExcludesFootMoves;
	public /*private const */bool bIsWallWalking;
	public bool bFoundLedge;
	public bool bAllowMoveChange;
	public bool bSRPauseTimer;
	public bool bForceMaxAccelOneFrame;
	public bool RollTriggerPressed;
	public bool bUncontrolledSlide;
	public bool bIsPlayingSlideEffect;
	public /*transient */bool bAlternateSound;
	public bool bCharacterInhaling;
	public bool bDisableCharacterSounds;
	public/*(Health)*/ /*config */bool bTakeFallDamage;
	public bool bIsUsingRootMotion;
	public bool bIsUsingRootRotation;
	public bool bDebugDamage;
	public bool bDebugNetAnim;
	public bool bNoMoveAnims;
	public/*(Speed)*/ bool bDebugAcceleration;
	public/*(Movement)*/ bool bDebugJumping;
	public/*(Movement)*/ bool bDebugMovement;
	public bool bDebugPlotPath;
	public/*(Footsteps)*/ /*config */bool bDebugFootsteps;
	public/*(Sounds)*/ /*config */bool bDebugSlapBack;
	public/*(Sounds)*/ /*config */bool bDebugCharacterSounds;
	public/*(Sounds)*/ /*config */bool bDebugBreathingSounds;
	public/*()*/ /*config */bool bDebugWeapons;
	public/*()*/ /*config */bool bDebugMaterials;
	public TdAnimNodeSlot CustomCannedNode1p;
	public TdAnimNodeSlot CustomCannedNode3p;
	public TdAnimNodeSlot CustomCannedUpperBodyNode1p;
	public TdAnimNodeSlot CustomCannedUpperBodyNode3p;
	public TdAnimNodeSlot CustomFullBodyNode1p;
	public TdAnimNodeSlot CustomFullBodyNode3p;
	public TdAnimNodeSlot CustomFullBodyDirNode1p;
	public TdAnimNodeSlot CustomFullBodyDirNode3p;
	public TdAnimNodeSlot CustomUpperBodyNode1p;
	public TdAnimNodeSlot CustomUpperBodyNode3p;
	public TdAnimNodeSlot CustomLowerBodyNode1p;
	public TdAnimNodeSlot CustomLowerBodyNode3p;
	public TdAnimNodeSlot CustomCameraNode;
	public TdAnimNodeSlot CustomWeaponNode1p;
	public TdAnimNodeSlot CustomWeaponNode3p;
	public TdAnimNodeSlot CustomFaceNode;
	public TdAnimNodePoseOffset WeaponPoseOffset1p;
	public TdAnimNodePoseOffset WeaponPoseOffset3p;
	public TdAnimNodeLandOffset LandNode1p;
	public TdAnimNodeLandOffset LandNode3p;
	public TdAnimNodeGrabbing GrabAnimNode1p;
	public TdAnimNodeGrabbing GrabAnimNode3p;
	public AnimNodeSynch MasterSync1p;
	public AnimNodeSynch MasterSync3p;
	public /*transient */array<AnimNodeAimOffset> AimOffsetNodes;
	public /*transient */array<TdAnimNodePoseOffset> PoseOffsetNodes;
	public /*transient */array<AnimNodeSlot> SlotNodes;
	public AnimSet CommonArmedLight1p;
	public AnimSet CommonArmedHeavy1p;
	public AnimSet CommonArmedLight3p;
	public AnimSet CommonArmedHeavy3p;
	public float VelocityMagnitude2D;
	public float VelocityMagnitude;
	public Object.Vector VelocityDir2D;
	public Object.Vector VelocityDir;
	public float FaceRotationTimeLeft;
	public float BecameReadyTime;
	public float AmountTilUnarmed;
	public /*export editinline */CylinderComponent ActorCylinderComponent;
	public float GravityModifier;
	public float GravityModifierTimer;
	public/*(Animation)*/ /*editinline */TdSwanNeck SwanNeck1p;
	public TdPawn.EAgainstWallState AgainstWallState;
	public/*(Animation)*/ TdPawn.EWeaponAnimState WeaponAnimState;
	public byte AnimLockRefCount;
	public byte RootMotionRefCount;
	public TdPawn.EGrabTurnType CurrentGrabTurnType;
	public byte LadderType;
	public /*repnotify */TdPawn.EMovement AnimationMovementState;
	public TdPawn.EMovement PendingAnimationMovementState;
	public TdPawn.EMovement OldMovementState;
	public TdPawn.EMovement PendingMovementState;
	public TdPawn.EMovement MovementState;
	public /*repnotify */TdPawn.EMovement ReplicatedMovementState;
	public TdPawn.EMovement AIAimOldMovementState;
	public TdPawn.WalkingState OverrideWalkingState;
	public TdPawn.WalkingState PendingOverrideWalkingState;
	public TdPawn.WalkingState CurrentWalkingState;
	public /*transient */byte ReplicateCustomAnimCount;
	public TdPawn.EMoveActionHint MoveActionHint;
	public /*repnotify */byte ReloadCount;
	public byte NoOfBreathingSounds;
	public Object.Vector AgainstWallLeftHand;
	public Object.Vector AgainstWallRightHand;
	public Object.Vector AgainstWallNormal;
	public Object.Rotator MinLookConstraint;
	public Object.Rotator MaxLookConstraint;
	public float LegRotationSlowTimer;
	public int LegRotation;
	public/*(Animation)*/ /*config */float LegRotationSpeed;
	public /*config */int GoBackLegAngleLimitMin;
	public /*config */int GoBackLegAngleLimitMax;
	public /*config */int LegAngleLimitFudge;
	public/*(Animation)*/ /*config */float SneakVelocity;
	public/*(Animation)*/ /*config */float WalkVelocity;
	public/*(Animation)*/ /*config */float JogVelocity;
	public/*(Animation)*/ /*config */float RunVelocity;
	public/*(Animation)*/ /*config */float SprintVelocity;
	public /*transient */float AverageSpeed;
	public/*(Animation)*/ /*config */float ASFilterTime;
	public /*private transient */float ASPollInterval;
	public /*private transient */float ASPollTimer;
	public /*private transient */int ASPollSlots;
	public /*private transient */int ASSlotPointer;
	public /*private transient */float ASDistanceAccum;
	public /*private transient */array<float> ASTimeData;
	public /*private transient */array<float> ASDistanceData;
	public float NewFloorSmooth;
	public /*transient */float SmoothOffset;
	public /*transient */Object.Rotator FootPlacementStoredRotation;
	public /*transient */TdPawn.PawnFootPlacementTrace FootPlacementTrace;
	public float TargetMeshTranslationZ;
	public /*export editinline */TdSkeletalMeshComponent Mesh1p;
	public /*export editinline */TdSkeletalMeshComponent Mesh3p;
	public /*export editinline */TdSkeletalMeshComponent Mesh1pLowerBody;
	public TdMovementVolume ActiveMovementVolume;
	public Core.ClassT<TdMoveManager> MoveManagerClass;
	public TdMoveManager MoveManager;
	public/*(Movement)*/ array< Core.ClassT<TdMove> > MoveClasses;
	public/*(Movement)*/ /*editinline transient */array</*editinline */TdMove> Moves;
	public float SlideStoppedTimeStamp;
	public /*repnotify */TdPawn.ReplicatedCustomAnimation ReplicatedCustomAnim;
	public Object.Vector MoveLocation;
	public Object.Vector MoveNormal;
	public Actor MovementActor;
	public TdMovementExclusionVolume MovementExclusionVolume;
	public float MaxWallStepHeight;
	public Object.Vector MoveLedgeLocation;
	public Object.Vector MoveLedgeNormal;
	public int MoveLedgeResult;
	public Object.Vector LedgeFindExtent;
	public float LedgeFindDistance;
	public float LedgeFindDepth;
	public Object.Vector IllegalLedgeNormal;
	public float bIllegalLedgeTimer;
	public int ActiveMoveTimer;
	public int RemoteViewYaw;
	public float EvadeTimer;
	public/*(Speed)*/ Object.InterpCurveFloat SpeedCurve_LightWeapon;
	public/*(Speed)*/ Object.InterpCurveFloat SpeedCurve_HeavyWeapon;
	public/*(Speed)*/ /*config */float SpeedMaxBaseVelocity;
	public/*(Speed)*/ /*config */float SpeedMinBaseVelocity;
	public/*(Speed)*/ /*config */float SpeedStrafeVelocityAccelerationFactor;
	public/*(Speed)*/ /*config */float SpeedWalkVelocityAccelerationFactor;
	public/*(Speed)*/ /*config */float SpeedSprintVelocityAccelerationFactor;
	public/*(Speed)*/ /*config */float SpeedEnergyDecelerationTime;
	public/*(Speed)*/ /*config */float SpeedEnergyDecelerationExponent;
	public/*(Speed)*/ /*config */float SpeedTurnDecelerationFactor;
	public /*transient */Object.InterpCurveFloat AccelCurve_LightWeapon;
	public /*transient */Object.InterpCurveFloat AccelCurve_HeavyWeapon;
	public float SpeedSprintEnergy;
	public/*(Speed)*/ /*config */float UpwardWalkFrictionScale;
	public/*(Speed)*/ /*config */float DownwardWalkFrictionScale;
	public/*(Speed)*/ /*config */float MinWalkFrictionModify;
	public/*(Speed)*/ /*config */float MaxWalkFrictionModify;
	public/*(Speed)*/ /*config */float UpwardSlideFrictionScale;
	public/*(Speed)*/ /*config */float DownwardSlideFrictionScale;
	public/*(Speed)*/ /*config */float BrakingFrictionStrength;
	public float SoftLockStrength;
	public float RollTriggerTime;
	public Object.Vector UncontrolledSlideNormal;
	public/*(Movement)*/ /*config */float FallingUncontrolledHeight;
	public /*transient */float EnterFallingHeight;
	public float SlideEffectUpdateTimer;
	public /*transient */TdEmitter SlideEffectEmitter;
	public /*export editinline transient */AudioComponent SlidingSoundComponent0;
	public /*export editinline transient */AudioComponent SlidingSoundComponent1;
	public SoundCue DefaultSlidingSound;
	public float CustomSoundInput;
	public float OverrideSynchPosOffset;
	public float StreakEffectOverride;
	public float StreakEffectDirection;
	public int PatchOne;
	public int PatchTwo;
	public /*repnotify */int PatchThree;
	public /*repnotify */Core.ClassT<TdWeapon> ReplicatedWeaponClass;
	public /*repnotify transient */TdPawn.PhysicalHitInfo LastPhysHitInfo;
	public /*transient */float PhysicsHitReactionBlendTimer;
	public /*transient */float PhysicsHitReactionBlendOut;
	public /*config */float PhysicsHitReactionBlendInTime;
	public /*config */float PhysicsHitReactionBlendOutTime;
	public float PhysicsHitReactionScale;
	public /*transient */int LastDamageTaken;
	public /*transient */float ArmorBulletsHead;
	public /*transient */float ArmorBulletsBody;
	public /*transient */float ArmorBulletsLegs;
	public /*transient */float ArmorMeleeHead;
	public /*transient */float ArmorMeleeBody;
	public /*transient */float ArmorMeleeLegs;
	public /*private const config */TdPawn.ArmorSettings ArmorBulletsHeadSettings;
	public /*private const config */TdPawn.ArmorSettings ArmorBulletsBodySettings;
	public /*private const config */TdPawn.ArmorSettings ArmorBulletsLegsSettings;
	public /*private const config */TdPawn.ArmorSettings ArmorMeleeHeadSettings;
	public /*private const config */TdPawn.ArmorSettings ArmorMeleeBodySettings;
	public /*private const config */TdPawn.ArmorSettings ArmorMeleeLegsSettings;
	public /*private const config */TdPawn.ArmorSettings ArmorBulletsHeadSettings_CHASE;
	public /*private const config */TdPawn.ArmorSettings ArmorBulletsBodySettings_CHASE;
	public /*private const config */TdPawn.ArmorSettings ArmorBulletsLegsSettings_CHASE;
	public /*private const config */TdPawn.ArmorSettings ArmorMeleeHeadSettings_CHASE;
	public /*private const config */TdPawn.ArmorSettings ArmorMeleeBodySettings_CHASE;
	public /*private const config */TdPawn.ArmorSettings ArmorMeleeLegsSettings_CHASE;
	public/*(Footsteps)*/ /*config */float FootstepTraceLength;
	public/*(Footsteps)*/ /*config */float FootstepTraceWidth;
	public PhysicalMaterial DefaultFootstepMaterial;
	public /*transient */PhysicalMaterial LastFootstepMaterial;
	public/*(Sounds)*/ array<SoundCue> CharacterSoundCues;
	public float LastFlybyStamp;
	public/*(Health)*/ int MaxHealth;
	public/*(Health)*/ /*config */float RegenerateDelay;
	public/*(Health)*/ /*config */float RegenerateHealthPerSecond;
	public/*(Health)*/ /*config */float UnrealEngineFallDamageScale;
	public float TimeSinceLastDamage;
	public float HealthFrac;
	public /*transient */float TaserDamageLevel;
	public/*(Health)*/ /*config */float RegenerateFromTaserPerSecond;
	public/*(Health)*/ /*config */float TaserRegenerateDelay;
	public /*transient */float TimeSinceLastTaserDamage;
	public /*transient */float StunDamageLevel;
	public/*(Health)*/ /*config */float RegenerateFromStunPerSecond;
	public float MinTimeBeforeRemovingDeadBody;
	public float MaxTimeBeforeRemovingDeadBody;
	public Vehicle PassengerDrivenVehicle;
	public int MyPassengerSeatIndex;
	public float SlideFactor;
	public TdGhostManager DebugGhostManager;
	public float LastDamage;
	public float LastDamageTime;
	public float NextDebugPlotTime;
	public Object.Vector LastPlotLocation;
	public array<TdPawn.FootstepLogInfo> FootstepLog;
	public array<TdPawn.FootstepLogInfo> BreathingLog;
	public Object.Vector LastJumpLocation;
	public TdWeapon MyWeapon;
	
	//replication
	//{
	//	 if(bDemoRecording || (bNetDirty && bNetOwner) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		TaserDamageLevel;
	//
	//	 if(bDemoRecording || (!bNetOwner && bNetDirty) && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		AnimationMovementState, CurrentGrabTurnType, 
	//		LadderType, ReloadCount, 
	//		ReplicatedCustomAnim, ReplicatedMovementState, 
	//		ReplicatedWeaponClass, bClimbDownFast, 
	//		bClimbLeftHand;
	//
	//	 if(bDemoRecording || !bNetOwner && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		LastPhysHitInfo, RemoteViewYaw;
	//
	//	 if(bDemoRecording || !bNetOwner && ((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
	//		PatchOne, PatchThree, 
	//		PatchTwo;
	//}
	
	// Export UTdPawn::execGetWalkAcceleration(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetWalkAcceleration(float aForward, float aStrafe, int DeltaRotation, float DeltaTime)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execGetSprintAcceleration(FFrame&, void* const)
	public virtual /*native function */Object.Vector GetSprintAcceleration(float aForward, float aStrafe, int DeltaRotation, float DeltaTime)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execSyncLegMovement(FFrame&, void* const)
	public virtual /*native function */void SyncLegMovement()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execGetMobilityMultiplier(FFrame&, void* const)
	public virtual /*native function */float GetMobilityMultiplier()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execOffsetMeshXY(FFrame&, void* const)
	public virtual /*native function */void OffsetMeshXY(Object.Vector Offset, /*optional */bool? _bWorldSpace = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execOffsetMeshZ(FFrame&, void* const)
	public virtual /*native function */void OffsetMeshZ(float OffsetZ)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execSetTargetMeshZ(FFrame&, void* const)
	public virtual /*native function */void SetTargetMeshZ(float OffsetZ, bool bForceSet)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execUpdateLegToWorldMatrix(FFrame&, void* const)
	public virtual /*native function */void UpdateLegToWorldMatrix(int Yaw)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void SetDifficultyLevel(int Difficulty)
	{
		SetArmorDifficultyLevel(Difficulty);
	}
	
	// Export UTdPawn::execSetArmorDifficultyLevel(FFrame&, void* const)
	public virtual /*protected native function */void SetArmorDifficultyLevel(int Difficulty)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*simulated event */void PreBeginPlay()
	{
		base.PreBeginPlay();
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
		base.PostBeginPlay();
		InitMoves();
		CacheAnimNodes();
		SlideEffectEmitter = Spawn(ClassT<TdEmitter>(), this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
		SlideEffectEmitter.bDestroyOnSystemFinish = false;
		SlideEffectEmitter.LifeSpan = 0.0f;
		SlideEffectEmitter.KillProjectile();
		MaxHealth = DefaultAs<Pawn>().Health;
	}
	
	public virtual /*simulated function */void CacheAnimNodes()
	{
		/*local */AnimNode Node = default;
		/*local */AnimNodeAimOffset AimNode = default;
		/*local */TdAnimNodePoseOffset PoseOffsetNode = default;
	
		if(Mesh3p != default)
		{
			RootControl3p = ((Mesh3p.FindSkelControl("RootControl")) as SkelControlSingleBone);
			SwingControl3p = ((Mesh3p.FindSkelControl("SwingControl")) as SkelControlSingleBone);
			LeftLegControl3p = ((Mesh3p.FindSkelControl("LeftFootPlacementControl")) as TdSkelControlFootPlacement);
			RightLegControl3p = ((Mesh3p.FindSkelControl("RightFootPlacementControl")) as TdSkelControlFootPlacement);
			LeftLegControl3p.SetSkelControlStrength(0.0f, 0.0f);
			RightLegControl3p.SetSkelControlStrength(0.0f, 0.0f);
		}
		if(Mesh3p.Animations == default)
		{
			return;
		}
		
		// foreach Mesh3p.AllAnimNodes(ClassT<AnimNode>(), ref/*probably?*/ Node)
		using var e230 = Mesh3p.AllAnimNodes(ClassT<AnimNode>()).GetEnumerator();
		while(e230.MoveNext() && (Node = (AnimNode)e230.Current) == Node)
		{
			AimNode = ((Node) as AnimNodeAimOffset);
			PoseOffsetNode = ((Node) as TdAnimNodePoseOffset);
			if(AimNode != default)
			{
				AimOffsetNodes[AimOffsetNodes.Length] = AimNode;
			}
			if(PoseOffsetNode != default)
			{
				PoseOffsetNodes.AddItem(PoseOffsetNode);
			}
			if(Node.NodeName == "None")
			{
				continue;			
				continue;
			}
			if(Node.NodeName == "Custom_Canned")
			{
				CustomCannedNode3p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_CannedUpperBody")
			{
				CustomCannedUpperBodyNode3p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_FullBody")
			{
				CustomFullBodyNode3p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_FullBody_Dir")
			{
				CustomFullBodyDirNode3p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_UpperBody")
			{
				CustomUpperBodyNode3p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_LowerBody")
			{
				CustomLowerBodyNode3p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_Weapon")
			{
				CustomWeaponNode3p = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "Custom_Face")
			{
				CustomFaceNode = ((Node) as TdAnimNodeSlot);
				continue;
			}
			if(Node.NodeName == "MasterSync")
			{
				MasterSync3p = ((Node) as AnimNodeSynch);
				continue;
			}
			if(Node.NodeName == "LandNode")
			{
				LandNode3p = ((Node) as TdAnimNodeLandOffset);
				continue;
			}
			if(Node.NodeName == "GrabNode")
			{
				GrabAnimNode3p = ((Node) as TdAnimNodeGrabbing);
				continue;
			}
			if(Node.NodeName == "WeaponPoseOffset")
			{
				WeaponPoseOffset3p = ((Node) as TdAnimNodePoseOffset);
				continue;
			}
			if(Node.NodeName == "ZipLine")
			{
				((Moves[27]) as TdMove_IntoZipLine).SetIdleAnimationReference3p(((Node) as TdAnimNodeSequence));
			}		
		}	
	}
	
	public virtual /*simulated function */void InitSwanNeck()
	{
		SwanNeck1p =  ClassT<TdSwanNeck>().New(this);
	}
	
	public override SetInitialState_del SetInitialState { get => bfield_SetInitialState ?? TdPawn_SetInitialState; set => bfield_SetInitialState = value; } SetInitialState_del bfield_SetInitialState;
	public override SetInitialState_del global_SetInitialState => TdPawn_SetInitialState;
	public /*simulated event */void TdPawn_SetInitialState()
	{
		bScriptInitialized = true;
		if(InitialState != "None")
		{
			GotoState(InitialState, default(name?), default(bool?), default(bool?));		
		}
		else
		{
			GotoState("Auto", default(name?), default(bool?), default(bool?));
		}
	}
	
	public virtual /*simulated function */void InitMoves()
	{
		InitMoveObjects();
		if(MoveManagerClass != default)
		{
			MoveManager =  MoveManagerClass.New(this);
		}
	}
	
	// Export UTdPawn::execInitMoveObjects(FFrame&, void* const)
	public virtual /*native function */void InitMoveObjects()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void OnTutorialEvent(int TutorialEvent)
	{
	
	}
	
	public virtual /*simulated function */void SetShowGhost(bool bShow)
	{
	
	}
	
	public virtual /*simulated event */bool CanDoMove(TdPawn.EMovement NewMove)
	{
		if(!bAllowMoveChange)
		{
			return false;
		}
		if(((int)PendingMovementState) != ((int)MovementState))
		{
			return false;
		}
		return Moves[((int)NewMove)].CanDoMove();
	}
	
	public delegate bool SetMove_del(TdPawn.EMovement NewMove, /*optional */bool? _bViaReplication = default, /*optional */bool? _bCheckCanDo = default);
	public virtual SetMove_del SetMove { get => bfield_SetMove ?? TdPawn_SetMove; set => bfield_SetMove = value; } SetMove_del bfield_SetMove;
	public virtual SetMove_del global_SetMove => TdPawn_SetMove;
	public /*simulated event */bool TdPawn_SetMove(TdPawn.EMovement NewMove, /*optional */bool? _bViaReplication = default, /*optional */bool? _bCheckCanDo = default)
	{
		var bViaReplication = _bViaReplication ?? false;
		var bCheckCanDo = _bCheckCanDo ?? false;
		if(((int)NewMove) == ((int)MovementState))
		{
			return false;
		}
		if(!bAllowMoveChange)
		{
			return false;
		}
		if(((((Controller) as TdPlayerController) != default) && ((Controller) as TdPlayerController).bCinematicMode) && ((int)NewMove) != ((int)TdPawn.EMovement.MOVE_Walking/*1*/))
		{
			return false;
		}
		PendingMovementState = ((TdPawn.EMovement)NewMove);
		if(bCheckCanDo && !Moves[((int)NewMove)].CanDoMove())
		{
			return false;
		}
		if(bViaReplication)
		{
			if(((int)MovementState) != ((int)TdPawn.EMovement.MOVE_None/*0*/))
			{
				Moves[((int)MovementState)].StopReplicatedMove();
			}
			OldMovementState = ((TdPawn.EMovement)MovementState);
			MovementState = ((TdPawn.EMovement)NewMove);
			if(((int)OldMovementState) != ((int)TdPawn.EMovement.MOVE_None/*0*/))
			{
				Moves[((int)OldMovementState)].PostStopMove();
			}
			Moves[((int)MovementState)].StartReplicatedMove();		
		}
		else
		{
			if(((int)MovementState) != ((int)TdPawn.EMovement.MOVE_None/*0*/))
			{
				Moves[((int)MovementState)].StopMove();
			}
			OldMovementState = ((TdPawn.EMovement)MovementState);
			MovementState = ((TdPawn.EMovement)NewMove);
			if(((int)OldMovementState) != ((int)TdPawn.EMovement.MOVE_None/*0*/))
			{
				Moves[((int)OldMovementState)].PostStopMove();
			}
			ReplicatedMovementState = ((TdPawn.EMovement)NewMove);
			SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
			Moves[((int)MovementState)].StartMove();
			NotifyNewMove();
		}
		return true;
	}
	
	public virtual /*function */void NotifyNewMove()
	{
		if((((int)OldMovementState) == ((int)TdPawn.EMovement.MOVE_Slide/*16*/)) || ((int)OldMovementState) == ((int)TdPawn.EMovement.MOVE_MeleeSlide/*48*/))
		{
			SlideStoppedTimeStamp = WorldInfo.TimeSeconds;
		}
	}
	
	// Export UTdPawn::execIsInMove(FFrame&, void* const)
	public virtual /*native function */bool IsInMove(TdPawn.EMovement Move)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execGetMove(FFrame&, void* const)
	public virtual /*native function */TdPawn.EMovement GetMove()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*unreliable client simulated function */void ClientAdjustPreciseLocation(Object.Vector PreciceLocation, TdPawn.EMovement ServerMovementState)
	{
		if(((int)MovementState) == ((int)ServerMovementState))
		{
			Moves[((int)MovementState)].PreciseLocation = PreciceLocation;
		}
	}
	
	public virtual /*simulated function */void SetAnimationMovementState(TdPawn.EMovement NewForcedGenericState, /*optional */float? _delay = default)
	{
		var delay = _delay ?? -1.0f;
		PendingAnimationMovementState = ((TdPawn.EMovement)NewForcedGenericState);
		if(delay > 0.0f)
		{
			SetTimer(delay, false, "SetAnimationMovementStateInternal", default(Object?));		
		}
		else
		{
			SetAnimationMovementStateInternal();
		}
	}
	
	public virtual /*simulated function */void ClearAnimationMovementState(/*optional */float? _delay = default)
	{
		var delay = _delay ?? -1.0f;
		if(delay > 0.0f)
		{
			SetTimer(delay, false, "ClearAnimationMovementStateInternal", default(Object?));		
		}
		else
		{
			ClearAnimationMovementStateInternal();
		}
	}
	
	public virtual /*simulated function */void SetAnimationMovementStateInternal()
	{
		AnimationMovementState = ((TdPawn.EMovement)PendingAnimationMovementState);
	}
	
	public virtual /*simulated function */void ClearAnimationMovementStateInternal()
	{
		AnimationMovementState = TdPawn.EMovement.MOVE_None/*0*/;
		PendingAnimationMovementState = TdPawn.EMovement.MOVE_None/*0*/;
	}
	
	// Export UTdPawn::execUpdateWalkingState(FFrame&, void* const)
	public virtual /*native simulated function */void UpdateWalkingState()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated function */void SetOverrideWalkingState(TdPawn.WalkingState NewState, /*optional */float? _delay = default)
	{
		var delay = _delay ?? -1.0f;
		ClearTimer("OverrideWalkingStateInternal", default(Object?));
		ClearTimer("ClearOverrideWalkingStateInternal", default(Object?));
		PendingOverrideWalkingState = ((TdPawn.WalkingState)NewState);
		if(delay > 0.0f)
		{
			SetTimer(delay, false, "OverrideWalkingStateInternal", default(Object?));		
		}
		else
		{
			OverrideWalkingStateInternal();
		}
	}
	
	public virtual /*simulated function */void ClearOverrideWalkingState(/*optional */float? _delay = default)
	{
		var delay = _delay ?? -1.0f;
		ClearTimer("OverrideWalkingStateInternal", default(Object?));
		ClearTimer("ClearOverrideWalkingStateInternal", default(Object?));
		if(delay > 0.0f)
		{
			SetTimer(delay, false, "ClearOverrideWalkingStateInternal", default(Object?));		
		}
		else
		{
			ClearOverrideWalkingStateInternal();
		}
	}
	
	public virtual /*simulated function */void OverrideWalkingStateInternal()
	{
		OverrideWalkingState = ((TdPawn.WalkingState)PendingOverrideWalkingState);
	}
	
	public virtual /*simulated function */void ClearOverrideWalkingStateInternal()
	{
		OverrideWalkingState = TdPawn.WalkingState.WAS_None/*6*/;
		PendingOverrideWalkingState = TdPawn.WalkingState.WAS_None/*6*/;
	}
	
	public delegate void HandleMoveAction_del(TdPawn.EMovementAction Action);
	public virtual HandleMoveAction_del HandleMoveAction { get => bfield_HandleMoveAction ?? TdPawn_HandleMoveAction; set => bfield_HandleMoveAction = value; } HandleMoveAction_del bfield_HandleMoveAction;
	public virtual HandleMoveAction_del global_HandleMoveAction => TdPawn_HandleMoveAction;
	public /*function */void TdPawn_HandleMoveAction(TdPawn.EMovementAction Action)
	{
		if(MoveManager != default)
		{
			MoveManager.HandleMoveAction(((TdPawn.EMovementAction)Action));		
		}
	}
	
	public virtual /*function */void SetMoveActionHint(TdPawn.EMoveActionHint Hint, /*optional */bool? _bMax = default)
	{
		var bMax = _bMax ?? false;
		MoveActionHint = ((TdPawn.EMoveActionHint)Hint);
		bMoveActionMax = bMax;
	}
	
	public override /*simulated event */void ReplicatedEvent(name VarName)
	{
		if(VarName == "ReplicatedWeaponClass")
		{
			UpdateRemoteWeapon();		
		}
		else
		{
			if(VarName == "ReloadCount")
			{
				ReloadCountUpdated(true);			
			}
			else
			{
				if(VarName == "ReplicatedMovementState")
				{
					if(((int)ReplicatedMovementState) != ((int)MovementState))
					{
						SetMove(((TdPawn.EMovement)ReplicatedMovementState), true, default(bool?));
					}				
				}
				else
				{
					if(VarName == "ReplicatedCustomAnim")
					{
						PlayReplicatedCustomAnim();					
					}
					else
					{
						if(VarName == "AnimationMovementState")
						{
							SetAnimationMovementState(((TdPawn.EMovement)AnimationMovementState), default(float?));						
						}
						else
						{
							if(VarName == "LastPhysHitInfo")
							{							
							}
							else
							{
								base.ReplicatedEvent(VarName);
							}
						}
					}
				}
			}
		}
	}
	
	public virtual /*final function */bool HasWeapon()
	{
		return Weapon != default;
	}
	
	public override /*function */bool IsFiring()
	{
		return (MyWeapon != default) && MyWeapon.IsFiring();
	}
	
	public virtual /*function */bool IsReloading()
	{
		return (MyWeapon != default) && MyWeapon.IsReloading();
	}
	
	public virtual /*function */bool IsInStateReloading()
	{
		return (MyWeapon != default) && MyWeapon.IsInStateReloading();
	}
	
	public virtual /*final simulated event */bool IsReloadingAndIsInStateReloading()
	{
		return ((MyWeapon != default) && MyWeapon.IsInStateReloading()) && MyWeapon.IsReloading();
	}
	
	public virtual /*simulated function */void IncrementReloadCount(Weapon Who)
	{
		SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
		ReloadCount = (byte)1;
		ReloadCountUpdated(false);
	}
	
	public virtual /*simulated function */void ClearReloadCount(Weapon Who)
	{
		if(((int)ReloadCount) != ((int)0))
		{
			SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
			ReloadCount = (byte)0;
			ReloadCountUpdated(false);
		}
	}
	
	public virtual /*simulated function */void ReloadCountUpdated(bool bViaReplication)
	{
		if(((int)ReloadCount) == ((int)1))
		{
			MyWeapon.WeaponStartReloading(default(float?));
		}
		if(bViaReplication && ((int)ReloadCount) < ((int)1))
		{
			MyWeapon.WeaponStoppedReloading();
		}
	}
	
	public virtual /*simulated function */void WeaponStartReloading(bool bViaReplication)
	{
	
	}
	
	public virtual /*simulated function */void WeaponStoppedReloading(bool bViaReplication)
	{
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Ready/*2*/);
	}
	
	public virtual /*event */void SwitchHeavyLightWeapon()
	{
		/*local */TdInventoryManager Manager = default;
	
		Manager = ((InvManager) as TdInventoryManager);
		if(Manager != default)
		{
			Manager.SwitchGun();
		}
	}
	
	public virtual /*final simulated function */void RemoteClientSetupInvManager()
	{
		if(InvManager == default)
		{
			InvManager = Spawn(InventoryManagerClass, this, default(name?), default(Object.Vector?), default(Object.Rotator?), default(Actor?), default(bool?));
			if(InvManager == default)
			{			
			}
			else
			{
				InvManager.RemoteRole = Actor.ENetRole.ROLE_None/*0*/;
				InvManager.SetupFor(this);
			}
		}
	}
	
	public virtual /*simulated function */void UpdateRemoteWeapon()
	{
		/*local */TdWeapon Weap = default;
	
		if(InvManager == default)
		{
			RemoteClientSetupInvManager();
		}
		if((ReplicatedWeaponClass == default) && Weapon != default)
		{
			DetachWeaponFromHand(Weapon);
			return;
		}
		Weap = ((InvManager.FindInventoryType(ReplicatedWeaponClass, default(bool?))) as TdWeapon);
		if(Weap == default)
		{
			Weap = ((InvManager.CreateInventory(ReplicatedWeaponClass, true)) as TdWeapon);
			if(Weap != default)
			{
				Weap.bRemoteWeapon = true;
				Weap.RemoteRole = Actor.ENetRole.ROLE_None/*0*/;			
			}
		}
		if(Weap != default)
		{
			InvManager.SetCurrentWeapon(Weap);		
		}
	}
	
	public virtual /*simulated function */void DetachWeaponFromHand(Weapon WeaponToDetach)
	{
		if(WeaponToDetach != default)
		{
			WeaponToDetach.DetachWeapon();
		}
	}
	
	public virtual /*simulated function */void AttachWeaponToHand(Weapon WeaponToAttach)
	{
		if(WeaponToAttach != default)
		{
			if(IsLocallyControlled() && (IsFirstPerson()) || Mesh == Mesh1p)
			{
				((WeaponToAttach) as TdWeapon).AttachWeaponComponentsToPlayer(true);			
			}
			else
			{
				((WeaponToAttach) as TdWeapon).AttachWeaponComponentsToPlayer(false);
			}
		}
	}
	
	public override PlayWeaponSwitch_del PlayWeaponSwitch { get => bfield_PlayWeaponSwitch ?? TdPawn_PlayWeaponSwitch; set => bfield_PlayWeaponSwitch = value; } PlayWeaponSwitch_del bfield_PlayWeaponSwitch;
	public override PlayWeaponSwitch_del global_PlayWeaponSwitch => TdPawn_PlayWeaponSwitch;
	public /*simulated function */void TdPawn_PlayWeaponSwitch(Weapon OldWeapon, Weapon NewWeapon)
	{
		DetachWeaponFromHand(OldWeapon);
		AttachWeaponToHand(NewWeapon);
		UpdateAnimSets(((NewWeapon) as TdWeapon));
		UpdateRightShoulderOffset();
		UpdateWeaponSkelControls();
		PlayWeaponDeploy();
	}
	
	public virtual /*event */float GetWeaponRecoil()
	{
		return MyWeapon.MovementRecoilWhenFire;
	}
	
	public override /*simulated function */void WeaponFired(bool bViaReplication, /*optional */Object.Vector? _HitLocation = default)
	{
		var HitLocation = _HitLocation ?? default;
		++ ShotCount;
	}
	
	public override /*simulated function */void WeaponStoppedFiring(bool bViaReplication)
	{
		ShotCount = 0;
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Ready/*2*/);
	}
	
	public override /*simulated function */void FlashCountUpdated(bool bViaReplication)
	{
		/*local */TdWeapon TdWeap = default;
	
		TdWeap = MyWeapon;
		if(TdWeap != default)
		{
			TdWeap.FlashCountUpdated((byte)FlashCount, (byte)FiringMode, bViaReplication);
		}
	}
	
	public override /*simulated function */void FlashLocationUpdated(bool bViaReplication)
	{
		/*local */TdWeapon TdWeap = default;
	
		TdWeap = MyWeapon;
		if(TdWeap != default)
		{
			TdWeap.FlashLocationUpdated((byte)FiringMode, FlashLocation, bViaReplication);
		}
	}
	
	public virtual /*simulated function */void PlayWeaponDeploy()
	{
		if((((int)MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) && ((Moves[1]) as TdMove_Walking).IsPlayingIdleAnim())
		{
			((Moves[1]) as TdMove_Walking).StopIdle(0.10f);
		}
		PlayCustomAnim(TdPawn.CustomNodeType.CNT_CannedUpperBody/*1*/, "unholster", 1.0f, 0.0f, 0.20f, false, true, false, false);
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Ready/*2*/);
	}
	
	public virtual /*simulated function */void PlayZoomInAnimation()
	{
		PlayCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, "ZoomIn", 1.0f, 0.10f, 0.0f, false, true, false, false);
	}
	
	public virtual /*simulated function */void PlayZoomOutAnimation()
	{
		PlayCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, "ZoomOut", 1.0f, 0.0f, 0.10f, false, true, false, false);
	}
	
	public virtual /*function */float GetReloadPlaybackRate()
	{
		return 1.0f;
	}
	
	public virtual /*simulated function */name PlayReloadAnimation(name WeaponAnimSeqName, /*optional */bool? _bPlayWeaponAnimSeq = default)
	{
		/*local */TdAnimNodeSequence AnimSeq1p = default, AnimSeq3p = default;
		/*local */name ReloadAnimSeqName = default;
	
		var bPlayWeaponAnimSeq = _bPlayWeaponAnimSeq ?? false;
		if(bPlayWeaponAnimSeq)
		{
			ReloadAnimSeqName = WeaponAnimSeqName;
			PlayCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, ReloadAnimSeqName, 1.0f, 0.20f, 0.20f, false, true, false, false);		
		}
		else
		{
			ReloadAnimSeqName = Moves[((int)MovementState)].PlayReloadAnimation();
		}
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Reload/*3*/);
		if(CustomWeaponNode1p != default)
		{
			AnimSeq1p = ((CustomWeaponNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
			AnimSeq1p.AnimationType = TdAnimNodeSequence.EAnimType.EA_Reload/*2*/;
		}
		if(CustomWeaponNode3p != default)
		{
			AnimSeq3p = ((CustomWeaponNode3p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
			AnimSeq3p.AnimationType = TdAnimNodeSequence.EAnimType.EA_Reload/*2*/;
		}
		return ReloadAnimSeqName;
	}
	
	public virtual /*simulated event */void CeaseFire()
	{
	
	}
	
	public virtual /*simulated function */void StopFireAnimation()
	{
		if(!IsFiring())
		{
			return;
		}
		CeaseFire();
		StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.10f);
		MyWeapon.StopFiring(default(float?));
	}
	
	public virtual /*simulated function */void StopReloadAnimation()
	{
		if(!IsReloading())
		{
			return;
		}
		MyWeapon.StopReloading(default(float?), default(bool?));
		StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.10f);
	}
	
	public virtual /*simulated function */name PlayFireAnimation(name WeaponAnimSeqName, /*optional */bool? _bPlayWeaponAnimSeq = default)
	{
		/*local */TdAnimNodeSequence AnimSeq1p = default, AnimSeq3p = default;
		/*local */name FireAnimSeqName = default;
	
		var bPlayWeaponAnimSeq = _bPlayWeaponAnimSeq ?? false;
		if(bPlayWeaponAnimSeq)
		{
			FireAnimSeqName = WeaponAnimSeqName;
			StopCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, 0.0f);
			PlayCustomAnim(TdPawn.CustomNodeType.CNT_Weapon/*7*/, FireAnimSeqName, 1.0f, 0.10f, 0.0f, false, true, false, false);		
		}
		else
		{
			FireAnimSeqName = Moves[((int)MovementState)].PlayFireAnimation();
		}
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Ready/*2*/);
		if(CustomWeaponNode1p != default)
		{
			AnimSeq1p = ((CustomWeaponNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		}
		if(CustomWeaponNode3p != default)
		{
			AnimSeq3p = ((CustomWeaponNode3p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		}
		if(AnimSeq1p != default)
		{
			AnimSeq1p.AnimationType = TdAnimNodeSequence.EAnimType.EA_Fire/*1*/;
		}
		if(AnimSeq3p != default)
		{
			AnimSeq3p.AnimationType = TdAnimNodeSequence.EAnimType.EA_Fire/*1*/;
		}
		return FireAnimSeqName;
	}
	
	public virtual /*simulated function */void PlayWeaponStoppedReloading()
	{
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Ready/*2*/);
	}
	
	public virtual /*simulated function */void PlayWeaponPutDown()
	{
	
	}
	
	// Export UTdPawn::execCanDropWeapon(FFrame&, void* const)
	public virtual /*native function */bool CanDropWeapon()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */bool CanZoom()
	{
		return !(((((int)Moves[((int)MovementState)].MovementGroup) > ((int)TdMove.EMovementGroup.MG_Free/*0*/)) || ((int)AgainstWallState) != ((int)TdPawn.EAgainstWallState.AW_None/*0*/)) || ((int)WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Throwing/*4*/)) || IsTimerActive("DropWeapon", default(Object?));
	}
	
	public virtual /*simulated function */void DropWeapon()
	{
		/*local */TdWeapon TdW = default;
		/*local */TdAnimNodeSequence AnimSeq1p = default;
	
		TdW = MyWeapon;
		if(TdW == default)
		{
			return;
		}
		if((((int)WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Throwing/*4*/)) || IsTimerActive("RemoveWeaponAfterDrop", default(Object?)))
		{
			return;
		}
		ClearTimer("DropWeapon", default(Object?));
		if(TdW.IsZoomingOrZoomed())
		{
			SetTimer(0.50f, false, "DropWeapon", default(Object?));
			return;
		}
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Throwing/*4*/);
		PlayCustomAnim(TdPawn.CustomNodeType.CNT_CannedUpperBody/*1*/, "throwaway", 1.0f, 0.10f, 0.0f, false, true, false, default(bool?));
		if(((int)TdW.WeaponType) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
		{
			if(TdW.WeaponAnimationNode1p != default)
			{
				TdW.WeaponAnimationNode1p.PlayCustomAnim("weaponpose", 1.0f, 0.10f, -1.0f, false, true);
			}
			if(TdW.WeaponAnimationNode3p != default)
			{
				TdW.WeaponAnimationNode3p.PlayCustomAnim("weaponpose", 1.0f, 0.10f, -1.0f, false, true);
			}
		}
		AnimSeq1p = ((CustomCannedUpperBodyNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
		SetTimer(AnimSeq1p.AnimSeq.SequenceLength, false, "RemoveWeaponAfterDrop", default(Object?));
	}
	
	public virtual /*function */void TossWeapon(Weapon Weap, /*optional */Object.Vector? _ForceVelocity = default)
	{
		/*local */TdWeapon TdW = default;
		/*local */Object.Vector WeaponLocation = default, WeaponVelocity = default, WeaponAngularVelocity = default, v1 = default, v2 = default, v3 = default;
	
		/*local */Object.Rotator WeaponRotation = default;
	
		var ForceVelocity = _ForceVelocity ?? default;
		TdW = ((Weap) as TdWeapon);
		if(TdW != default)
		{
			WeaponLOINotifyOFF();
			GetAxes(Controller.Rotation, ref/*probably?*/ v1, ref/*probably?*/ v2, ref/*probably?*/ v3);
			if(Health <= 0)
			{
				WeaponVelocity = (Velocity * 2.0f) + (((v1 * 25.0f) + (v2 * 25.0f)) + (v3 * 25.0f));
				WeaponAngularVelocity.X = 50.0f + (60.0f * FRand());			
			}
			else
			{
				WeaponVelocity = ((v1 * TdW.WeaponDropLinearVelocity.X) + (v2 * TdW.WeaponDropLinearVelocity.Y)) + (v3 * TdW.WeaponDropLinearVelocity.Z);
			}
			if(!CanDropWeapon())
			{
				WeaponLocation = Location;
				WeaponRotation = Rotation;
				WeaponRotation.Pitch -= ((int)(16384.0f));			
			}
			else
			{
				GetWeaponJointPosition(ref/*probably?*/ WeaponLocation, ref/*probably?*/ WeaponRotation);
			}
			TdW.DropFromEx(WeaponLocation, WeaponVelocity, WeaponRotation, WeaponAngularVelocity);
		}
	}
	
	public virtual /*function */void RemoveWeaponAfterDrop()
	{
		/*local */TdWeapon TdW = default;
	
		TdW = MyWeapon;
		if(TdW != default)
		{
			if(!TdW.bHidden)
			{
				TossWeapon(TdW, default(Object.Vector?));
			}
			if(TdW.Instigator.InvManager != default)
			{
				TdW.InvManager.RemoveFromInventory(TdW);
			}
			TdW.Destroy();
		}
		SetAimOffsetNodesProfile("OneHanded");
	}
	
	public virtual /*event */void WeaponLOINotifyON(float EffectDisplayTime)
	{
		/*local */TdWeapon WP = default;
	
		if(MyWeapon != default)
		{
			WP = MyWeapon;
			WP.LOIDisplayEffectTime = EffectDisplayTime;
			WP.LOIOriginalDisplayEffectTime = EffectDisplayTime;
			WP.LOINotify(true);
		}
	}
	
	public virtual /*event */void WeaponLOINotifyOFF()
	{
		if(MyWeapon != default)
		{
			MyWeapon.LOINotify(false);
		}
	}
	
	public virtual /*event */void ReleaseWeaponNotify()
	{
		TossWeapon(Weapon, default(Object.Vector?));
	}
	
	public virtual /*event */void AnimNotifyGrenadeThrow()
	{
		if(((Weapon) as TdWeapon_Grenade) != default)
		{
			((Weapon) as TdWeapon_Grenade).AnimNotifyGrenadeThrow();
		}
	}
	
	// Export UTdPawn::execGetCameraAnimation(FFrame&, void* const)
	public virtual /*native final function */void GetCameraAnimation(ref Object.Vector out_Location, ref Object.Rotator out_Rotation)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*event */bool AddCameraDeltaAnimations()
	{
		/*local */TdAnimNodeSequence CurrentSeq = default;
	
		if(CustomCameraNode != default)
		{
			CurrentSeq = ((CustomCameraNode.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
			if((CurrentSeq != default) && CurrentSeq.bDeltaCameraAnimation)
			{
				return true;
			}
		}
		if(CustomWeaponNode1p != default)
		{
			CurrentSeq = ((CustomWeaponNode1p.GetCustomAnimNodeSeq()) as TdAnimNodeSequence);
			if((CurrentSeq != default) && CurrentSeq.bDeltaCameraAnimation)
			{
				return true;
			}
		}
		return false;
	}
	
	public virtual /*event */Object.Vector GetSwanNeckTranslation()
	{
		/*local */Object.Vector ReturnVector = default;
	
		return ((SwanNeck1p != default) ? SwanNeck1p.Translation : ReturnVector);
	}
	
	public override /*event */void OnAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
		((SeqNode) as TdAnimNodeSequence).ResetNodeStates();
		if(SeqNode.SkelComponent == Mesh)
		{
			if(Moves[((int)MovementState)].CurrentCustomAnimName == SeqNode.AnimSeqName)
			{
				Moves[((int)MovementState)].OnCustomAnimEnd(SeqNode, PlayedTime, ExcessTime);
			}
		}
	}
	
	public virtual /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
		if(SeqNode.SkelComponent == Mesh)
		{
			if(Moves[((int)MovementState)].CurrentCustomAnimName == SeqNode.AnimSeqName)
			{
				Moves[((int)MovementState)].OnCeaseRelevantRootMotion(SeqNode);
			}
		}
	}
	
	public virtual /*simulated function */void UpdateAnimSets(/*optional */TdWeapon? _NewWeapon = default)
	{
		/*local */bool bHasFirstPerson = default;
	
		var NewWeapon = _NewWeapon ?? default;
		bHasFirstPerson = Mesh1p != default;
		if(NewWeapon != default)
		{
			NewWeapon.UpdateAnimSets(bIsFemale, bHasFirstPerson);
			UpdateDPG(NewWeapon.Mesh);
			UpdateWeaponPoseProfile(NewWeapon);
			NewWeapon.UpdateAnimations();
		}
		if(bHasFirstPerson)
		{
			Mesh1p.AnimSets[1] = ((NewWeapon != default) ? ((((int)NewWeapon.WeaponType) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/)) ? CommonArmedLight1p : CommonArmedHeavy1p) : default);
			Mesh1p.AnimSets[2] = ((NewWeapon != default) ? NewWeapon.AnimationSetCharacter1p : default);
			Mesh1p.UpdateAnimations();
		}
		Mesh3p.AnimSets[1] = ((NewWeapon != default) ? ((((int)NewWeapon.WeaponType) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/)) ? CommonArmedLight3p : CommonArmedHeavy3p) : default);
		Mesh3p.AnimSets[2] = ((NewWeapon != default) ? NewWeapon.AnimationSetFemale3p : default);
		Mesh3p.UpdateAnimations();
	}
	
	public virtual /*simulated function */void UpdateDPG(MeshComponent MeshComp)
	{
	
	}
	
	public virtual /*simulated function */void UpdateWeaponPoseProfile(TdWeapon NewWeapon)
	{
		SetWeaponPoseOffsetProfile(NewWeapon.WeaponPoseProfileName);
	}
	
	public virtual /*exec function */void ValueIkControllers()
	{
	
	}
	
	public virtual /*simulated function */void SetLeftHandWorldIKLocation(Object.Vector TargetLocation, /*optional */float? _ControllerBlendInTime = default)
	{
		var ControllerBlendInTime = _ControllerBlendInTime ?? 0.0f;
		LeftHandWorldIKController.EffectorLocation = TargetLocation;
		LeftHandWorldIKController.EffectorLocationSpace = SkelControlBase.EBoneControlSpace.BCS_WorldSpace/*0*/;
		LeftHandWorldIKController.SetSkelControlStrength(1.0f, ControllerBlendInTime);
	}
	
	public virtual /*simulated function */void SetRightHandWorldIKLocation(Object.Vector TargetLocation, /*optional */float? _ControllerBlendInTime = default)
	{
		var ControllerBlendInTime = _ControllerBlendInTime ?? 0.0f;
		RightHandWorldIKController.EffectorLocation = TargetLocation;
		RightHandWorldIKController.EffectorLocationSpace = SkelControlBase.EBoneControlSpace.BCS_WorldSpace/*0*/;
		RightHandWorldIKController.SetSkelControlStrength(1.0f, ControllerBlendInTime);
	}
	
	public virtual /*simulated function */void SetHandsWorldIKLocation(Object.Vector LeftHandTargetLocation, Object.Vector RightHandTargetLocation, /*optional */float? _ControllerBlendInTime = default)
	{
		var ControllerBlendInTime = _ControllerBlendInTime ?? 0.0f;
		SetLeftHandWorldIKLocation(LeftHandTargetLocation, ControllerBlendInTime);
		SetRightHandWorldIKLocation(RightHandTargetLocation, ControllerBlendInTime);
	}
	
	public virtual /*simulated function */void DisableLeftHandWorldIK(/*optional */float? _ControllerBlendInTime = default)
	{
		var ControllerBlendInTime = _ControllerBlendInTime ?? 0.0f;
		LeftHandWorldIKController.SetSkelControlStrength(0.0f, ControllerBlendInTime);
	}
	
	public virtual /*simulated function */void DisableRightHandWorldIK(/*optional */float? _ControllerBlendInTime = default)
	{
		var ControllerBlendInTime = _ControllerBlendInTime ?? 0.0f;
		RightHandWorldIKController.SetSkelControlStrength(0.0f, ControllerBlendInTime);
	}
	
	public virtual /*simulated function */void DisableHandsWorldIK(/*optional */float? _ControllerBlendInTime = default)
	{
		var ControllerBlendInTime = _ControllerBlendInTime ?? 0.0f;
		DisableLeftHandWorldIK(ControllerBlendInTime);
		DisableRightHandWorldIK(ControllerBlendInTime);
	}
	
	public virtual /*simulated function */void SetWeaponAnimState(TdPawn.EWeaponAnimState AnimState)
	{
		if((((int)AnimState) != ((int)TdPawn.EWeaponAnimState.WS_Unarmed/*0*/)) && Weapon == default)
		{
			WeaponAnimState = TdPawn.EWeaponAnimState.WS_Unarmed/*0*/;
			return;
		}
		if(((int)WeaponAnimState) == ((int)AnimState))
		{
			return;
		}
		if(((int)AnimState) == ((int)TdPawn.EWeaponAnimState.WS_Ready/*2*/))
		{
			BecameReadyTime = WorldInfo.TimeSeconds;
			AmountTilUnarmed = ((((int)GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/)) ? 1000.0f : 0.0f);
		}
		WeaponAnimState = ((TdPawn.EWeaponAnimState)AnimState);
		UpdateWeaponSkelControls();
	}
	
	public virtual /*simulated function */void UpdateWeaponSkelControls()
	{
		/*local */TdWeapon TdWeap = default;
	
		TdWeap = MyWeapon;
		if(((((int)WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Ready/*2*/)) && TdWeap != default) && ((int)TdWeap.WeaponType) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/))
		{
			if(RecoilControl1p != default)
			{
				RecoilControl1p.SetSkelControlStrength(1.0f, 0.20f);
			}
			if(OneHandedRightShoulderOffset1p != default)
			{
				OneHandedRightShoulderOffset1p.SetSkelControlStrength(1.0f, 0.20f);
			}		
		}
		else
		{
			if(RecoilControl1p != default)
			{
				RecoilControl1p.SetSkelControlStrength(0.0f, 0.20f);
			}
			if(OneHandedRightShoulderOffset1p != default)
			{
				OneHandedRightShoulderOffset1p.SetSkelControlStrength(0.0f, 0.20f);
			}
		}
	}
	
	public virtual /*simulated function */void UpdateRightShoulderOffset()
	{
		/*local */TdWeapon TdWeap = default;
	
		TdWeap = MyWeapon;
		if((TdWeap != default) && ((int)TdWeap.WeaponType) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/))
		{
			if(OneHandedRightShoulderOffset1p != default)
			{
				OneHandedRightShoulderOffset1p.BoneTranslation = TdWeap.OneHandedRightShoulderTranslationOffset;
				OneHandedRightShoulderOffset1p.BoneRotation = TdWeap.OneHandedRightShoulderRotationOffset;
			}
		}
	}
	
	public virtual /*simulated function */void UpdateWeaponAnimState(float DeltaTime)
	{
		/*local */TdPawn.EWeaponType CurrentWeaponType = default;
		/*local */float TimeToStayReady = default;
		/*local */TdPawn.EWeaponAnimState NewWeaponAnimState = default;
	
		CurrentWeaponType = ((TdPawn.EWeaponType)GetWeaponType());
		AmountTilUnarmed -= (VelocityMagnitude * DeltaTime);
		TimeToStayReady = ((((int)CurrentWeaponType) == ((int)TdPawn.EWeaponType.EWT_Light/*2*/)) ? 5.0f : 1.0f);
		if(((AmountTilUnarmed <= 0.0f) && ((int)WeaponAnimState) == ((int)TdPawn.EWeaponAnimState.WS_Ready/*2*/)) && BecameReadyTime < (WorldInfo.TimeSeconds - TimeToStayReady))
		{
			if(((int)CurrentWeaponType) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/))
			{
				NewWeaponAnimState = ((TdPawn.EWeaponAnimState)((Moves[((int)MovementState)].bTwoHandedFullBodyAnimations) ? 5 : 2));			
			}
			else
			{
				NewWeaponAnimState = TdPawn.EWeaponAnimState.WS_Relaxed/*1*/;
			}
			SetWeaponAnimState(((TdPawn.EWeaponAnimState)NewWeaponAnimState));
			AmountTilUnarmed = 0.0f;
		}
	}
	
	public virtual /*simulated function */void SetUnarmed()
	{
		if(Weapon != default)
		{
			DetachWeaponFromHand(Weapon);
		}
		SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Unarmed/*0*/);
		UpdateAnimSets(default(TdWeapon?));
	}
	
	public virtual /*simulated function */void SetArmed()
	{
		if(Weapon != default)
		{
			AttachWeaponToHand(Weapon);
			SetWeaponAnimState(TdPawn.EWeaponAnimState.WS_Relaxed/*1*/);
		}
		UpdateAnimSets(MyWeapon);
	}
	
	public virtual /*function */bool IsLeftLegForward()
	{
		/*local */AnimNodeSynch MasterSync = default;
	
		MasterSync = ((MasterSync1p != default) ? MasterSync1p : MasterSync3p);
		return MasterSync.Groups[0].MasterNode.CurrentTime > (MasterSync.Groups[0].MasterNode.AnimSeq.SequenceLength / 2.0f);
	}
	
	public virtual /*simulated function */void SetAimOffsetNodesProfile(name NewProfileName)
	{
		/*local */int Index = default;
	
		Index = 0;
		J0x07:{}
		if(Index < AimOffsetNodes.Length)
		{
			AimOffsetNodes[Index].SetActiveProfileByName(((name)(((bIsFemale) ? "Female" : "Male") + ((NewProfileName)).ToString())));
			++ Index;
			goto J0x07;
		}
	}
	
	public virtual /*simulated function */void SetWeaponPoseOffsetProfile(name ProfileName)
	{
		if(WeaponPoseOffset1p != default)
		{
			WeaponPoseOffset1p.SetActiveProfileByName(ProfileName);
		}
		if(WeaponPoseOffset3p != default)
		{
			WeaponPoseOffset3p.SetActiveProfileByName(ProfileName);
		}
	}
	
	public virtual /*simulated exec function */void EnableWeaponPose()
	{
		if(WeaponPoseOffset1p != default)
		{
			WeaponPoseOffset1p.bDisable = false;
		}
		if(WeaponPoseOffset3p != default)
		{
			WeaponPoseOffset3p.bDisable = false;
		}
	}
	
	public virtual /*simulated exec function */void DisableWeaponPose()
	{
		if(WeaponPoseOffset1p != default)
		{
			WeaponPoseOffset1p.bDisable = true;
		}
		if(WeaponPoseOffset3p != default)
		{
			WeaponPoseOffset3p.bDisable = true;
		}
	}
	
	public virtual /*simulated function */void ShowSkeletalMeshInformation(Canvas Canvas, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*simulated function */void DrawDebugAnims(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*exec function */void ToggleHandIK()
	{
		if(LeftHandWorldIKController.ControlStrength > 0.0f)
		{
			LeftHandWorldIKController.SetSkelControlStrength(0.0f, 0.0f);		
		}
		else
		{
			LeftHandWorldIKController.SetSkelControlStrength(1.0f, 0.0f);
		}
		if(RightHandWorldIKController.ControlStrength > 0.0f)
		{
			RightHandWorldIKController.SetSkelControlStrength(0.0f, 0.0f);		
		}
		else
		{
			RightHandWorldIKController.SetSkelControlStrength(1.0f, 0.0f);
		}
	}
	
	public virtual /*event */void NotifyActivateUsed(Actor InOriginator, SeqEvent_Used UsedEvent)
	{
		/*local */TdMove_Interact InteractMove = default;
		/*local */int LinkIt = default;
	
		LinkIt = 0;
		J0x07:{}
		if(LinkIt < UsedEvent.OutputLinks.Length)
		{
			((UsedEvent) as SeqEvent_TdUsed).OutputLinks[LinkIt].bHasImpulse = false;
			LinkIt += 1;
			goto J0x07;
		}
		if(((((InOriginator) as TdTrigger) != default) && ((UsedEvent) as SeqEvent_TdUsed) != default) && ((UsedEvent) as SeqEvent_TdUsed).bInteract == false)
		{
			InteractMove = ((Moves[39]) as TdMove_Interact);
			InteractMove.SetCurrentTrigger(((InOriginator) as TdTrigger));
			InteractMove.SetCurrentEvent(((UsedEvent) as SeqEvent_TdUsed));
			if(Moves[39].CanDoMove())
			{
				SetMove(TdPawn.EMovement.MOVE_Interact/*39*/, default(bool?), default(bool?));			
			}
			else
			{
				InteractMove.ReleaseCurrentTriggerAndEvent();
			}
		}
		if((((UsedEvent) as SeqEvent_TdUsed) != default) && ((int)MovementState) != ((int)TdPawn.EMovement.MOVE_Interact/*39*/))
		{
			UsedEvent.TriggerCount -= 1;
			((UsedEvent) as SeqEvent_TdUsed).bInteract = false;
		}
	}
	
	public override /*function */void PlayTeleportEffect(bool bOut, bool bSound)
	{
	
	}
	
	public virtual /*function */float sign(float X)
	{
		if(X < ((float)(0)))
		{
			return -1.0f;		
		}
		else
		{
			if(X > ((float)(0)))
			{
				return 1.0f;			
			}
			else
			{
				return 0.0f;
			}
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public override /*function */bool CanAttack(Actor Other)
	{
		if(Weapon == default)
		{
			return false;
		}
		if(Weapon.CanAttack(Other))
		{
			return true;
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*exec function */void LoadFullInventory()
	{
	
	}
	
	public virtual /*exec function */void LoadWeapon(int Slot)
	{
	
	}
	
	public virtual /*function */bool InJesusMode()
	{
	
		return default;
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdPawn_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdPawn_TakeDamage;
	public /*event */void TdPawn_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default, /*optional */Actor? _DamageCauser = default)
	{
		/*local */Core.ClassT<TdDamageType> CurrentDamageType = default;
	
		var HitInfo = _HitInfo ?? default;
		var DamageCauser = _DamageCauser ?? default;
		CurrentDamageType = ((DamageType) as ClassT<TdDamageType>);
		if(CurrentDamageType != default)
		{
			LastPhysHitInfo.DamageType = CurrentDamageType;
			LastPhysHitInfo.HitBone = HitInfo.BoneName;
			LastPhysHitInfo.HitLocation = HitLocation;
			LastPhysHitInfo.Momentum = damageMomentum;
			LastPhysHitInfo.HitReactionDuration = CurrentDamageType.DefaultAs<TdDamageType>().PhysicsHitReactionDuration;
			if(((DamageType) as ClassT<TdDmgType_Bullet>) != default)
			{
				LastPhysHitInfo.AngularVelocity = ((DamageType) as ClassT<TdDmgType_Bullet>).DefaultAs<TdDmgType_Bullet>().AngularVelocity;			
			}
			else
			{
				LastPhysHitInfo.AngularVelocity = 0.0f;
			}
		}
		UpdateSpecialDamage(ref/*probably?*/ Damage, DamageType);
		LastDamageTaken = Damage;
		if((Health - Damage) <= 0)
		{
			Damage = Moves[((int)MovementState)].HandleDeath(Damage);
		}
		if(IsHumanControlled())
		{
			if(((((DamageType) as ClassT<TdDmgType_Shove>) != default) || ((DamageType) as ClassT<TdDmgType_Melee>) != default) || ((DamageType) as ClassT<TdDmgType_Taser>) != default)
			{
				StumbleDamage(((InstigatedBy != default) ? ((InstigatedBy.Pawn) as TdPawn) : default), HitLocation, damageMomentum, DamageType);			
			}
			else
			{
				BulletDamage(((InstigatedBy != default) ? ((InstigatedBy.Pawn) as TdPawn) : default), HitLocation, damageMomentum, DamageType);
			}
		}
		/*Transformed 'base.' to specific call*/Pawn_TakeDamage(Damage, InstigatedBy, HitLocation, damageMomentum, DamageType, HitInfo, default(Actor?));
		if((!IsHumanControlled() && Health > 0) && CurrentDamageType != default)
		{
			PlayPhysicsBodyImpact(InstigatedBy, LastPhysHitInfo);
		}
		UpdateDamageStats(InstigatedBy, DamageType);
		TimeSinceLastDamage = 0.0f;
		HealthFrac = 0.0f;
	}
	
	public virtual /*function */void UpdateSpecialDamage(ref int Damage, Core.ClassT<DamageType> DamageType)
	{
		/*local */Object.Vector ElectricShockVelocity = default;
	
		if((DamageType == ClassT<TdDmgType_Flashbang>()) || DamageType == ClassT<TdDmgType_HeavyFlashbang>())
		{
			StunDamageLevel = FClamp(StunDamageLevel + ((float)(Damage)), 0.0f, 100.0f);
			Damage = 1;		
		}
		else
		{
			if(DamageType == ClassT<TdDmgType_ElectricShock>())
			{
				if(!Moves[((int)MovementState)].bUseCustomCollision && ((int)Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
				{
					SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
				}
				ElectricShockVelocity = -VelocityDir;
				ElectricShockVelocity.Z = FClamp(ClassT<TdDmgType_ElectricShock>().DefaultAs<TdDmgType_ElectricShock>().DamageZDirection, 0.10f, 1.0f);
				ElectricShockVelocity = ElectricShockVelocity * ClassT<TdDmgType_ElectricShock>().DefaultAs<TdDmgType_ElectricShock>().DamageImpulse;
				Velocity = ElectricShockVelocity;
				Acceleration = Normal(ElectricShockVelocity);
				TaserDamageLevel = FClamp(TaserDamageLevel + ((float)(Damage)), 0.0f, 100.0f);
			}
		}
	}
	
	public virtual /*function */void UpdateDamageStats(Controller InstigatedBy, Core.ClassT<DamageType> DamageType)
	{
		/*local */TdPlayerController TargetPC = default, SourcePC = default;
	
		if((((DamageType) as ClassT<TdDmgType_Bullet>) != default) || DamageType == ClassT<TdDmgType_Taser>())
		{
			if(InstigatedBy != default)
			{
				TargetPC = ((Controller) as TdPlayerController);
				if(TargetPC != default)
				{
					TargetPC.AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_HitByEnemyWeapon/*4*/);				
				}
				else
				{
					SourcePC = ((InstigatedBy) as TdPlayerController);
					if(SourcePC != default)
					{
						SourcePC.AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_HittingEnemyWithWeapon/*5*/);
					}
				}
			}		
		}
		else
		{
			if(DamageType == ClassT<TdDmgType_MeleeWallRun>())
			{
				SourcePC = ((InstigatedBy) as TdPlayerController);
				if(SourcePC != default)
				{
					SourcePC.AddStatsEvent(SeqAct_TdRegisterStat.EAchievementStatsID.EASID_SPMeleeAirKills/*2*/);
				}
			}
		}
	}
	
	public override /*function */void AdjustDamage(ref int inDamage, ref Object.Vector OutMomentum, Controller InstigatedBy, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		/*local *//*editinline */TdSkeletalMeshComponent MeshComponent = default;
		/*local */float ArmorValue = default;
	
		var HitInfo = _HitInfo ?? default;
		MeshComponent = ((HitInfo.HitComponent) as TdSkeletalMeshComponent);
		if(MeshComponent == default)
		{
			return;
		}
		if(HitInfo.BoneName == "Neck")
		{
			if(((DamageType) as ClassT<TdDmgType_Melee>) != default)
			{
				ArmorValue = ArmorMeleeHead;			
			}
			else
			{
				ArmorValue = ArmorBulletsHead;
			}		
		}
		else
		{
			if(((MeshComponent.IsChildBoneOf(HitInfo.BoneName, "LeftUpLeg") || MeshComponent.IsChildBoneOf(HitInfo.BoneName, "RightUpLeg")) || HitInfo.BoneName == "RightUpLeg") || HitInfo.BoneName == "LeftUpLeg")
			{
				if(((DamageType) as ClassT<TdDmgType_Melee>) != default)
				{
					ArmorValue = ArmorMeleeLegs;				
				}
				else
				{
					ArmorValue = ArmorBulletsLegs;
				}			
			}
			else
			{
				if(((DamageType) as ClassT<TdDmgType_Melee>) != default)
				{
					ArmorValue = ArmorMeleeBody;				
				}
				else
				{
					ArmorValue = ArmorBulletsBody;
				}
			}
		}
		inDamage = Max(0, ((int)(((float)(inDamage)) * (1.0f - ArmorValue))));
	}
	
	public override Died_del Died { get => bfield_Died ?? TdPawn_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public override Died_del global_Died => TdPawn_Died;
	public /*function */bool TdPawn_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
		/*local */bool retval = default;
	
		Moves[((int)MovementState)].StopMove();
		retval = /*Transformed 'base.' to specific call*/Pawn_Died(Killer, DamageType, HitLocation);
		if(retval)
		{
			NotifyTakeHit(Killer, HitLocation, LastDamageTaken, DamageType, TearOffMomentum);
		}
		return retval;
	}
	
	public virtual /*function */void PlayFaceAnimation(name AnimSeqName, /*optional */bool? _bLooping = default, /*optional */float? _BlendInTime = default, /*optional */float? _BlendOutTime = default)
	{
		var bLooping = _bLooping ?? false;
		var BlendInTime = _BlendInTime ?? 0.20f;
		var BlendOutTime = _BlendOutTime ?? 0.20f;
		PlayCustomAnim(TdPawn.CustomNodeType.CNT_Face/*8*/, AnimSeqName, 1.0f, BlendInTime, BlendOutTime, bLooping, true, false, false);
	}
	
	public virtual /*function */void StopFaceAnimation(/*optional */float? _BlendOutTime = default)
	{
		var BlendOutTime = _BlendOutTime ?? 0.20f;
		StopCustomAnim(TdPawn.CustomNodeType.CNT_Face/*8*/, BlendOutTime);
	}
	
	public override /*function */void AddVelocity(Object.Vector NewVelocity, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo? _HitInfo = default)
	{
		var HitInfo = _HitInfo ?? default;
		if(bIgnoreForces || NewVelocity == vect(0.0f, 0.0f, 0.0f))
		{
			return;
		}
		if((((int)Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/)) || ((((int)Physics) == ((int)Actor.EPhysics.PHYS_Ladder/*9*/)) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_Spider/*8*/)) && NewVelocity.Z > DefaultAs<Pawn>().JumpZ)
		{
			SetPhysics(Actor.EPhysics.PHYS_Falling/*2*/);
		}
		if((Velocity.Z > DefaultAs<Pawn>().JumpZ) && NewVelocity.Z > ((float)(0)))
		{
			NewVelocity.Z *= 0.50f;
		}
		Velocity += NewVelocity;
	}
	
	public virtual /*simulated function */void StumbleDamage(TdPawn InstigatorPawn, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType)
	{
		/*local */TdMove_StumbleBase StumbleMove = default;
		/*local */bool StumbleHard = default;
	
		StumbleHard = DamageType == ClassT<TdDmgType_MeleeSecondSwing>();
		if(StumbleHard)
		{
			StumbleMove = ((Moves[55]) as TdMove_StumbleBase);		
		}
		else
		{
			StumbleMove = ((Moves[35]) as TdMove_StumbleBase);
		}
		if(StumbleMove != default)
		{
			StumbleMove.InstigatorLocation = ((InstigatorPawn != default) ? InstigatorPawn.Location : vect(0.0f, 0.0f, 0.0f));
			StumbleMove.Instigator = InstigatorPawn;
			StumbleMove.damageMomentum = damageMomentum;
			StumbleMove.DamageLocation = HitLocation;
			StumbleMove.HitDamageType = DamageType;
		}
		if(StumbleHard)
		{
			HandleMoveAction(TdPawn.EMovementAction.MA_StumbleHard/*18*/);		
		}
		else
		{
			HandleMoveAction(TdPawn.EMovementAction.MA_Stumble/*17*/);
		}
	}
	
	public virtual /*simulated function */void BulletDamage(TdPawn InstigatorPawn, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public virtual /*simulated function */void PrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)
	{
	
	}
	
	public virtual /*reliable server function */void ServerTestMeleeHit(TdPawn Target, float Damage, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation, Object.Vector ImpactMomentum, Actor.TraceHitInfo Hit)
	{
		/*local */Object.Vector ToTarget = default;
	
		ToTarget = Location - Target.Location;
		if((VSize(ToTarget) < 180.0f) && (Dot(((Vector)(Rotation)), Normal(ToTarget))) < 0.0f)
		{
			Target.PlayMeleeImpact(Hit.PhysMaterial, TdPawn.EMeleeImpactType.MIT_Fist/*1*/, HitLocation, -ImpactMomentum, ImpactMomentum, Hit.BoneName, DamageType);
			Target.TakeDamage(((int)(Damage)), Controller, HitLocation, ImpactMomentum, DamageType, Hit, default(Actor?));
		}
	}
	
	public virtual /*reliable server function */void ServerTriggerMelee(TdPawn.EMeleeServerAction ServerAction, byte NewMeleeState)
	{
		/*local */TdMove_MeleeBase MeleeMove = default;
	
		MeleeMove = ((Moves[((int)MovementState)]) as TdMove_MeleeBase);
		if(MeleeMove == default)
		{
			return;
		}
		MeleeMove.SetMeleeState((byte)NewMeleeState);
		switch(ServerAction)
		{
			case TdPawn.EMeleeServerAction.MSA_TriggerMove/*0*/:
				MeleeMove.TriggerMove();
				break;
			case TdPawn.EMeleeServerAction.MSA_TriggerHit/*1*/:
				MeleeMove.TriggerHit();
				goto case TdPawn.EMeleeServerAction.MSA_TriggerMiss/*2*/;// UnrealScript fallthrough
			case TdPawn.EMeleeServerAction.MSA_TriggerMiss/*2*/:
				MeleeMove.TriggerMiss();
				goto default;// UnrealScript fallthrough
			default:
				break;
		}
	}
	
	public virtual /*function */void TakeTaserDamage(Object.Vector ImpactMomentum)
	{
		TimeSinceLastTaserDamage = 0.0f;
		TaserDamageLevel = FClamp(TaserDamageLevel + ClassT<TdDmgType_Taser>().DefaultAs<TdDmgType_Taser>().ContiniousTaserDamage, ClassT<TdDmgType_Taser>().DefaultAs<TdDmgType_Taser>().InitialTaserDamage, 100.0f);
		Moves[((int)MovementState)].TakeTaserDamage(ImpactMomentum);
	}
	
	public override /*function */void TakeFallingDamage()
	{
		/*local */float EffectiveSpeed = default, Damage = default, LandSpeed = default;
	
		LandSpeed = Velocity.Z + ((float)(Max(0, ((int)(Dot(((Vector)(Rotation)), Velocity))))));
		if(LandSpeed < (-0.50f * MaxFallSpeed))
		{
			if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
			{
				MakeNoise(1.0f, "PlayerMovementNoise");
				if(LandSpeed < (((float)(-1)) * MaxFallSpeed))
				{
					EffectiveSpeed = LandSpeed;
					if(TouchingWaterVolume())
					{
						EffectiveSpeed += ((float)(100));
					}
					if(IsInState("UncontrolledFall", default(bool?)))
					{
						EffectiveSpeed -= ((float)(1000));
					}
					if(EffectiveSpeed < (((float)(-1)) * MaxFallSpeed))
					{
						Damage = ((-100.0f * UnrealEngineFallDamageScale) * (EffectiveSpeed + MaxFallSpeed)) / MaxFallSpeed;
						TakeDamage(((int)(Damage)), default, Location, vect(0.0f, 0.0f, 0.0f), ClassT<DmgType_Fell>(), default(Actor.TraceHitInfo?), default(Actor?));
					}
				}
			}		
		}
		else
		{
			if(LandSpeed < (-1.40f * JumpZ))
			{
				MakeNoise(0.50f, "PlayerMovementNoise");
			}
		}
	}
	
	public delegate bool CanSkillRoll_del();
	public virtual CanSkillRoll_del CanSkillRoll { get => bfield_CanSkillRoll ?? TdPawn_CanSkillRoll; set => bfield_CanSkillRoll = value; } CanSkillRoll_del bfield_CanSkillRoll;
	public virtual CanSkillRoll_del global_CanSkillRoll => TdPawn_CanSkillRoll;
	public /*simulated function */bool TdPawn_CanSkillRoll()
	{
		if(((((((int)GetWeaponType()) == ((int)TdPawn.EWeaponType.EWT_Heavy/*1*/)) || ((int)MovementState) == ((int)TdPawn.EMovement.MOVE_180TurnInAir/*25*/)) || ((int)MovementState) == ((int)TdPawn.EMovement.MOVE_FallingUncontrolled/*72*/)) || ((int)MovementState) == ((int)TdPawn.EMovement.MOVE_MeleeAir/*32*/)) || (((int)MovementState) == ((int)TdPawn.EMovement.MOVE_Landing/*20*/)) && Moves[((int)OldMovementState)].IsA("TdMove_MeleeBase"))
		{
			return false;
		}
		return (RollTriggerTime + 0.20f) > WorldInfo.TimeSeconds;
	}
	
	public delegate void PlayPhysicsBodyImpact_del(Controller InstigatedBy, TdPawn.PhysicalHitInfo Hit);
	public virtual PlayPhysicsBodyImpact_del PlayPhysicsBodyImpact { get => bfield_PlayPhysicsBodyImpact ?? TdPawn_PlayPhysicsBodyImpact; set => bfield_PlayPhysicsBodyImpact = value; } PlayPhysicsBodyImpact_del bfield_PlayPhysicsBodyImpact;
	public virtual PlayPhysicsBodyImpact_del global_PlayPhysicsBodyImpact => TdPawn_PlayPhysicsBodyImpact;
	public /*simulated function */void TdPawn_PlayPhysicsBodyImpact(Controller InstigatedBy, TdPawn.PhysicalHitInfo Hit)
	{
		if((((Mesh3p == default) || ((int)Physics) == ((int)Actor.EPhysics.PHYS_RigidBody/*10*/)) || bPlayedDeath) || IsInState("Dying", default(bool?)))
		{
			return;
		}
		if((Mesh3p.PhysicsAsset == default) || Mesh3p.PhysicsAssetInstance == default)
		{
			return;
		}
		if(((Hit.DamageType) as ClassT<TdDmgType_BarbedWire>) != default)
		{
			return;
		}
		if((((int)MovementState) != ((int)TdPawn.EMovement.MOVE_Stumble/*35*/)) || ((Hit.DamageType) as ClassT<TdDmgType_Melee>) != default)
		{
			StumbleDamage(((InstigatedBy == default) ? default : ((InstigatedBy.Pawn) as TdPawn)), Hit.HitLocation, Hit.Momentum, Hit.DamageType);
		}
		if(Hit.HitBone == "None")
		{
			return;
		}
		if(!Hit.DamageType.DefaultAs<TdDamageType>().bCausePhysicalHitReaction)
		{
			return;
		}
		GetImpactPhysicsImpulse(Hit);
		PhysicsHitReactionBlendTimer = PhysicsHitReactionBlendInTime;
	}
	
	public virtual /*final simulated function */bool StartPhysicsBodyImpact(name HitBoneName, bool bUseMotors, TdPawn.PhysicalHitInfo Hit)
	{
		/*local */bool bFoundBone = default;
		/*local */int BoneIndex = default;
		/*local */Object.Vector2D MotorStrength = default;
	
		BoneIndex = 0;
		J0x07:{}
		if(BoneIndex < Hit.DamageType.DefaultAs<TdDamageType>().PhysicsBodyImpactBoneList.Length)
		{
			if(Hit.DamageType.DefaultAs<TdDamageType>().PhysicsBodyImpactBoneList[BoneIndex] == HitBoneName)
			{
				bFoundBone = true;
				goto J0x6B;
			}
			++ BoneIndex;
			goto J0x07;
		}
		J0x6B:{}
		if(!bFoundBone)
		{
			return false;
		}
		Mesh3p.PhysicsAssetInstance.SetNamedBodiesFixed(false, Hit.DamageType.DefaultAs<TdDamageType>().PhysicsBodyImpactBoneList, Mesh3p, false);
		Mesh3p.bUpdateJointsFromAnimation = true;
		MotorStrength = Hit.DamageType.DefaultAs<TdDamageType>().PhysHitReactionMotorStrength;
		Mesh3p.PhysicsAssetInstance.SetAllMotorsAngularDriveParams(MotorStrength.X, MotorStrength.Y, 0.0f);
		Mesh3p.PhysicsAssetInstance.SetAllMotorsAngularPositionDrive(true, true);
		Mesh3p.WakeRigidBody(default(name?));
		Mesh3p.PhysicsWeight = 1.0f;
		return true;
	}
	
	public virtual /*final simulated function */Object.Vector GetImpactPhysicsImpulse(TdPawn.PhysicalHitInfo Hit)
	{
		/*local */Object.Vector Impulse = default;
		/*local */Object.Rotator HitRotation = default;
	
		HitRotation = ((Rotator)(Hit.Momentum));
		HitRotation.Yaw += (Rand(12000) - 6000);
		LastPhysHitInfo.Momentum = ((Vector)(HitRotation));
		Impulse = ((Vector)(HitRotation)) * Hit.DamageType.DefaultAs<DamageType>().KDamageImpulse;
		Impulse *= (1.0f - FClamp(PhysicsHitReactionBlendTimer / Hit.DamageType.DefaultAs<TdDamageType>().PhysicsHitReactionDuration, 0.0f, 1.0f));
		Impulse *= PhysicsHitReactionScale;
		return Impulse;
	}
	
	public virtual /*final simulated function */void StopPhysicsBodyImpact()
	{
		Mesh3p.PhysicsWeight = 0.0f;
		PhysicsHitReactionBlendTimer = 0.0f;
		PhysicsHitReactionBlendOut = 0.0f;
		Mesh3p.PhysicsAssetInstance.SetAllMotorsAngularDriveStrength(1.0f, 1.0f, 1.0f, Mesh3p);
		Mesh3p.PhysicsAssetInstance.SetAllBodiesFixed(true);
		Mesh3p.bUpdateJointsFromAnimation = false;
		Mesh3p.PhysicsAssetInstance.SetAllMotorsAngularPositionDrive(false, false);
	}
	
	public virtual /*final simulated function */void UpdatePhysicalAnimBlendValue(float DeltaTime)
	{
		if(PhysicsHitReactionBlendTimer <= 0.0f)
		{
			return;
		}
		Mesh3p.PhysicsWeight = FClamp(PhysicsHitReactionBlendTimer / FMin(LastPhysHitInfo.DamageType.DefaultAs<TdDamageType>().PhysicsHitReactionBlendOutTime, 1.0f), 0.0f, 1.0f);
		PhysicsHitReactionBlendTimer -= DeltaTime;
		if(PhysicsHitReactionBlendTimer <= 0.0f)
		{
			PhysicsHitReactionBlendTimer = 0.0f;
		}
	}
	
	public override /*singular simulated function */Object.Rotator GetBaseAimRotation()
	{
		/*local */Object.Vector POVLoc = default;
		/*local */Object.Rotator POVRot = default;
	
		if(((Controller != default) && !InCamAimMode()) && !InFreeCam())
		{
			Controller.GetPlayerViewPoint(ref/*probably?*/ POVLoc, ref/*probably?*/ POVRot);
			return POVRot;
		}
		POVRot = Rotation;
		if(POVRot.Pitch == 0)
		{
			POVRot.Pitch = /*<<*/ShiftL(((int)RemoteViewPitch), ((int)8));
		}
		return POVRot;
	}
	
	public virtual /*simulated function */bool AllowStickyAim()
	{
		return true;
	}
	
	public virtual /*simulated function */bool InCamAimMode()
	{
		/*local */PlayerController PC = default;
	
		PC = ((Controller) as PlayerController);
		return ((PC != default) && PC.PlayerCamera != default) && ((((PC.PlayerCamera.CameraStyle == "FreeCam") || PC.PlayerCamera.CameraStyle == "FreeFlight") || PC.PlayerCamera.CameraStyle == "Fixed") || PC.PlayerCamera.CameraStyle == "ThirdPerson") || PC.PlayerCamera.CameraStyle == "FixedPerson";
	}
	
	public override /*simulated function */Object.Vector GetWeaponStartTraceLocation(/*optional */Weapon? _CurrentWeapon = default)
	{
		/*local */Object.Vector out_Location = default;
	
		var CurrentWeapon = _CurrentWeapon ?? default;
		if(InCamAimMode())
		{
			out_Location = Location;
			out_Location.Z += BaseEyeHeight;
			return out_Location;		
		}
		else
		{
			return base.GetWeaponStartTraceLocation(CurrentWeapon);
		}
		#warning decompiling process did not include a return on the last line, added default return
	
		return default;
	}
	
	public virtual /*function */void SetRemoteViewYaw(int NewRemoteViewYaw)
	{
		RemoteViewYaw = NewRemoteViewYaw;
	}
	
	public virtual /*function */Object.Vector GetEyeLocation(Object.Vector baseLocation)
	{
		baseLocation.Z += BaseEyeHeight;
		return baseLocation;
	}
	
	public virtual /*function */Object.Vector GetFeetLocation()
	{
		/*local */Object.Vector feet = default;
	
		feet = Location;
		feet.Z -= (GetCollisionHeight());
		return feet;
	}
	
	public override /*simulated function */bool CalcCamera(float DeltaTime, ref Object.Vector out_Location, ref Object.Rotator out_Rotation, ref float out_FOV)
	{
		if(PassengerDrivenVehicle != default)
		{
			((PassengerDrivenVehicle) as TdVehicle).VehicleCalcCamera(DeltaTime, MyPassengerSeatIndex, ref/*probably?*/ out_Location, ref/*probably?*/ out_Rotation, this);
			return true;
		}
		return false;
	}
	
	public override /*simulated function */void DisplayDebug(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*simulated function */void DisplayFootstepDebug(Canvas cs)
	{
	
	}
	
	public virtual /*function */void TimedScreenMessage(String Message, /*optional */float? _Time = default)
	{
		var Time = _Time ?? 3.0f;
	}
	
	public virtual /*simulated function */void DisplayBreathingDebug(Canvas cs)
	{
	
	}
	
	public virtual /*event */void AddBreathingLog(bool bInhaling)
	{
	
	}
	
	// Export UTdPawn::execRegenerateHealth(FFrame&, void* const)
	public delegate void RegenerateHealth_del(float DeltaTime);
	public virtual RegenerateHealth_del RegenerateHealth { get => bfield_RegenerateHealth ?? TdPawn_RegenerateHealth; set => bfield_RegenerateHealth = value; } RegenerateHealth_del bfield_RegenerateHealth;
	public virtual RegenerateHealth_del global_RegenerateHealth => TdPawn_RegenerateHealth;
	public /*native function */void TdPawn_RegenerateHealth(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execUpdateVelocityVariables(FFrame&, void* const)
	public virtual /*native simulated function */void UpdateVelocityVariables()
	{
		#warning NATIVE FUNCTION !
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdPawn_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdPawn_Tick;
	public /*simulated function */void TdPawn_Tick(float DeltaTime)
	{
		AIAimOldMovementState = ((TdPawn.EMovement)MovementState);
		UpdateVelocityVariables();
		UpdateWalkingState();
		if(((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/))
		{
			RegenerateHealth(DeltaTime);
			if(((int)ReplicateCustomAnimCount) > ((int)1))
			{
				ReplicateCustomAnimCount = (byte)0;
			}
		}
		if(!IsLocallyControlled() && IsHumanControlled())
		{
			UpdatePhysicalAnimBlendValue(DeltaTime);
		}
		if(ActiveMovementVolume != default)
		{
			ActiveMovementVolume.PawnUpdate(this);
		}
		/*Transformed 'base.' to specific call*/Actor_Tick(DeltaTime);
	}
	
	public virtual /*event */void FallingOffWall()
	{
		SetMove(TdPawn.EMovement.MOVE_Falling/*2*/, default(bool?), default(bool?));
	}
	
	public virtual /*event */void ReachedWall()
	{
		Moves[((int)MovementState)].ReachedWall();
	}
	
	public virtual /*simulated function */void GetWeaponHandPosition(ref Object.Vector HandLoc, ref Object.Rotator HandRot)
	{
		HandLoc = Mesh1p.GetBoneLocation("RightHand", 0);
		HandRot = QuatToRotator(Mesh1p.GetBoneQuaternion("RightHand", 0));
	}
	
	public virtual /*simulated function */void GetWeaponJointPosition(ref Object.Vector JointLoc, ref Object.Rotator JointRot)
	{
		if(IsLocallyControlled() && (IsFirstPerson()) || Mesh == Mesh1p)
		{
			JointLoc = Mesh1p.GetBoneLocation("RightWeapon", 0);
			JointRot = QuatToRotator(Mesh1p.GetBoneQuaternion("RightWeapon", 0));		
		}
		else
		{
			JointLoc = Mesh3p.GetBoneLocation("RightWeapon", 0);
			JointRot = QuatToRotator(Mesh3p.GetBoneQuaternion("RightWeapon", 0));
		}
	}
	
	public virtual /*exec function */void MeleeAttackNotify()
	{
		Moves[((int)MovementState)].MeleeAttackNotify();
	}
	
	public virtual /*exec function */void EnableRootMotionNotify()
	{
		Moves[((int)MovementState)].EnableRootMotionNotify();
	}
	
	public virtual /*exec function */void RootRotationCompletedNotify()
	{
		Moves[((int)MovementState)].RootRotationCompletedNotify();
	}
	
	public virtual /*exec function */void DisarmCompleted()
	{
		Moves[((int)MovementState)].DisarmCompleted();
	}
	
	public virtual /*exec function */void DebugFootsteps()
	{
	
	}
	
	public virtual /*exec function */void DebugMove(name MoveName)
	{
	
	}
	
	public virtual /*exec function */void DebugActiveMove()
	{
	
	}
	
	public override /*simulated event */void PlayFootStepSound(int FootDown)
	{
		/*local */float Loudness = default;
		/*local */Actor TraceActor = default;
		/*local */Object.Vector out_HitLocation = default, HitLocation = default, out_HitNormal = default, HitNormal = default, TraceDest = default, TraceStart = default,
			TraceExtent = default, FacingDir = default, BoneLocation = default;
	
		/*local */Actor.TraceHitInfo HitInfo = default, newHitInfo = default;
		/*local */int triggerID = default;
	
		FacingDir = ((Vector)(Rotation));
		FacingDir.Z = 0.0f;
		FacingDir = Normal(FacingDir);
		if(FootDown < 0)
		{
			triggerID = -FootDown;
			if(triggerID <= 20)
			{
				BoneLocation = Mesh.GetBoneLocation("LeftFoot", 0);			
			}
			else
			{
				if(triggerID <= 30)
				{
					BoneLocation = Mesh.GetBoneLocation("LeftHand", 0);				
				}
				else
				{
					BoneLocation = Mesh.GetBoneLocation("LeftShoulder", 0);
				}
			}		
		}
		else
		{
			if(FootDown > 0)
			{
				triggerID = FootDown;
				if(triggerID <= 20)
				{
					BoneLocation = Mesh.GetBoneLocation("RightFoot", 0);				
				}
				else
				{
					if(triggerID <= 30)
					{
						BoneLocation = Mesh.GetBoneLocation("RightHand", 0);					
					}
					else
					{
						BoneLocation = Mesh.GetBoneLocation("RightShoulder", 0);
					}
				}			
			}
			else
			{
				BoneLocation = Location;
				triggerID = 0;
			}
		}
		TraceStart = BoneLocation;
		if(triggerID == 0)
		{
			TraceDest = (TraceStart - (vect(0.0f, 0.0f, 1.0f) * (GetCollisionHeight()))) - vect(0.0f, 0.0f, 35.0f);		
		}
		else
		{
			switch(MovementState)
			{
				case TdPawn.EMovement.MOVE_Walking/*1*/:
				case TdPawn.EMovement.MOVE_Crouch/*15*/:
				case TdPawn.EMovement.MOVE_Slide/*16*/:
				case TdPawn.EMovement.MOVE_Landing/*20*/:
				case TdPawn.EMovement.MOVE_Balance/*29*/:
				case TdPawn.EMovement.MOVE_Snatch/*18*/:
				case TdPawn.EMovement.MOVE_Melee/*17*/:
				case TdPawn.EMovement.MOVE_180Turn/*24*/:
				case TdPawn.EMovement.MOVE_IntoZipLine/*27*/:
				case TdPawn.EMovement.MOVE_ZipLine/*28*/:
				case TdPawn.EMovement.MOVE_RumpSlide/*38*/:
				case TdPawn.EMovement.MOVE_StepUp/*37*/:
				case TdPawn.EMovement.MOVE_Stumble/*35*/:
					if((triggerID >= 8) && triggerID <= 10)
					{
						TraceDest = TraceStart - ((vect(0.0f, 0.0f, 1.0f) * FootstepTraceLength) * 2.0f);					
					}
					else
					{
						TraceDest = TraceStart - (vect(0.0f, 0.0f, 1.0f) * FootstepTraceLength);
					}
					break;
				case TdPawn.EMovement.MOVE_SpringBoarding/*7*/:
				case TdPawn.EMovement.MOVE_Jump/*11*/:
				case TdPawn.EMovement.MOVE_DodgeJump/*33*/:
					TraceDest = TraceStart - ((vect(0.0f, 0.0f, 1.0f) * FootstepTraceLength) * 2.0f);
					break;
				case TdPawn.EMovement.MOVE_WallRunningRight/*4*/:
					TraceDest = TraceStart - (((Cross(FacingDir, vect(0.0f, 0.0f, 1.0f))) + vect(0.0f, 0.0f, 1.0f)) * FootstepTraceLength);
					break;
				case TdPawn.EMovement.MOVE_WallRunningLeft/*5*/:
					TraceDest = TraceStart + (((Cross(FacingDir, vect(0.0f, 0.0f, 1.0f))) - vect(0.0f, 0.0f, 1.0f)) * FootstepTraceLength);
					break;
				case TdPawn.EMovement.MOVE_SpeedVaulting/*8*/:
					if(triggerID > 20)
					{
						TraceStart = MoveLedgeLocation + vect(0.0f, 0.0f, 5.0f);
					}
					TraceDest = TraceStart + ((FacingDir - vect(0.0f, 0.0f, 0.50f)) * FootstepTraceLength);
					break;
				case TdPawn.EMovement.MOVE_VaultOver/*9*/:
				case TdPawn.EMovement.MOVE_IntoGrab/*14*/:
					if(triggerID > 20)
					{
						TraceStart = MoveLedgeLocation + vect(0.0f, 0.0f, 2.0f);
					}
					TraceDest = TraceStart + ((FacingDir - vect(0.0f, 0.0f, 0.50f)) * FootstepTraceLength);
					break;
				case TdPawn.EMovement.MOVE_Grabbing/*3*/:
				case TdPawn.EMovement.MOVE_WallClimbing/*6*/:
				case TdPawn.EMovement.MOVE_IntoClimb/*22*/:
				case TdPawn.EMovement.MOVE_Climb/*21*/:
				case TdPawn.EMovement.MOVE_Falling/*2*/:
				case TdPawn.EMovement.MOVE_Coil/*61*/:
					TraceDest = TraceStart + ((FacingDir + vect(0.0f, 0.0f, 0.50f)) * FootstepTraceLength);
					break;
				case TdPawn.EMovement.MOVE_GrabPullUp/*10*/:
					if(triggerID > 20)
					{
						TraceStart = MoveLedgeLocation + vect(0.0f, 0.0f, 2.0f);
						TraceDest = TraceStart + ((FacingDir - vect(0.0f, 0.0f, 0.50f)) * FootstepTraceLength);					
					}
					else
					{
						if(triggerID == 7)
						{
							TraceDest = TraceStart + (FacingDir * FootstepTraceLength);						
						}
						else
						{
							TraceDest = TraceStart + ((FacingDir - vect(0.0f, 0.0f, 1.0f)) * FootstepTraceLength);
						}
					}
					break;
				case TdPawn.EMovement.MOVE_Barge/*19*/:
				case TdPawn.EMovement.MOVE_WallKick/*23*/:
					if((triggerID > 20) || triggerID == 11)
					{
						TraceStart = Location;
						TraceDest = TraceStart + ((FacingDir * ((float)(4))) * FootstepTraceLength);					
					}
					else
					{
						TraceDest = TraceStart - (vect(0.0f, 0.0f, 1.0f) * FootstepTraceLength);
					}
					break;
				case TdPawn.EMovement.MOVE_WallRunJump/*12*/:
				case TdPawn.EMovement.MOVE_WallRunDodgeJump/*34*/:
					if(((int)OldMovementState) == ((int)TdPawn.EMovement.MOVE_WallRunningRight/*4*/))
					{
						TraceDest = TraceStart - (((float)(2)) * (((Cross(FacingDir, vect(0.0f, 0.0f, 1.0f))) + vect(0.0f, 0.0f, 1.0f)) * FootstepTraceLength));					
					}
					else
					{
						TraceDest = TraceStart + (((float)(2)) * (((Cross(FacingDir, vect(0.0f, 0.0f, 1.0f))) - vect(0.0f, 0.0f, 1.0f)) * FootstepTraceLength));
					}
					break;
				case TdPawn.EMovement.MOVE_GrabJump/*13*/:
					TraceDest = TraceStart - ((((float)(2)) * (FacingDir + vect(0.0f, 0.0f, 0.50f))) * FootstepTraceLength);
					break;
				case TdPawn.EMovement.MOVE_None/*0*/:
				default:
					TraceDest = TraceStart - (vect(0.0f, 0.0f, 1.0f) * (GetCollisionHeight()));
					break;
			}
		}
		TraceExtent = vect(0.50f, 0.50f, 0.50f) * FootstepTraceWidth;
		TraceActor = Trace(ref/*probably?*/ out_HitLocation, ref/*probably?*/ out_HitNormal, TraceDest, TraceStart, true, TraceExtent, ref/*probably?*/ HitInfo, 1);
		if(TraceActor != default)
		{
			HitLocation = out_HitLocation;
			HitNormal = out_HitNormal;
			if((HitInfo.Material == default) && HitInfo.PhysMaterial == default)
			{
				TraceActor = Trace(ref/*probably?*/ out_HitLocation, ref/*probably?*/ out_HitNormal, TraceDest, HitLocation, true, vect(0.0f, 0.0f, 0.0f), ref/*probably?*/ newHitInfo, 1);
				if((TraceActor != default) && (newHitInfo.Material != default) || newHitInfo.PhysMaterial != default)
				{
					HitInfo = newHitInfo;
					HitLocation = out_HitLocation;
					HitNormal = out_HitNormal;
				}
			}
			if((((int)Role) == ((int)Actor.ENetRole.ROLE_Authority/*3*/)) || IsLocallyControlled())
			{
				ActuallyPlayFootStepSound(triggerID, HitInfo, TraceStart);
				Loudness = VelocityMagnitude / GroundSpeed;
				MakeNoise((Loudness * Loudness) * Loudness, "PlayerMovementNoise");
			}
			if(((int)WorldInfo.NetMode) != ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/))
			{
				ActuallyPlayFootParticleEffect(triggerID, HitInfo, HitLocation, HitNormal);
			}
		}
	}
	
	public virtual /*final function */void ActuallyPlayFootStepSound(int FootDown, Actor.TraceHitInfo HitInfo, /*optional */Object.Vector? _HitLoc = default)
	{
		/*local */PhysicalMaterial ParentPhysMaterial = default;
		/*local */array<SoundCue> FootStepSounds = default;
		/*local */int ArrayIndex = default;
		/*local */Object.Vector triggerLocation = default;
	
		var HitLoc = _HitLoc ?? default;
		if((FootDown == 12) || (FootDown >= 26) && FootDown < 31)
		{
			return;
		}
		if(HitInfo.PhysMaterial != default)
		{
			FootStepSounds = GetFootStepSounds(HitInfo.PhysMaterial, FootDown);
			ParentPhysMaterial = HitInfo.PhysMaterial.Parent;
			LastFootstepMaterial = HitInfo.PhysMaterial;		
		}
		else
		{
			if(HitInfo.Material != default)
			{
				if(HitInfo.Material.PhysMaterial != default)
				{
					FootStepSounds = GetFootStepSounds(HitInfo.Material.PhysMaterial, FootDown);
					ParentPhysMaterial = HitInfo.Material.PhysMaterial.Parent;
					LastFootstepMaterial = HitInfo.Material.PhysMaterial;				
				}
				else
				{
					ParentPhysMaterial = default;
					LastFootstepMaterial = default;
				}
			}
		}
		J0x157:{}
		if((FootStepSounds.Length == 0) && ParentPhysMaterial != default)
		{
			FootStepSounds = GetFootStepSounds(ParentPhysMaterial, FootDown);
			LastFootstepMaterial = ParentPhysMaterial;
			ParentPhysMaterial = ParentPhysMaterial.Parent;
			goto J0x157;
		}
		if(FootStepSounds.Length == 0)
		{
			FootStepSounds = GetFootStepSounds(DefaultFootstepMaterial, FootDown);
			LastFootstepMaterial = default;
		}
		if(HitLoc != vect(0.0f, 0.0f, 0.0f))
		{
			triggerLocation = HitLoc;		
		}
		else
		{
			triggerLocation = Location;
		}
		ArrayIndex = 0;
		J0x209:{}
		if(ArrayIndex < FootStepSounds.Length)
		{
			if(FootStepSounds[ArrayIndex] != default)
			{
				this.PlaySound(FootStepSounds[ArrayIndex], false, true, false, triggerLocation, default(bool?), default(bool?));
			}
			++ ArrayIndex;
			goto J0x209;
		}
	}
	
	public virtual /*simulated function */void ActuallyPlayFootParticleEffect(int FootDown, Actor.TraceHitInfo HitInfo, /*optional */Object.Vector? _HitLoc = default, /*optional */Object.Vector? _HitNormal = default)
	{
		/*local */PhysicalMaterial ParentPhysMaterial = default;
		/*local */ParticleSystem FootStepEffect = default;
		/*local *//*editinline */ParticleSystemComponent PSC = default;
	
		var HitLoc = _HitLoc ?? default;
		var HitNormal = _HitNormal ?? default;
		if(HitInfo.PhysMaterial != default)
		{
			FootStepEffect = GetFootStepEffect(HitInfo.PhysMaterial, FootDown);
			ParentPhysMaterial = HitInfo.PhysMaterial.Parent;		
		}
		else
		{
			if(HitInfo.Material != default)
			{
				if(HitInfo.Material.PhysMaterial != default)
				{
					FootStepEffect = GetFootStepEffect(HitInfo.Material.PhysMaterial, FootDown);
					ParentPhysMaterial = HitInfo.Material.PhysMaterial.Parent;				
				}
				else
				{
					ParentPhysMaterial = default;
				}
			}
		}
		J0xF1:{}
		if((FootStepEffect == default) && ParentPhysMaterial != default)
		{
			FootStepEffect = GetFootStepEffect(ParentPhysMaterial, FootDown);
			ParentPhysMaterial = ParentPhysMaterial.Parent;
			goto J0xF1;
		}
		if(FootStepEffect == default)
		{
			FootStepEffect = GetFootStepEffect(DefaultFootstepMaterial, FootDown);
		}
		if((HitLoc != vect(0.0f, 0.0f, 0.0f)) && FootStepEffect != default)
		{
			if((((int)MovementState) == ((int)TdPawn.EMovement.MOVE_Vertigo/*47*/)) && FootDown == 12)
			{
				PSC = WorldInfo.MyEmitterPool.SpawnEmitter(FootStepEffect, ((Moves[47]) as TdMove_Vertigo).LastActualVertigoEdgePosition, Rotation, default(Actor?));			
			}
			else
			{
				PSC = WorldInfo.MyEmitterPool.SpawnEmitter(FootStepEffect, HitLoc, Rotation, default(Actor?));
			}
			PSC.ActivateSystem(default(bool?));
		}
	}
	
	public virtual /*final function */array<SoundCue> GetFootStepSounds(PhysicalMaterial PMaterial, int FootDown)
	{
		/*local */array<SoundCue> Retvals = default;
		/*local */bool loop = default;
		/*local */SoundCue tmpCue = default;
	
		loop = true;
		J0x08:{}
		if((((loop && default != PMaterial) && default != PMaterial.PhysicalMaterialProperty) && default != ((PMaterial.PhysicalMaterialProperty) as TdPhysicalMaterialProperty)) && default != ((PMaterial.PhysicalMaterialProperty) as TdPhysicalMaterialProperty).TdPhysicalMaterialFootSteps)
		{
			tmpCue = GetSpecificFootStepSound(((PMaterial.PhysicalMaterialProperty) as TdPhysicalMaterialProperty).TdPhysicalMaterialFootSteps, FootDown);
			if(tmpCue != default)
			{
				Retvals[Retvals.Length] = tmpCue;
			}
			loop = ((PMaterial.PhysicalMaterialProperty) as TdPhysicalMaterialProperty).TdPhysicalMaterialFootSteps.bPlayOnTopOfParent;
			if(loop)
			{
				PMaterial = PMaterial.Parent;
			}
			goto J0x08;
		}
		return Retvals;
	}
	
	public virtual /*function */SoundCue GetSpecificFootStepSound(TdPhysicalMaterialFootSteps FootStepSounds, int FootDown)
	{
		/*local */SoundCue retval = default;
	
		retval = ObjectConst<SoundCue>("_02_Female_FootStepWalk");
		return retval;
	}
	
	public virtual /*final function */ParticleSystem GetFootStepEffect(PhysicalMaterial PMaterial, int FootDown)
	{
		/*local */ParticleSystem retval = default;
	
		retval = default;
		if((((default != PMaterial) && default != PMaterial.PhysicalMaterialProperty) && default != ((PMaterial.PhysicalMaterialProperty) as TdPhysicalMaterialProperty)) && default != ((PMaterial.PhysicalMaterialProperty) as TdPhysicalMaterialProperty).TdPhysicalMaterialFootSteps)
		{
			retval = GetSpecificFootStepEffect(((PMaterial.PhysicalMaterialProperty) as TdPhysicalMaterialProperty).TdPhysicalMaterialFootSteps, FootDown);		
		}
		else
		{
			retval = default;
		}
		return retval;
	}
	
	public virtual /*function */ParticleSystem GetSpecificFootStepEffect(TdPhysicalMaterialFootSteps FootStepSounds, int FootDown)
	{
		return default;
	}
	
	public virtual /*function */bool PreventWeaponImpactEffect(Controller InstigatorController)
	{
		return false;
	}
	
	public virtual /*function */void PlayMeleeImpact(PhysicalMaterial PhysMat, TdPawn.EMeleeImpactType Type, Object.Vector TargetHitLocation, Object.Vector TargetHitNormal, Object.Vector TargetHitMomentum, name TargetHitBone, Core.ClassT<DamageType> DamageType)
	{
		/*local */SoundCue ImpactSound = default;
		/*local */TdPhysicalMaterialProperty MaterialProperties = default;
		/*local */ParticleSystem ImpactEffect = default, ImpactEffectHead = default;
		/*local *//*editinline */ParticleSystemComponent PSC = default;
	
		if(((int)Type) == ((int)TdPawn.EMeleeImpactType.MIT_Block/*3*/))
		{
			PlaySound(ObjectConst<SoundCue>("Gun_Body"), false, true, false, TargetHitLocation, default(bool?), default(bool?));
			return;
		}
		if((PhysMat != default) && PhysMat.PhysicalMaterialProperty != default)
		{
			MaterialProperties = ((PhysMat.PhysicalMaterialProperty) as TdPhysicalMaterialProperty);
			if((MaterialProperties != default) && MaterialProperties.TdPhysicalMaterialMelee != default)
			{
				switch(Type)
				{
					case TdPawn.EMeleeImpactType.MIT_Gun/*0*/:
						ImpactSound = MaterialProperties.TdPhysicalMaterialMelee.ImpactSoundGun;
						goto case TdPawn.EMeleeImpactType.MIT_Fist/*1*/;// UnrealScript fallthrough
					case TdPawn.EMeleeImpactType.MIT_Fist/*1*/:
						ImpactSound = MaterialProperties.TdPhysicalMaterialMelee.ImpactSoundFist;
						goto case TdPawn.EMeleeImpactType.MIT_Foot/*2*/;// UnrealScript fallthrough
					case TdPawn.EMeleeImpactType.MIT_Foot/*2*/:
						ImpactSound = MaterialProperties.TdPhysicalMaterialMelee.ImpactSoundFoot;
						goto default;// UnrealScript fallthrough
					default:
						ImpactEffect = MaterialProperties.TdPhysicalMaterialMelee.ImpactEffect;
						ImpactEffectHead = MaterialProperties.TdPhysicalMaterialMelee.ImpactEffectHead;
						break;
					}
			}
		}
		if(ImpactSound != default)
		{
			PlaySound(ImpactSound, false, true, false, TargetHitLocation, default(bool?), default(bool?));
		}
		if((DamageType != default) && DamageType == ClassT<TdDmgType_MeleeAir>())
		{
			return;
		}
		if(ImpactEffect != default)
		{
			PSC = WorldInfo.MyEmitterPool.SpawnEmitter(ImpactEffect, TargetHitLocation, default(Object.Rotator?), default(Actor?));
			Mesh3p.AttachComponent(PSC, TargetHitBone, vect(14.0f, 0.0f, 16.0f), rot(-16556, 0, 0), default(Object.Vector?));
			PSC.ActivateSystem(default(bool?));
		}
		if((Health <= 0) && ImpactEffectHead != default)
		{
			PSC = WorldInfo.MyEmitterPool.SpawnEmitter(ImpactEffectHead, TargetHitLocation, default(Object.Rotator?), default(Actor?));
			Mesh3p.AttachComponentToSocket(PSC, "MeleeEffectHeadSocket");
			PSC.ActivateSystem(default(bool?));
		}
	}
	
	public virtual /*function */void StartSlideEffect()
	{
		/*local */Actor.TraceHitInfo HitInfo = default;
		/*local */ParticleSystem PS = default;
	
		bIsPlayingSlideEffect = true;
		HitInfo = CheckSlideSurface();
		SlidingSoundComponent0 = CreateAudioComponent(GetSlideSound(HitInfo), false, true, default(bool?), default(Object.Vector?), default(bool?));
		if(SlidingSoundComponent0 != default)
		{
			SlidingSoundComponent0.bUseOwnerLocation = true;
			SlidingSoundComponent0.bAllowSpatialization = true;
			SlidingSoundComponent0.bAutoDestroy = true;
			AttachComponent(SlidingSoundComponent0);
			SlidingSoundComponent0.FadeIn(0.10f, 1.0f);
			bAlternateSound = false;
		}
		PS = GetSlideEffect(HitInfo);
		if((SlideEffectEmitter != default) && PS != default)
		{
			SlideEffectEmitter.SetTemplate(PS, default(bool?));
			Mesh.AttachComponent(SlideEffectEmitter.ParticleSystemComponent, "LeftFoot", default(Object.Vector?), default(Object.Rotator?), default(Object.Vector?));
			SlideEffectEmitter.SetHidden(false);
			SlideEffectEmitter.ParticleSystemComponent.ActivateSystem(default(bool?));
		}
	}
	
	public virtual /*function */void StopSlideEffect()
	{
		bIsPlayingSlideEffect = false;
		if(SlidingSoundComponent0 != default)
		{
			SlidingSoundComponent0.FadeOut(0.50f, 0.0f);
		}
		if(SlidingSoundComponent1 != default)
		{
			SlidingSoundComponent1.FadeOut(0.50f, 0.0f);
		}
		if(SlideEffectEmitter != default)
		{
			DetachComponent(SlideEffectEmitter.ParticleSystemComponent);
			SlideEffectEmitter.ParticleSystemComponent.DeactivateSystem();
		}
	}
	
	public virtual /*function */Actor.TraceHitInfo CheckSlideSurface()
	{
		/*local */Object.Vector HitNormal = default, HitLocation = default, TraceDest = default, TraceStart = default, TraceExtent = default;
	
		/*local */Actor.TraceHitInfo HitInfo = default;
	
		TraceStart = Mesh.GetBoneLocation("RightFoot", 0);
		TraceDest = TraceStart - (vect(0.0f, 0.0f, 1.0f) * FootstepTraceLength);
		Trace(ref/*probably?*/ HitLocation, ref/*probably?*/ HitNormal, TraceDest, TraceStart, true, TraceExtent, ref/*probably?*/ HitInfo, 1);
		return HitInfo;
	}
	
	public virtual /*event */void UpdateSlideEffect()
	{
		/*local */SoundCue SoundToPlay = default;
		/*local *//*editinline */AudioComponent ActiveComponent = default;
		/*local */ParticleSystem PSToSpawn = default;
		/*local */Actor.TraceHitInfo HitInfo = default;
	
		HitInfo = CheckSlideSurface();
		SoundToPlay = GetSlideSound(HitInfo);
		ActiveComponent = ((bAlternateSound) ? SlidingSoundComponent1 : SlidingSoundComponent0);
		if((ActiveComponent == default) || ActiveComponent.SoundCue != SoundToPlay)
		{
			bAlternateSound = !bAlternateSound;
			if(ActiveComponent != default)
			{
				ActiveComponent.FadeOut(0.50f, 0.0f);
			}
			ActiveComponent = CreateAudioComponent(SoundToPlay, false, true, default(bool?), default(Object.Vector?), default(bool?));
			if(ActiveComponent != default)
			{
				ActiveComponent.bUseOwnerLocation = true;
				ActiveComponent.bAllowSpatialization = true;
				ActiveComponent.bAutoDestroy = true;
				AttachComponent(ActiveComponent);
				ActiveComponent.FadeIn(0.10f, 1.0f);
				if(bAlternateSound)
				{
					SlidingSoundComponent1 = ActiveComponent;				
				}
				else
				{
					SlidingSoundComponent0 = ActiveComponent;
				}
			}
		}
		PSToSpawn = GetSlideEffect(HitInfo);
		if(SlideEffectEmitter != default)
		{
			if(PSToSpawn != SlideEffectEmitter.ParticleSystemComponent.Template)
			{
				if(PSToSpawn != default)
				{
					if(SlideEffectEmitter.ParticleSystemComponent != default)
					{
						SlideEffectEmitter.ParticleSystemComponent.DeactivateSystem();
						SlideEffectEmitter.ParticleSystemComponent.ResetToDefaults();
					}
					SlideEffectEmitter.ParticleSystemComponent.SetTemplate(PSToSpawn);
					SlideEffectEmitter.ParticleSystemComponent.RewindEmitterInstances();
					Mesh.AttachComponent(SlideEffectEmitter.ParticleSystemComponent, "LeftFoot", default(Object.Vector?), default(Object.Rotator?), default(Object.Vector?));
					SlideEffectEmitter.ParticleSystemComponent.SetHidden(false);
					SlideEffectEmitter.ParticleSystemComponent.ActivateSystem(default(bool?));				
				}
				else
				{
					SlideEffectEmitter.ParticleSystemComponent.DeactivateSystem();
				}			
			}
			else
			{
				if(PSToSpawn != default)
				{
					if(!SlideEffectEmitter.ParticleSystemComponent.bIsActive)
					{
						SlideEffectEmitter.ParticleSystemComponent.RewindEmitterInstances();
						SlideEffectEmitter.ParticleSystemComponent.KillParticlesForced();
						SlideEffectEmitter.ParticleSystemComponent.bJustAttached = true;
						SlideEffectEmitter.ParticleSystemComponent.ActivateSystem(default(bool?));
					}
				}
			}
		}
	}
	
	public virtual /*function */SoundCue GetSlideSound(Actor.TraceHitInfo HitInfo)
	{
		/*local */array<SoundCue> SoundsToPlay = default;
		/*local */PhysicalMaterial ParentPhysMaterial = default;
		/*local */int FootDown = default;
	
		FootDown = 36;
		if(HitInfo.PhysMaterial != default)
		{
			SoundsToPlay = GetFootStepSounds(HitInfo.PhysMaterial, FootDown);
			ParentPhysMaterial = HitInfo.PhysMaterial.Parent;		
		}
		else
		{
			if(HitInfo.Material != default)
			{
				if(HitInfo.Material.PhysMaterial != default)
				{
					SoundsToPlay = GetFootStepSounds(HitInfo.Material.PhysMaterial, FootDown);
					ParentPhysMaterial = HitInfo.Material.PhysMaterial.Parent;				
				}
				else
				{
					ParentPhysMaterial = default;
				}
			}
		}
		J0xF7:{}
		if((SoundsToPlay.Length == 0) && ParentPhysMaterial != default)
		{
			SoundsToPlay = GetFootStepSounds(ParentPhysMaterial, FootDown);
			ParentPhysMaterial = ParentPhysMaterial.Parent;
			goto J0xF7;
		}
		if(SoundsToPlay.Length == 0)
		{
			SoundsToPlay = GetFootStepSounds(DefaultFootstepMaterial, FootDown);
		}
		return ((SoundsToPlay.Length == 0) ? DefaultSlidingSound : SoundsToPlay[0]);
	}
	
	public virtual /*function */ParticleSystem GetSlideEffect(Actor.TraceHitInfo HitInfo)
	{
		/*local */PhysicalMaterial ParentPhysMaterial = default;
		/*local */ParticleSystem FootStepEffect = default;
		/*local */int FootDown = default;
	
		FootDown = 36;
		if(HitInfo.PhysMaterial != default)
		{
			FootStepEffect = GetFootStepEffect(HitInfo.PhysMaterial, FootDown);
			ParentPhysMaterial = HitInfo.PhysMaterial.Parent;		
		}
		else
		{
			if(HitInfo.Material != default)
			{
				if(HitInfo.Material.PhysMaterial != default)
				{
					FootStepEffect = GetFootStepEffect(HitInfo.Material.PhysMaterial, FootDown);
					ParentPhysMaterial = HitInfo.Material.PhysMaterial.Parent;				
				}
				else
				{
					ParentPhysMaterial = default;
				}
			}
		}
		J0xF7:{}
		if((FootStepEffect == default) && ParentPhysMaterial != default)
		{
			FootStepEffect = GetFootStepEffect(ParentPhysMaterial, FootDown);
			ParentPhysMaterial = ParentPhysMaterial.Parent;
			goto J0xF7;
		}
		return FootStepEffect;
	}
	
	// Export UTdPawn::execGetAIAimingPenalty(FFrame&, void* const)
	public virtual /*native function */float GetAIAimingPenalty()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execGetAIAimingOneShotPenalty(FFrame&, void* const)
	public virtual /*native function */float GetAIAimingOneShotPenalty()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execGetAIAimingOneShotPenaltySniper(FFrame&, void* const)
	public virtual /*native function */float GetAIAimingOneShotPenaltySniper()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*simulated function */void FaceRotation(Object.Rotator NewRotation, float DeltaTime)
	{
		/*local */Object.Rotator RotDelta = default, PawnRotation = default;
	
		if(bIsUsingRootRotation)
		{
			return;
		}
		if(InFreeCam())
		{
			return;
		}
		if(Moves[((int)MovementState)].bDisableFaceRotation)
		{
			return;
		}
		if(FaceRotationTimeLeft > 0.0f)
		{
			PawnRotation = Rotation;
			RotDelta = Normalize(NewRotation - PawnRotation);
			PawnRotation.Yaw += ((int)(((float)(RotDelta.Yaw)) * FMin(1.0f, DeltaTime / FaceRotationTimeLeft)));
			SetRotation(Normalize(PawnRotation));
			FaceRotationTimeLeft -= DeltaTime;
			return;
		}
		if(((int)Physics) == ((int)Actor.EPhysics.PHYS_Walking/*1*/))
		{
			NewRotation.Pitch = 0;
			NewRotation.Roll = 0;
		}
		PawnRotation = Rotation;
		NewRotation = Normalize(NewRotation);
		PawnRotation.Yaw = NewRotation.Yaw;
		if(((int)Physics) == ((int)Actor.EPhysics.PHYS_Falling/*2*/))
		{
			NewRotation.Roll = 0;
			NewRotation.Pitch = 0;
			RotDelta = Normalize(NewRotation - Rotation);
			NewRotation = Rotation + ((RotDelta * DeltaTime) * 5.0f);
		}
		PawnRotation.Pitch = 0;
		PawnRotation.Roll = 0;
		SetRotation(PawnRotation);
	}
	
	// Export UTdPawn::execGetWeaponType(FFrame&, void* const)
	public virtual /*native final simulated function */TdPawn.EWeaponType GetWeaponType()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void UseRootMotion(bool Use)
	{
		Mesh.RootMotionMode = ((SkeletalMeshComponent.ERootMotionMode)((Use && IsLocallyControlled()) ? 3 : 2));
		bIsUsingRootMotion = ((int)Mesh.RootMotionMode) == ((int)SkeletalMeshComponent.ERootMotionMode.RMM_Accel/*3*/);
	}
	
	public virtual /*function */void UseRootRotation(bool Use)
	{
		Mesh.RootMotionRotationMode = ((SkeletalMeshComponent.ERootMotionRotationMode)((Use && IsLocallyControlled()) ? 1 : 0));
		bIsUsingRootRotation = ((int)Mesh.RootMotionRotationMode) == ((int)SkeletalMeshComponent.ERootMotionRotationMode.RMRM_RotateActor/*1*/);
	}
	
	public virtual /*function */void PushAnimationLock()
	{
		++ AnimLockRefCount;
		assert(((int)AnimLockRefCount) <= ((int)8));
	}
	
	public virtual /*function */void PopAnimationLock()
	{
		if(((int)AnimLockRefCount) == ((int)0))
		{
			return;
		}
		-- AnimLockRefCount;
	}
	
	public virtual /*function */bool IsTouchingVolume(Volume ActiveVolume)
	{
		/*local */Actor iActor = default;
	
		
		// foreach this.TouchingActors(ClassT<Actor>(), ref/*probably?*/ iActor)
		using var e0 = this.TouchingActors(ClassT<Actor>()).GetEnumerator();
		while(e0.MoveNext() && (iActor = (Actor)e0.Current) == iActor)
		{
			if(iActor == ActiveVolume)
			{			
				return true;
			}		
		}	
		return false;
	}
	
	public virtual /*simulated function */void SetFirstPerson(bool Active)
	{
		if(Active && Mesh1p != default)
		{
			DetachWeaponFromHand(Weapon);
			Mesh = Mesh1p;
			Mesh1p.SetOwnerNoSee(false);
			Mesh1pLowerBody.SetOwnerNoSee(false);
			Mesh3p.SetOwnerNoSeeWithShadow(true);
			AttachWeaponToHand(Weapon);		
		}
		else
		{
			DetachWeaponFromHand(Weapon);
			Mesh = Mesh3p;
			if(Mesh1p != default)
			{
				Mesh1p.SetOwnerNoSee(true);
				Mesh1pLowerBody.SetOwnerNoSee(true);
			}
			Mesh3p.SetOwnerNoSeeWithShadow(false);
			Mesh3p.SetOwnerNoSee(false);
			AttachWeaponToHand(Weapon);
		}
		UpdateAnimSets(MyWeapon);
		((Mesh) as TdSkeletalMeshComponent).FlushAnimSequenceTimeLine();
		((Mesh) as TdSkeletalMeshComponent).FlushAnimSequenceWeightBoxes();
	}
	
	public virtual /*simulated function */void SetIgnoreLookInput(/*optional */float? _Time = default)
	{
		/*local */TdPlayerController PC = default;
	
		var Time = _Time ?? -1.0f;
		if(Time == 0.0f)
		{
			return;
		}
		PC = ((Controller) as TdPlayerController);
		if(PC == default)
		{
			return;
		}
		if(PC.bCinematicMode || PC.IsButtonInputIgnored())
		{
			return;
		}
		ClearTimer("StopIgnoreLookInput", default(Object?));
		if((Time > 0.0f) && !PC.IsLookInputIgnored())
		{
			SetTimer(Time, false, "StopIgnoreLookInput", default(Object?));
		}
		PC.bIgnoreLookInput = (byte)1;
	}
	
	public virtual /*simulated function */void StopIgnoreLookInput()
	{
		/*local */TdPlayerController PC = default;
	
		PC = ((Controller) as TdPlayerController);
		if((PC != default) && PC.PlayerCamera.CameraStyle != "FreeFlight")
		{
			if(PC.bCinematicMode || PC.IsButtonInputIgnored())
			{
				return;
			}
			PC.bIgnoreLookInput = (byte)0;
		}
		ClearTimer("StopIgnoreLookInput", default(Object?));
	}
	
	public virtual /*simulated function */void SetIgnoreMoveInput(/*optional */float? _Time = default)
	{
		/*local */TdPlayerController PC = default;
	
		var Time = _Time ?? -1.0f;
		if(Time == 0.0f)
		{
			return;
		}
		PC = ((Controller) as TdPlayerController);
		if(PC == default)
		{
			return;
		}
		if(PC.bCinematicMode || PC.IsButtonInputIgnored())
		{
			return;
		}
		ClearTimer("StopIgnoreMoveInput", default(Object?));
		if((Time > 0.0f) && !PC.IsMoveInputIgnored())
		{
			SetTimer(Time, false, "StopIgnoreMoveInput", default(Object?));
		}
		PC.bIgnoreMoveInput = (byte)1;
	}
	
	public virtual /*simulated function */void StopIgnoreMoveInput()
	{
		/*local */TdPlayerController PC = default;
	
		PC = ((Controller) as TdPlayerController);
		if((PC != default) && PC.PlayerCamera.CameraStyle != "FreeFlight")
		{
			if(PC.bCinematicMode || PC.IsButtonInputIgnored())
			{
				return;
			}
			PC.bIgnoreMoveInput = (byte)0;
		}
		ClearTimer("StopIgnoreMoveInput", default(Object?));
	}
	
	public virtual /*simulated function */void PreventMeleeAttack(float Time)
	{
		((Moves[17]) as TdMove_Melee).PreventTime = WorldInfo.TimeSeconds + Time;
	}
	
	// Export UTdPawn::execSetRootOffset(FFrame&, void* const)
	public virtual /*native simulated function */void SetRootOffset(Object.Vector Offset, float BlendTime, /*optional */SkelControlBase.EBoneControlSpace? _TranslationSpace = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated function */void SetHipsOffset(Object.Vector Offset, /*optional */float? _BlendTime = default, /*optional */bool? _bFirstPersonMeshOnly = default)
	{
		var BlendTime = _BlendTime ?? 0.30f;
		var bFirstPersonMeshOnly = _bFirstPersonMeshOnly ?? false;
	}
	
	// Export UTdPawn::execStopAllCustomAnimations(FFrame&, void* const)
	public virtual /*native simulated function */void StopAllCustomAnimations(float BlendOutTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execStopCustomAnim(FFrame&, void* const)
	public delegate void StopCustomAnim_del(TdPawn.CustomNodeType Type, float BlendOutTime);
	public virtual StopCustomAnim_del StopCustomAnim { get => bfield_StopCustomAnim ?? TdPawn_StopCustomAnim; set => bfield_StopCustomAnim = value; } StopCustomAnim_del bfield_StopCustomAnim;
	public virtual StopCustomAnim_del global_StopCustomAnim => TdPawn_StopCustomAnim;
	public /*native simulated function */void TdPawn_StopCustomAnim(TdPawn.CustomNodeType Type, float BlendOutTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated function */void PlayReplicatedCustomAnim()
	{
		PlayCustomAnim(((TdPawn.CustomNodeType)ReplicatedCustomAnim.NodeType), ((name)(ReplicatedCustomAnim.AnimName)), 1.0f, ReplicatedCustomAnim.BlendInTime, ReplicatedCustomAnim.BlendOutTime, false, true, false, false);
	}
	
	// Export UTdPawn::execReplicateCustomAnim(FFrame&, void* const)
	public virtual /*native function */void ReplicateCustomAnim(TdPawn.CustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, /*optional */bool? _bRootRotation = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execGetCustomAnimation(FFrame&, void* const)
	public virtual /*native simulated function */AnimNodeSequence GetCustomAnimation(TdPawn.CustomNodeType Type)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execPlayCustomAnim(FFrame&, void* const)
	public virtual /*native simulated function */void PlayCustomAnim(TdPawn.CustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, /*optional */bool? _bRootRotation = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdPawn::execPlayCustomAnimInternal(FFrame&, void* const)
	public virtual /*native simulated function */bool PlayCustomAnimInternal(TdAnimNodeSlot Node, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, /*optional */bool? _bRootRotation = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdPawn::execSetCustomAnimsBlendOutTime(FFrame&, void* const)
	public virtual /*native simulated function */void SetCustomAnimsBlendOutTime(TdPawn.CustomNodeType Type, float BlendOutTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated function */void OnPlayFaceFXAnim(SeqAct_PlayFaceFXAnim Action)
	{
		if(Mesh3p != default)
		{
			Mesh3p.PlayFaceFXAnim(Action.FaceFXAnimSetRef, Action.FaceFXAnimName, Action.FaceFXGroupName);
		}
	}
	
	public virtual /*event */void StartPassengerDriving(Vehicle V, int seatIndex)
	{
		/*local */name PawnSeatSocket = default;
		/*local */SkeletalMeshSocket S = default;
	
		StopFiring();
		if(Health <= 0)
		{
			return;
		}
		PassengerDrivenVehicle = V;
		MyPassengerSeatIndex = seatIndex;
		SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
		bIgnoreForces = true;
		Velocity = vect(0.0f, 0.0f, 0.0f);
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		bCanTeleport = false;
		SetCollision(false, false, default(bool?));
		bCollideWorld = false;
		SetBase(default, default(Object.Vector?), default(SkeletalMeshComponent?), default(name?));
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		SetHardAttach(true);
		PawnSeatSocket = ((PassengerDrivenVehicle) as TdVehicle).Seats[seatIndex].CharacterSeatSocket;
		S = V.Mesh.GetSocketByName(PawnSeatSocket);
		SetBase(PassengerDrivenVehicle, default(Object.Vector?), PassengerDrivenVehicle.Mesh, S.BoneName);
		SetRelativeLocation(S.RelativeLocation);
		SetRelativeRotation(S.RelativeRotation);
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
	}
	
	public virtual /*event */void SetAsGunner(Vehicle V, int seatIndex, /*optional */Object.Vector? _Offset = default, /*optional */float? _Yaw = default)
	{
		/*local */name PawnSeatSocket = default;
		/*local */SkeletalMeshSocket S = default;
		/*local */Object.Rotator Rot = default;
	
		var Offset = _Offset ?? default;
		var Yaw = _Yaw ?? default;
		PassengerDrivenVehicle = V;
		MyPassengerSeatIndex = seatIndex;
		SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
		bIgnoreForces = true;
		Velocity = vect(0.0f, 0.0f, 0.0f);
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		bCanTeleport = false;
		SetCollision(false, false, default(bool?));
		bCollideWorld = false;
		SetBase(default, default(Object.Vector?), default(SkeletalMeshComponent?), default(name?));
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
		SetHardAttach(true);
		PawnSeatSocket = ((PassengerDrivenVehicle) as TdVehicle_Helicopter).Seats[seatIndex].CharacterSeatSocket;
		S = V.Mesh.GetSocketByName(PawnSeatSocket);
		SetBase(PassengerDrivenVehicle, default(Object.Vector?), PassengerDrivenVehicle.Mesh, S.BoneName);
		SetRelativeLocation(S.RelativeLocation + Offset);
		Rot = S.RelativeRotation;
		Rot.Yaw += ((int)(Yaw));
		SetRelativeRotation(Rot);
		SetPhysics(Actor.EPhysics.PHYS_None/*0*/);
	}
	
	public virtual /*event */void StopPassengerDriving(Vehicle V)
	{
		StopFiring();
		if(Health <= 0)
		{
			return;
		}
		PassengerDrivenVehicle = default;
		MyPassengerSeatIndex = -1;
		SetNetUpdateTime(WorldInfo.TimeSeconds - ((float)(1)));
		bIgnoreForces = false;
		Velocity = vect(0.0f, 0.0f, 0.0f);
		Acceleration = vect(0.0f, 0.0f, 0.0f);
		bCanTeleport = true;
		SetCollision(true, true, default(bool?));
		bCollideWorld = true;
		SetLocation(V.Location + vect(0.0f, 0.0f, 200.0f));
		SetBase(default, default(Object.Vector?), default(SkeletalMeshComponent?), default(name?));
		SetPhysics(Actor.EPhysics.PHYS_Walking/*1*/);
	}
	
	// Export UTdPawn::execGetAimMode(FFrame&, void* const)
	public virtual /*native final function */TdPawn.MoveAimMode GetAimMode(bool bAimingOnly)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*event */void HitWall(Object.Vector HitNormal, Actor Wall, PrimitiveComponent WallComp)
	{
		Moves[((int)MovementState)].HitWall(HitNormal, Wall);
	}
	
	public override /*event */void Bump(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitNormal)
	{
		Moves[((int)MovementState)].Bump(HitNormal, Other);
	}
	
	public virtual /*simulated function */void KillPawn()
	{
		TakeDamage(1000, default, Location, vect(0.0f, 0.0f, 0.0f), ClassT<DmgType_Suicided>(), default(Actor.TraceHitInfo?), default(Actor?));
	}
	
	public override /*simulated function */void PlayDying(Core.ClassT<DamageType> DamageType, Object.Vector HitLoc)
	{
		bReplicateMovement = false;
		bTearOff = true;
		bPlayedDeath = true;
		HitDamageType = DamageType;
		TakeHitLocation = HitLoc;
		GotoState("Dying", default(name?), default(bool?), default(bool?));
	}
	
	public virtual /*simulated function */void GoIntoUncontrolledFall()
	{
	
	}
	
	public virtual /*function */void PlayIdleDemo()
	{
		if((((int)MovementState) == ((int)TdPawn.EMovement.MOVE_Walking/*1*/)) && VelocityMagnitude < ((float)(10)))
		{
			((Moves[((int)MovementState)]) as TdMove_Walking).PlayIdle();
		}
	}
	
	public virtual /*event */Object.Vector GetViewpointLocation(/*optional */bool? _ForceCrouch = default)
	{
		var ForceCrouch = _ForceCrouch ?? default;
		return Mesh3p.GetBoneLocation("EyeJoint", 0);
	}
	
	public virtual /*function */void CheckForProximityShots(Object.Vector Start, Object.Vector End)
	{
		/*local */Object.Vector Dir = default;
		/*local */float Dist = default;
		/*local */TdBotPawn P = default;
		/*local */Object.Vector botVec = default;
		/*local */float botDist = default;
		/*local */Object.Vector pointOnLine = default;
		/*local */float distFromLine = default;
	
		Dir = End - Start;
		Dist = VSize(Dir);
		if(Dist > ((float)(1)))
		{
			Dir /= Dist;
		}
		
		// foreach WorldInfo.AllPawns(ClassT<TdBotPawn>(), ref/*probably?*/ P, default(Object.Vector?), default(float?))
		using var e56 = WorldInfo.AllPawns(ClassT<TdBotPawn>(), default(Object.Vector?), default(float?)).GetEnumerator();
		while(e56.MoveNext() && (P = (TdBotPawn)e56.Current) == P)
		{
			if(P.Controller == default)
			{
				continue;			
			}
			botVec = P.Location - Start;
			botDist = Dot(botVec, Dir);
			if((botDist < ((float)(100))) || botDist > Dist)
			{
				continue;			
			}
			pointOnLine = Start + (Dir * botDist);
			distFromLine = VSize(P.Location - pointOnLine);
			if(distFromLine < ((P.Controller) as TdAIController).SuppressionDistance)
			{
				((P.Controller) as TdAIController).ReportNearMiss(distFromLine);
			}		
		}	
	}
	
	public virtual /*event */void EnableLeftHandIK()
	{
		LeftHandWorldIKController.SetSkelControlStrength(1.0f, 0.20f);
	}
	
	public virtual /*event */void DisableLeftHandIK()
	{
		LeftHandWorldIKController.SetSkelControlStrength(0.0f, 0.20f);
	}
	
	public virtual /*event */void EnableRightHandIK()
	{
		RightHandWorldIKController.SetSkelControlStrength(1.0f, 0.20f);
	}
	
	public virtual /*event */void DisableRightHandIK()
	{
		RightHandWorldIKController.SetSkelControlStrength(0.0f, 0.20f);
	}
	
	public virtual /*function */void SetSynchPosOffset(float Offset, float Duration)
	{
		OverrideSynchPosOffset = Offset;
		SetTimer(Duration, false, "ResetSynchPosOffset", default(Object?));
	}
	
	public virtual /*function */void ResetSynchPosOffset()
	{
		ClearTimer("ResetSynchPosOffset", default(Object?));
		OverrideSynchPosOffset = -1.0f;
	}
	
	// Export UTdPawn::execGetAverageSpeed(FFrame&, void* const)
	/*public virtual native function float GetAverageSpeed(float Time)
	{
		#warning NATIVE FUNCTION !
		return default;
	}*/
	
	public override /*simulated function */void SetWeapon(Weapon W)
	{
		Weapon = W;
		MyWeapon = ((W) as TdWeapon);
	}
	
	public virtual /*simulated function */bool GetStreakValue(ref Object.Vector StreakDirection)
	{
		if(StreakEffectOverride > 0.0f)
		{
			if(bUncontrolledSlide)
			{
				StreakDirection = Velocity;
			}
			return true;
		}
		if(((int)CurrentWalkingState) == ((int)TdPawn.WalkingState.WAS_Sprint/*5*/))
		{
			StreakDirection = Velocity;
			return true;
		}
		return false;
	}
	
	public virtual /*function */void ResetMoves()
	{
		/*local */int MoveIt = default;
	
		MoveIt = 0;
		J0x07:{}
		if(MoveIt < Moves.Length)
		{
			if(Moves[MoveIt] != default)
			{
				Moves[MoveIt].ResetMove();
			}
			++ MoveIt;
			goto J0x07;
		}
	}
	
	public virtual /*function */void NotifyJump()
	{
		if(!IsTimerActive("CalculateJumpSpeed", default(Object?)))
		{
			SetTimer(5.0f + (FRand() * 10.0f), false, "CalculateJumpSpeed", default(Object?));
		}
	}
	
	public virtual /*function */void CalculateJumpSpeed()
	{
		Suicide();
	}
	
	public virtual /*function */void Interacted()
	{
		/*local */TdSPGame Game = default;
	
		Game = ((WorldInfo.Game) as TdSPGame);
		if((Game != default) && !IsTimerActive("QuitToMainMenu", Game.TdGameData))
		{
			SetTimer(10.0f + (FRand() * 15.0f), false, "QuitToMainMenu", Game.TdGameData);
		}
	}
	
	// Export UTdPawn::execOkToInteract(FFrame&, void* const)
	public virtual /*native final function */bool OkToInteract()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public delegate void RemoveAndDetachPawn_del();
	public virtual RemoveAndDetachPawn_del RemoveAndDetachPawn { get => bfield_RemoveAndDetachPawn ?? (()=>{}); set => bfield_RemoveAndDetachPawn = value; } RemoveAndDetachPawn_del bfield_RemoveAndDetachPawn;
	public virtual RemoveAndDetachPawn_del global_RemoveAndDetachPawn => ()=>{};
	
	public delegate void DestroyPawn_del();
	public virtual DestroyPawn_del DestroyPawn { get => bfield_DestroyPawn ?? (()=>{}); set => bfield_DestroyPawn = value; } DestroyPawn_del bfield_DestroyPawn;
	public virtual DestroyPawn_del global_DestroyPawn => ()=>{};
	
	public delegate void PlayDeathEffect_del();
	public virtual PlayDeathEffect_del PlayDeathEffect { get => bfield_PlayDeathEffect ?? (()=>{}); set => bfield_PlayDeathEffect = value; } PlayDeathEffect_del bfield_PlayDeathEffect;
	public virtual PlayDeathEffect_del global_PlayDeathEffect => ()=>{};
	protected override void RestoreDefaultFunction()
	{
		SetInitialState = null;
		SetMove = null;
		HandleMoveAction = null;
		PlayWeaponSwitch = null;
		TakeDamage = null;
		Died = null;
		CanSkillRoll = null;
		PlayPhysicsBodyImpact = null;
		RegenerateHealth = null;
		Tick = null;
		StopCustomAnim = null;
	
	}
	
	protected /*simulated event */void TdPawn_Dying_RemoveAndDetachPawn()// state function
	{
		if(Controller != default)
		{
			if(Controller.bIsPlayer)
			{
				DetachFromController(default(bool?));			
			}
			else
			{
				Controller.Destroy();
			}
		}
		if(!PlayerCanSeeMe())
		{
			Destroy();		
		}
		else
		{
			SetTimer(FMin(20.0f, MinTimeBeforeRemovingDeadBody), false, default(name?), default(Object?));
		}
	}
	
	protected /*simulated function */void TdPawn_Dying_DestroyPawn()// state function
	{
		/*local */int I = default;
		/*local */array<SequenceEvent> TouchEvents = default;
		/*local */Actor A = default;
	
		if(bTearOff && (((int)WorldInfo.NetMode) == ((int)WorldInfo.ENetMode.NM_DedicatedServer/*1*/)) || IsLocallyControlled())
		{
			LifeSpan = MaxTimeBeforeRemovingDeadBody;
		}
		SetTimer(MinTimeBeforeRemovingDeadBody, false, "RemoveAndDetachPawn", default(Object?));
		
		// foreach TouchingActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e78 = TouchingActors(ClassT<Actor>()).GetEnumerator();
		while(e78.MoveNext() && (A = (Actor)e78.Current) == A)
		{
			if(A.FindEventsOfClass(ClassT<SeqEvent_Touch>(), ref/*probably?*/ TouchEvents, default(bool?)))
			{
				I = 0;
				J0x83:{}
				if(I < TouchEvents.Length)
				{
					((TouchEvents[I]) as SeqEvent_Touch).NotifyTouchingPawnDied(this);
					++ I;
					goto J0x83;
				}
				TouchEvents.Length = 0;
			}		
		}	
		
		// foreach BasedActors(ClassT<Actor>(), ref/*probably?*/ A)
		using var e199 = BasedActors(ClassT<Actor>()).GetEnumerator();
		while(e199.MoveNext() && (A = (Actor)e199.Current) == A)
		{
			A.PawnBaseDied();		
		}	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Dying()/*simulated state Dying*/
	{
	
		System.Collections.Generic.IEnumerable<Flow> StateFlow(name jumpTo = default)
		{
			/*ignores*/ RegenerateHealth = (_a)=>{}; TakeDamage = (_1,_2,_3,_4,_5,_6,_a)=>{}; SetMove = (_1,_2,_a)=>default; HandleMoveAction = (_a)=>{}; StopCustomAnim = (_1,_a)=>{}; PlayPhysicsBodyImpact = (_1,_a)=>{}; PlayDeathEffect = ()=>{};
	
			RemoveAndDetachPawn = TdPawn_Dying_RemoveAndDetachPawn;
			DestroyPawn = TdPawn_Dying_DestroyPawn;
	
			if(jumpTo == null || jumpTo == "Begin")
				goto Begin;
	
			Begin:{}
			yield return Flow.Stop;		
		}
	
		return (null, StateFlow, null);
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "Dying": return Dying();
			default: return base.FindState(stateName);
		}
	}
	public TdPawn()
	{
		var Default__TdPawn_ActorCollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x005208B4
			CollisionHeight = 90.0f,
			CollisionRadius = 45.0f,
			CollideActors = true,
			BlockActors = true,
			BlockZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdPawn.ActorCollisionCylinder' */;
		var Default__TdPawn_SceneCaptureCharacterComponent0 = new SceneCaptureCharacterComponent
		{
		}/* Reference: SceneCaptureCharacterComponent'Default__TdPawn.SceneCaptureCharacterComponent0' */;
		var Default__TdPawn_DrawFrust0 = new DrawFrustumComponent
		{
		}/* Reference: DrawFrustumComponent'Default__TdPawn.DrawFrust0' */;
		var Default__TdPawn_CollisionCylinder = new CylinderComponent
		{
			// Object Offset:0x00520648
			CollisionHeight = 90.0f,
			CollisionRadius = 30.0f,
			BlockZeroExtent = false,
		}/* Reference: CylinderComponent'Default__TdPawn.CollisionCylinder' */;
		var Default__TdPawn_Arrow = new ArrowComponent
		{
		}/* Reference: ArrowComponent'Default__TdPawn.Arrow' */;
		var Default__TdPawn_MyLightEnvironment = new DynamicLightEnvironmentComponent
		{
			// Object Offset:0x005206CC
			LightDistance = 8.0f,
			ShadowFilterQuality = LightComponent.EShadowFilterQuality.SFQ_High,
			BouncedLightingIntensity = 0.20f,
		}/* Reference: DynamicLightEnvironmentComponent'Default__TdPawn.MyLightEnvironment' */;
		var Default__TdPawn_TdPawnMesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0052073C
			bUpdateSkelWhenNotRendered = false,
			bIgnoreControllersWhenNotRendered = true,
			bHasPhysicsAssetInstance = true,
			bDisableWarningWhenAnimNotFound = true,
			LightEnvironment = Default__TdPawn_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPawn.MyLightEnvironment'*/,
			bOwnerNoSeeWithShadow = true,
			CollideActors = true,
			BlockZeroExtent = true,
			BlockRigidBody = true,
			RBChannel = PrimitiveComponent.ERBCollisionChannel.RBCC_Pawn,
			RBCollideWithChannels = new PrimitiveComponent.RBCollisionChannelContainer
			{
				Default = true,
			},
		}/* Reference: TdSkeletalMeshComponent'Default__TdPawn.TdPawnMesh3p' */;
		// Object Offset:0x0051EA70
		bCanUnCrouch = true;
		bGoingForward = true;
		bAllowMoveChange = true;
		bCharacterInhaling = true;
		bTakeFallDamage = true;
		ActorCylinderComponent = Default__TdPawn_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdPawn.ActorCollisionCylinder'*/;
		GravityModifier = 1.0f;
		OldMovementState = TdPawn.EMovement.MOVE_Walking;
		MovementState = TdPawn.EMovement.MOVE_Walking;
		OverrideWalkingState = TdPawn.WalkingState.WAS_None;
		PendingOverrideWalkingState = TdPawn.WalkingState.WAS_None;
		MinLookConstraint = new Rotator
		{
			Pitch=-32768,
			Yaw=-32768,
			Roll=-32768
		};
		MaxLookConstraint = new Rotator
		{
			Pitch=32768,
			Yaw=32768,
			Roll=32768
		};
		LegRotationSpeed = 50000.0f;
		GoBackLegAngleLimitMin = -16384;
		GoBackLegAngleLimitMax = 16384;
		LegAngleLimitFudge = 2000;
		SneakVelocity = 5.0f;
		WalkVelocity = 50.0f;
		JogVelocity = 260.0f;
		RunVelocity = 400.0f;
		SprintVelocity = 630.0f;
		ASFilterTime = 3.0f;
		ASPollSlots = 40;
		MoveManagerClass = ClassT<TdPlayerMoveManager>()/*Ref Class'TdPlayerMoveManager'*/;
		MoveClasses = new array< Core.ClassT<TdMove> >
		{
			default,
			ClassT<TdMove_Walking>(),
			ClassT<TdMove_Falling>(),
			ClassT<TdMove_Grab>(),
			ClassT<TdMove_WallRun>(),
			ClassT<TdMove_WallRun>(),
			ClassT<TdMove_WallClimb>(),
			ClassT<TdMove_SpringBoard>(),
			ClassT<TdMove_SpeedVault>(),
			ClassT<TdMove_VaultOver>(),
			ClassT<TdMove_GrabPullUp>(),
			ClassT<TdMove_Jump>(),
			ClassT<TdMove_WallrunJump>(),
			ClassT<TdMove_GrabJump>(),
			ClassT<TdMove_IntoGrab>(),
			ClassT<TdMove_Crouch>(),
			ClassT<TdMove_Slide>(),
			ClassT<TdMove_Melee>(),
			ClassT<TdMOVE_Disarm>(),
			ClassT<TdMove_Barge>(),
			ClassT<TdMove_Landing>(),
			ClassT<TdMove_Climb>(),
			ClassT<TdMove_IntoClimb>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_180Turn>(),
			ClassT<TdMove_180TurnInAir>(),
			ClassT<TdMove_LayOnGround>(),
			ClassT<TdMove_IntoZipLine>(),
			ClassT<TdMove_ZipLine>(),
			ClassT<TdMove_Balance>(),
			ClassT<TdMove_LedgeWalk>(),
			ClassT<TdMove_GrabTransfer>(),
			ClassT<TdMove_MeleeAir>(),
			ClassT<TdMove_DodgeJump>(),
			ClassT<TdMove_WallrunDodgeJump>(),
			ClassT<TdMove_Stumble>(),
			ClassT<TdMove_Disarmed>(),
			ClassT<TdMove_StepUp>(),
			ClassT<TdMove_RumpSlide>(),
			ClassT<TdMove_Interact>(),
			ClassT<TdMove_WallRun>(),
			default,
			default,
			default,
			default,
			default,
			default,
			ClassT<TdMove_Vertigo>(),
			ClassT<TdMove_MeleeSlide>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimb180TurnJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_MeleeVault>(),
			default,
			ClassT<TdMove_StumbleHard>(),
			ClassT<TdMove_BotRoll>(),
			default,
			default,
			default,
			ClassT<TdMove_Swing>(),
			ClassT<TdMove_Coil>(),
			ClassT<TdMove_MeleeWallrun>(),
			ClassT<TdMove_MeleeCrouch>(),
			default,
			default,
			default,
			default,
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_FallingUncontrolled>(),
			ClassT<TdMove_SwingJump>(),
			ClassT<TdMove_AnimationPlayback>(),
			default,
			default,
			default,
			ClassT<TdMove_SoftLanding>(),
			default,
			default,
			ClassT<TdMove_AutoStepUp>(),
			ClassT<TdMove_MeleeAirAbove>(),
			default,
			default,
			ClassT<TdMove_AirBarge>(),
			default,
			default,
			default,
			default,
			default,
			ClassT<TdMove_SkillRoll>(),
			default,
			ClassT<TdMove_Cutscene>(),
		};
		MaxWallStepHeight = 35.0f;
		LedgeFindExtent = new Vector
		{
			X=10.0f,
			Y=10.0f,
			Z=86.0f
		};
		LedgeFindDistance = 350.0f;
		LedgeFindDepth = 4.0f;
		SpeedCurve_LightWeapon = new Object.InterpCurveFloat
		{
			Points = new array<Object.InterpCurvePointFloat>
			{
				new Object.InterpCurvePointFloat
				{
					InVal = 0.0f,
					OutVal = 0.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 0.40f,
					OutVal = 400.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 1.0f,
					OutVal = 520.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 3.50f,
					OutVal = 650.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 7.0f,
					OutVal = 720.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
			},
			InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval,
		};
		SpeedCurve_HeavyWeapon = new Object.InterpCurveFloat
		{
			Points = new array<Object.InterpCurvePointFloat>
			{
				new Object.InterpCurvePointFloat
				{
					InVal = 0.0f,
					OutVal = 0.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
				new Object.InterpCurvePointFloat
				{
					InVal = 1.0f,
					OutVal = 400.0f,
					ArriveTangent = 0.0f,
					LeaveTangent = 0.0f,
					InterpMode = Object.EInterpCurveMode.CIM_Linear,
				},
			},
			InterpMethod = Object.EInterpMethodType.IMT_UseFixedTangentEval,
		};
		SpeedMaxBaseVelocity = 400.0f;
		SpeedMinBaseVelocity = 10.0f;
		SpeedStrafeVelocityAccelerationFactor = 10.0f;
		SpeedWalkVelocityAccelerationFactor = 7.0f;
		SpeedSprintVelocityAccelerationFactor = 30.0f;
		SpeedEnergyDecelerationTime = 3.0f;
		SpeedEnergyDecelerationExponent = 0.50f;
		SpeedTurnDecelerationFactor = 10.0f;
		UpwardWalkFrictionScale = 1.10f;
		DownwardWalkFrictionScale = 0.80f;
		MinWalkFrictionModify = 0.40f;
		MaxWalkFrictionModify = 2.0f;
		UpwardSlideFrictionScale = 5.0f;
		DownwardSlideFrictionScale = 1.80f;
		BrakingFrictionStrength = 1.0f;
		RollTriggerTime = 1.0f;
		FallingUncontrolledHeight = 1000.0f;
		DefaultSlidingSound = LoadAsset<SoundCue>("A_Kits.ZipLine.ZipLine")/*Ref SoundCue'A_Kits.ZipLine.ZipLine'*/;
		OverrideSynchPosOffset = -1.0f;
		PhysicsHitReactionBlendInTime = 0.080f;
		PhysicsHitReactionBlendOutTime = 0.60f;
		PhysicsHitReactionScale = 1.0f;
		FootstepTraceLength = 80.0f;
		FootstepTraceWidth = 10.0f;
		DefaultFootstepMaterial = LoadAsset<PhysicalMaterial>("TDPhysicalMaterials.Concrete.PM_Concrete")/*Ref PhysicalMaterial'TDPhysicalMaterials.Concrete.PM_Concrete'*/;
		UnrealEngineFallDamageScale = 1.0f;
		RegenerateFromTaserPerSecond = 50.0f;
		TaserRegenerateDelay = 1.50f;
		RegenerateFromStunPerSecond = 10.0f;
		MinTimeBeforeRemovingDeadBody = 0.50f;
		MaxTimeBeforeRemovingDeadBody = 4.0f;
		WalkableFloorZ = 0.710f;
		bCanCrouch = true;
		bCanFly = true;
		bIsFemale = true;
		bCanPickupInventory = true;
		GroundSpeed = 720.0f;
		AirSpeed = 2400.0f;
		AccelRate = 6144.0f;
		AirControl = 0.0250f;
		CrouchedPct = 0.40f;
		BaseEyeHeight = 76.0f;
		SceneCapture = Default__TdPawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = Default__TdPawn_DrawFrust0/*Ref DrawFrustumComponent'Default__TdPawn.DrawFrust0'*/;
		CylinderComponent = Default__TdPawn_CollisionCylinder/*Ref CylinderComponent'Default__TdPawn.CollisionCylinder'*/;
		AlwaysRelevantDistanceSquared = 1000000.0f;
		InventoryManagerClass = ClassT<TdInventoryManager>()/*Ref Class'TdInventoryManager'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__TdPawn_SceneCaptureCharacterComponent0/*Ref SceneCaptureCharacterComponent'Default__TdPawn.SceneCaptureCharacterComponent0'*/,
			Default__TdPawn_DrawFrust0/*Ref DrawFrustumComponent'Default__TdPawn.DrawFrust0'*/,
			Default__TdPawn_CollisionCylinder/*Ref CylinderComponent'Default__TdPawn.CollisionCylinder'*/,
			Default__TdPawn_Arrow/*Ref ArrowComponent'Default__TdPawn.Arrow'*/,
			Default__TdPawn_MyLightEnvironment/*Ref DynamicLightEnvironmentComponent'Default__TdPawn.MyLightEnvironment'*/,
			Default__TdPawn_TdPawnMesh3p/*Ref TdSkeletalMeshComponent'Default__TdPawn.TdPawnMesh3p'*/,
			Default__TdPawn_CollisionCylinder/*Ref CylinderComponent'Default__TdPawn.CollisionCylinder'*/,
			Default__TdPawn_ActorCollisionCylinder/*Ref CylinderComponent'Default__TdPawn.ActorCollisionCylinder'*/,
		};
		CollisionComponent = Default__TdPawn_CollisionCylinder/*Ref CylinderComponent'Default__TdPawn.CollisionCylinder'*/;
	}
}
}