namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdBotPawn : TdPawn/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public const int SETUPTEMPLATE_BOTPAWN = 0;
	public const int SETUPTEMPLATE_BOTPAWN_1 = 1;
	public const int SETUPTEMPLATE_BOTPAWN_2 = 2;
	public const int SETUPTEMPLATE_BOTPAWN_3 = 3;
	public const int SETUPTEMPLATE_BOTPAWN_4 = 4;
	
	public enum DeathAnimType 
	{
		DAT_Ragdoll,
		DAT_RagdollHard,
		DAT_DeathFront,
		DAT_DeathFrontHard,
		DAT_DeathBack,
		DAT_DeathBackHard,
		DAT_DeathRight,
		DAT_DeathRightHard,
		DAT_DeathLeft,
		DAT_DeathLeftHard,
		DAT_MAX
	};
	
	public enum EAcceleration 
	{
		EANormal,
		EAFast,
		EAcceleration_MAX
	};
	
	public enum EPose 
	{
		Pose_Normal,
		Pose_Crouched,
		Pose_Melee,
		Pose_MAX
	};
	
	public enum AIFiringMood 
	{
		AFM_Aimed,
		AFM_None,
		AFM_MAX
	};
	
	public enum AIFiringRange 
	{
		AFR_Near,
		AFR_Combat,
		AFR_Far,
		AFR_None,
		AFR_MAX
	};
	
	public partial struct /*native */InvulnerableDamageTypeStruct
	{
		public Class DamageType;
		public name Identifier;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004B607E
	//		DamageType = default;
	//		Identifier = (name)"None";
	//	}
	};
	
	public partial struct /*native */DeathAnimData
	{
		public/*(DeathAnim)*/ name AnimName;
		public/*(DeathAnim)*/ float PlaybackSpeed;
		public/*(DeathAnim)*/ bool bUseRootMotion;
		public/*(DeathAnim)*/ float PawnImpulse;
		public/*(DeathAnim)*/ float PawnZImpulse;
		public/*(DeathAnim)*/ float BoneImpulse;
		public/*(DeathAnim)*/ float GravityModifier;
		public/*(DeathAnim)*/ float CollisionScale;
		public/*(DeathAnim)*/ bool bUseMotors;
		public/*(DeathAnim)*/ float MotorStrength;
		public/*(DeathAnim)*/ float TimeToEnableRagdoll;
		public/*(DeathAnim)*/ float TimeToBlendOutMotors;
		public/*(DeathAnim)*/ float TimeToDisableMotors;
		public/*(DeathAnim)*/ float TimeToBoneImpulse;
		public/*(DeathAnim)*/ float TimeToFullRagdoll;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004B6386
	//		AnimName = (name)"None";
	//		PlaybackSpeed = 1.0f;
	//		bUseRootMotion = false;
	//		PawnImpulse = 0.0f;
	//		PawnZImpulse = 0.0f;
	//		BoneImpulse = 0.0f;
	//		GravityModifier = 1.0f;
	//		CollisionScale = 1.0f;
	//		bUseMotors = false;
	//		MotorStrength = 0.0f;
	//		TimeToEnableRagdoll = 0.0f;
	//		TimeToBlendOutMotors = 0.0f;
	//		TimeToDisableMotors = 0.0f;
	//		TimeToBoneImpulse = 0.0f;
	//		TimeToFullRagdoll = 0.0f;
	//	}
	};
	
	public partial struct /*native */EaseStructure
	{
		public float Value;
		public float StartTime;
		public float EndTime;
		public float StartValue;
		public float EndValue;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x004B2D56
	//		Value = 0.0f;
	//		StartTime = 0.0f;
	//		EndTime = 0.0f;
	//		StartValue = 0.0f;
	//		EndValue = 0.0f;
	//	}
	};
	
	public /*protected */int SetupTemplateCount;
	public bool bInitializing;
	public bool bShouldNextMeleeCausePlayerFall;
	public /*private */bool bAllowStandingTurning;
	public/*(BotConfig)*/ bool bImmobile;
	public bool SpawnedFromKismet;
	public bool bDyingFromCover;
	public bool bAIGodMode;
	public bool bChaseAI;
	public /*private */bool bForceWalking;
	public /*private */bool bWantsToWalk;
	public /*private */bool bIsSlowWalking;
	public /*private */bool bDebuggingFalling;
	public bool bHasStoppedAtFinalGoal;
	public /*private */bool bForceStasis;
	public /*private */bool bAIIgnoreMoveInput;
	public bool bCanDoTakedownMoves;
	public /*private */bool bIgnoreAIPawnBlockingVolumes;
	public /*private */bool bIsWalkingOrStanding;
	public bool bDebugOutput;
	public bool bUseLegRotationHack1;
	public bool bUseLegRotationHack2;
	public /*private */bool bUseLegRotation;
	public /*config */bool bDebugDeathAnim;
	public bool IsPressingWeaponTrigger;
	public bool bWantsToFire;
	public bool bBurstWait;
	public bool bNewBurst;
	public bool bOkToBurst;
	public bool bForceCombatRange_Preferred;
	public bool bForceCombatRange_Max;
	public bool bUseTemporaryCombatRange;
	public bool bRunPastNode;
	public bool bShowPathInfo;
	public bool bDebugShowVelocity;
	public bool bForceWaitForDamage;
	public /*transient */bool bEnableMeleePose;
	public bool bIsAccelerating;
	public /*transient */bool bEnableInverseKinematics;
	public bool bHeadPitchAlwaysOk;
	public bool bCanFire;
	public /*private transient */bool bIsRunnerVisionEnabled;
	public /*private transient */bool bPawnRunnerVision;
	public float AudibleFeetRange;
	public TdPawn Target;
	public float TurnTimer;
	public /*private */array<TdBotPawn.InvulnerableDamageTypeStruct> InvulnerableDamageTypes;
	public TdAIController myController;
	public TdInv_Shield myShield;
	public AnimNodeSynch LegMovementSyncGroup;
	public TdAnimNodeAimOffset HitReactionNode;
	public TdAnimNodeAimOffset HitReactionNode2;
	public float HitReactionRelay1;
	public float HitReactionRelay2;
	public /*config */float LegOffsetWalkFwd;
	public /*config */float LegOffsetWalkLeft60;
	public /*config */float LegOffsetWalkLeftBwd120;
	public /*config */float LegOffsetWalkRight60;
	public /*config */float LegOffsetWalkRightBwd120;
	public /*config */float LegOffsetWalkBack;
	public /*config */float LegOffsetRunFwd;
	public /*config */float LegOffsetRunLeft90;
	public /*config */float LegOffsetRunLeft180;
	public /*config */float LegOffsetRunRight90;
	public /*config */float LegOffsetRunRight180;
	public /*const */float CMaxPathDistSq;
	public /*private */TdBubbleStack ForcedWalkingStack;
	public /*private */int iSetMoveCounter;
	public /*private */AITemplate myTemplate;
	public /*private */float StartedRunningTimeStamp;
	public /*private */Object.Vector DebugFallingPos;
	public /*private */Object.Vector DebugFallingSpeed;
	public float EvadedTimeStamp;
	public int LastAnchorNetworkId;
	public float DamageMultiplier_Head;
	public float DamageMultiplier_Body;
	public SoundCue bulletFlyby;
	public float ReloadReadyTime;
	public TdBotPawn.DeathAnimType ActiveDeathAnimType;
	public /*protected */TdBotPawn.AIFiringMood FiringMood;
	public /*protected */TdBotPawn.AIFiringRange FiringRange;
	public /*transient */TdPawn.EWeaponAnimState AiInitializeWeaponAnimationState;
	public TdBotPawn.DeathAnimData DeathAnim;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimRagdoll;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimRagdollHard;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathFront;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathFrontHard;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathBack;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathBackHard;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathRight;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathRightHard;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathLeft;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathLeftHard;
	public/*(DeathAnim)*/ /*config */TdBotPawn.DeathAnimData DeathAnimDeathByAuto;
	public array<name> RagdollBones;
	public float RagdollMotorBlendOut;
	public float RagdollTimer;
	public/*()*/ /*private */SoundCue BodyFallHard;
	public/*()*/ /*private */SoundCue BodyFallMedium;
	public/*()*/ /*private */SoundCue BodyFallSoft;
	public/*(BotControl)*/ /*config */int AccelRateNormal;
	public/*(BotControl)*/ /*config */int AccelRateFast;
	public float CertainSightRadius;
	public/*()*/ int CurrentBurstLength;
	public/*()*/ float BurstDelayMin;
	public/*()*/ float BurstDelayMax;
	public/*()*/ int CurrentBurstMin;
	public/*()*/ int CurrentBurstMax;
	public float ForcedCombatRange_Preferred;
	public float ForcedCombatRange_Max;
	public float TemporaryCombatRange;
	public int DeltaRotation;
	public float ThisTick;
	public float SavedRotationTime;
	public /*transient */int MainWeaponAmmo_Dropped;
	public /*transient */int MainWeaponAmmo_Disarmed;
	public /*private transient */int FactoryAmmoDrop_Easy;
	public /*private transient */int FactoryAmmoDrop_Medium;
	public /*private transient */int FactoryAmmoDrop_Hard;
	public /*private transient */int FactoryAmmoDisarm_Easy;
	public /*private transient */int FactoryAmmoDisarm_Medium;
	public /*private transient */int FactoryAmmoDisarm_Hard;
	public Core.ClassT<TdProj_Grenade> DroppedGrenadeClass;
	public AnimNodeSlot CustomFullBodyAnimNode;
	public TdAIAnimationController myAnimationController;
	public Object.Vector DirectionOfMovement;
	public float CurveSteepness;
	public int CurrentRotationSpeed;
	public int OldYaw;
	public Object.Vector aimPos;
	public /*private */float AccumulatedDeltaTime;
	public/*(AIMovement)*/ /*config */int MaxLookAhead;
	public/*(AIMovement)*/ /*config */int DiffForMaxRotationSpeed;
	public/*(AIMovement)*/ /*config */int MaxRotationSpeed;
	public/*(AIMovement)*/ /*config */int MaxRotationAcceleration;
	public/*(AIMovement)*/ /*config */int MinRotationAcceleration;
	public/*(AIMovement)*/ /*config */int RotationSpeedDiffForMaxAcceleration;
	public/*(AIMovement)*/ /*config */int TurnFrictionTweak;
	public/*(AIMovement)*/ /*config */float RotationSpeedForMaxLean;
	public/*(AccelerationTimes)*/ /*config */float WalkToRun;
	public/*(AccelerationTimes)*/ /*config */float RunToWalk;
	public/*(AccelerationTimes)*/ /*config */float StandToWalk;
	public /*config */float DamageTime;
	public /*transient */int MeleeAttackLimit;
	public /*transient */int ConsecutiveHitCount;
	public /*transient */int ConsecutiveCrouchHitCount;
	public /*transient */int ConsecutiveAirHitCount;
	public /*transient */float MeleeAttackTime;
	public /*transient */float CrouchMeleeAttackTime;
	public /*transient */float AirMeleeAttackTime;
	public /*config */float BlockResetTime;
	public float InterpolatedSlope;
	public /*transient */TdBotPawn.EaseStructure InterpolationInformation;
	public /*transient */name AiProfileName;
	public /*transient */float AnimationRunSpeed;
	public /*transient */float AnimationWalkSpeed;
	public /*transient */float AnimationExitReloadTime;
	public float StartFallingZ;
	public Object.Vector StartingLocation;
	public Object.Rotator StartingRotation;
	public /*export editinline transient */SkeletalMeshComponent AdditionalSkeletalMesh;
	public Object.Vector ViewPointLocation;
	public Object.Vector ViewPointLocation_Crouching;
	public TdAI_RunnerVisionEffect RVEffect;
	public /*delegate*/TdBotPawn.OnDeath __OnDeath__Delegate;
	
	// Export UTdBotPawn::execUpdateLeaning(FFrame&, void* const)
	public virtual /*native simulated function */void UpdateLeaning(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdBotPawn::execInitMoveObjects(FFrame&, void* const)
	public override /*native function */void InitMoveObjects()
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdBotPawn::execValidAnchor(FFrame&, void* const)
	public override /*native function */bool ValidAnchor()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void Initialize(TdAIController C)
	{
	
	}
	
	public override /*simulated event */void PlayFootStepSound(int FootDown)
	{
	
	}
	
	public override Died_del Died { get => bfield_Died ?? TdBotPawn_Died; set => bfield_Died = value; } Died_del bfield_Died;
	public override Died_del global_Died => TdBotPawn_Died;
	public /*event */bool TdBotPawn_Died(Controller Killer, Core.ClassT<DamageType> DamageType, Object.Vector HitLocation)
	{
	
		return default;
	}
	
	public override /*simulated event */void Destroyed()
	{
	
	}
	
	public virtual /*function */void ResetLocation()
	{
	
	}
	
	public virtual /*event */void SetPawnRunnerVision(bool bEnabled)
	{
	
	}
	
	public virtual /*function */void SetRunnerVisionEnabled(bool bEnabled)
	{
	
	}
	
	public virtual /*private final function */void UpdateRunnerVision()
	{
	
	}
	
	public virtual /*event */void SetChaseAI(bool bFlag)
	{
	
	}
	
	public virtual /*function */void UseLegRotation(bool bLegRotation)
	{
	
	}
	
	public virtual /*final function */bool HasUseLegRotationFlagSet()
	{
	
		return default;
	}
	
	public override /*simulated function */void PlayCustomAnim(TdPawn.CustomNodeType Type, name AnimName, float Rate, float BlendInTime, float BlendOutTime, bool bLooping, bool bOverride, bool bRootMotion, /*optional */bool bRootRotation = default)
	{
	
	}
	
	public override /*simulated function */void SetCustomAnimsBlendOutTime(TdPawn.CustomNodeType Type, float BlendOutTime)
	{
	
	}
	
	public virtual /*function */bool CanDoRunStopTurnMoves()
	{
	
		return default;
	}
	
	// Export UTdBotPawn::execTdSetRotation(FFrame&, void* const)
	public virtual /*native function */bool TdSetRotation(Object.Rotator NewRotation)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override SetMove_del SetMove { get => bfield_SetMove ?? TdBotPawn_SetMove; set => bfield_SetMove = value; } SetMove_del bfield_SetMove;
	public override SetMove_del global_SetMove => TdBotPawn_SetMove;
	public /*simulated event */bool TdBotPawn_SetMove(TdPawn.EMovement NewMove, /*optional */bool bViaReplication = default, /*optional */bool bCheckCanDo = default)
	{
	
		return default;
	}
	
	public override /*simulated event */bool CanDoMove(TdPawn.EMovement NewMove)
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool OkToChangeState()
	{
	
		return default;
	}
	
	public virtual /*simulated function */bool OkToUpdatePath()
	{
	
		return default;
	}
	
	public virtual /*function */void AddSpecialOutput(ref string Text)
	{
	
	}
	
	public virtual /*function */bool LoseWeaponAfterDisarm()
	{
	
		return default;
	}
	
	public delegate void OnDeath(TdBotPawn Victim);
	
	public virtual /*function */void SetDeathCallback(/*delegate*/TdBotPawn.OnDeath callback)
	{
	
	}
	
	public virtual /*function */void StopMoving()
	{
	
	}
	
	public virtual /*function */void OnAIReleaseScripting(SeqAct_AIReleaseScripting Action)
	{
	
	}
	
	public virtual /*function */void OnAIImmobile(SeqAct_AIImmobile Action)
	{
	
	}
	
	public virtual /*function */void OnTdAIStasis(SeqAct_TdAIStasis Action)
	{
	
	}
	
	public virtual /*function */void OnTdSetPathLimits(SeqAct_TdSetPathLimits Action)
	{
	
	}
	
	public virtual /*function */void OnAIHoldFire(SeqAct_AIHoldFire Action)
	{
	
	}
	
	public virtual /*function */void OnAIForceWalking(SeqAct_AIForceWalking Action)
	{
	
	}
	
	public virtual /*function */void OnTdAIPerfectAim(SeqAct_TdAIPerfectAim Action)
	{
	
	}
	
	public virtual /*function */void OnAIFireAt(SeqAct_AIFireAt Action)
	{
	
	}
	
	public virtual /*function */void OnSetCombatRange(SeqAct_SetCombatRange RangeData)
	{
	
	}
	
	public virtual /*function */void OnSetCoverGroup(SeqAct_SetCoverGroup Action)
	{
	
	}
	
	public virtual /*function */void ActivateStasis(bool flag, bool UpdateControllerState)
	{
	
	}
	
	public override /*simulated function */bool IsFirstPerson()
	{
	
		return default;
	}
	
	public override /*event */void AnimNotifyGrenadeThrow()
	{
	
	}
	
	public virtual /*final function */bool HasAmmo()
	{
	
		return default;
	}
	
	public override /*simulated function */void SetWeaponAnimState(TdPawn.EWeaponAnimState AnimState)
	{
	
	}
	
	public virtual /*function */name GetAimProfileName(name AimNodeName)
	{
	
		return default;
	}
	
	public virtual /*function */name GetPoseProfileName(name PoseNodeName)
	{
	
		return default;
	}
	
	public virtual /*simulated function */void InitializeAimOffsetNodes()
	{
	
	}
	
	public virtual /*simulated function */void InitializePoseOffsetNodes()
	{
	
	}
	
	public override /*simulated function */void UpdateAnimSets(/*optional */TdWeapon NewWeapon = default)
	{
	
	}
	
	public override /*simulated function */void SetAimOffsetNodesProfile(name ProfileName)
	{
	
	}
	
	public override /*simulated function */void SetWeaponPoseOffsetProfile(name ProfileName)
	{
	
	}
	
	public override /*simulated function */void SetUnarmed()
	{
	
	}
	
	public override /*simulated function */void SetArmed()
	{
	
	}
	
	public override /*event */void EncroachedBy(Actor Other)
	{
	
	}
	
	public override /*simulated function */bool AllowStickyAim()
	{
	
		return default;
	}
	
	public virtual /*function */float WhereInWalkCykle()
	{
	
		return default;
	}
	
	public delegate bool CanFireWeapon_del();
	public virtual CanFireWeapon_del CanFireWeapon { get => bfield_CanFireWeapon ?? TdBotPawn_CanFireWeapon; set => bfield_CanFireWeapon = value; } CanFireWeapon_del bfield_CanFireWeapon;
	public virtual CanFireWeapon_del global_CanFireWeapon => TdBotPawn_CanFireWeapon;
	public /*function */bool TdBotPawn_CanFireWeapon()
	{
	
		return default;
	}
	
	public virtual /*function */bool WalkingOrStanding()
	{
	
		return default;
	}
	
	public virtual /*event */void FireWhenReady()
	{
	
	}
	
	public override /*simulated event */void CeaseFire()
	{
	
	}
	
	public virtual /*protected function */void CheckFire()
	{
	
	}
	
	public virtual /*function */void StartFiringWeapon()
	{
	
	}
	
	public virtual /*function */void StopFiringWeapon()
	{
	
	}
	
	public virtual /*function */bool IsOkToFireBullet()
	{
	
		return default;
	}
	
	public virtual /*function */void NotifyOkToBurst()
	{
	
	}
	
	public virtual /*function */void PauseFiring()
	{
	
	}
	
	public virtual /*function */void StartNewBurst()
	{
	
	}
	
	public override /*simulated function */void WeaponFired(bool bViaReplication, /*optional */Object.Vector HitLocation = default)
	{
	
	}
	
	public virtual /*function */void BurstOver()
	{
	
	}
	
	public virtual /*function */void InterruptBurst()
	{
	
	}
	
	public override /*simulated function */void WeaponStoppedFiring(bool bViaReplication)
	{
	
	}
	
	public override /*simulated function */name PlayFireAnimation(name WeaponAnimSeqName, /*optional */bool bPlayWeaponAnimSeq = default)
	{
	
		return default;
	}
	
	public override /*function */float GetReloadPlaybackRate()
	{
	
		return default;
	}
	
	public override /*simulated function */name PlayReloadAnimation(name WeaponAnimSeqName, /*optional */bool bPlayWeaponAnimSeq = default)
	{
	
		return default;
	}
	
	public virtual /*function */float FRandRange(float Min, float Max)
	{
	
		return default;
	}
	
	// Export UTdBotPawn::execGetFiringRange(FFrame&, void* const)
	public virtual /*native function */TdBotPawn.AIFiringRange GetFiringRange()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execClassifyAIFiringRange(FFrame&, void* const)
	public virtual /*native final function */TdBotPawn.AIFiringRange ClassifyAIFiringRange(float DistanceSquared)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execSetAIFiringState(FFrame&, void* const)
	public virtual /*native final function */void SetAIFiringState(TdBotPawn.AIFiringMood M, float DistanceSquared)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdBotPawn::execIsCrouching(FFrame&, void* const)
	public virtual /*native function */bool IsCrouching()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execIsBusyCrouching(FFrame&, void* const)
	public virtual /*native function */bool IsBusyCrouching()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*final function */void SetPose(TdBotPawn.EPose pose)
	{
	
	}
	
	// Export UTdBotPawn::execGetCurrentPose(FFrame&, void* const)
	public virtual /*native final simulated function */TdBotPawn.EPose GetCurrentPose()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override /*simulated function */void OnCeaseRelevantRootMotion(AnimNodeSequence SeqNode)
	{
	
	}
	
	public virtual /*final function */bool HasShield()
	{
	
		return default;
	}
	
	public virtual /*function */void StartSliding(Object.Vector EndTarget)
	{
	
	}
	
	public virtual /*function */void StopSliding()
	{
	
	}
	
	public virtual /*function */void MakeInvulnerableTo(Core.ClassT<DamageType> DamageType, name Identifier)
	{
	
	}
	
	public virtual /*function */void MakeInvulnerableTo_StringVersion(array<name> DamageTypeNames, name Identifier)
	{
	
	}
	
	public virtual /*function */void RemoveInvulnerableTo(Core.ClassT<DamageType> DamageType, name Identifier)
	{
	
	}
	
	public virtual /*function */void RemoveAllInvulnerableTo(name Identifier)
	{
	
	}
	
	public virtual /*private final function */bool IsInvulnerableToThisDamageType(Core.ClassT<DamageType> DamageType)
	{
	
		return default;
	}
	
	public override /*function */void AdjustDamage(ref int inDamage, ref Object.Vector OutMomentum, Controller InstigatedBy, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo HitInfo = default)
	{
	
	}
	
	public override TakeDamage_del TakeDamage { get => bfield_TakeDamage ?? TdBotPawn_TakeDamage; set => bfield_TakeDamage = value; } TakeDamage_del bfield_TakeDamage;
	public override TakeDamage_del global_TakeDamage => TdBotPawn_TakeDamage;
	public /*function */void TdBotPawn_TakeDamage(int Damage, Controller InstigatedBy, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo HitInfo = default, /*optional */Actor DamageCauser = default)
	{
	
	}
	
	public override /*function */void PlayMeleeImpact(PhysicalMaterial PhysMat, TdPawn.EMeleeImpactType Type, Object.Vector TargetHitLocation, Object.Vector TargetHitNormal, Object.Vector TargetHitMomentum, name TargetHitBone, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public override /*function */bool PreventWeaponImpactEffect(Controller InstigatorController)
	{
	
		return default;
	}
	
	public override /*simulated function */void StumbleDamage(TdPawn InstigatorPawn, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public override /*simulated function */void BulletDamage(TdPawn InstigatorPawn, Object.Vector HitLocation, Object.Vector damageMomentum, Core.ClassT<DamageType> DamageType)
	{
	
	}
	
	public virtual /*function */void ForceWaitForDamage()
	{
	
	}
	
	public virtual /*function */void SetForceWaitForDamageTimer(float TimeToWait)
	{
	
	}
	
	public override /*simulated function */void PrepareForMeleeAttack(Core.ClassT<DamageType> MeleeDamageType)
	{
	
	}
	
	public virtual /*final function */bool HasMeleeIdleAnimation()
	{
	
		return default;
	}
	
	public virtual /*final function */bool HasMeleeTransitionAnimation()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanBlock()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldBlock(Core.ClassT<DamageType> MeleeDamageType)
	{
	
		return default;
	}
	
	public virtual /*function */void StartBlocking()
	{
	
	}
	
	public virtual /*function */void ResetBlockingParameters()
	{
	
	}
	
	public virtual /*function */void ResetCrouchBlockingParameters()
	{
	
	}
	
	public virtual /*function */void ResetAirBlockingParameters()
	{
	
	}
	
	public virtual /*function */bool ShouldMeleeCauseFall()
	{
	
		return default;
	}
	
	public virtual /*function */bool ShouldMeleeCauseStumbleFar()
	{
	
		return default;
	}
	
	public override /*function */void AddVelocity(Object.Vector NewVelocity, Object.Vector HitLocation, Core.ClassT<DamageType> DamageType, /*optional */Actor.TraceHitInfo HitInfo = default)
	{
	
	}
	
	public override /*function */void CrushedBy(Pawn OtherPawn)
	{
	
	}
	
	public virtual /*function */void OnStumble(bool bAllowRotation)
	{
	
	}
	
	public virtual /*function */void OnStumbleEnded()
	{
	
	}
	
	public virtual /*function */void OnDisarmed()
	{
	
	}
	
	public virtual /*function */void OnMeleedFromAir()
	{
	
	}
	
	public virtual /*function */void OnStoppedBlocking()
	{
	
	}
	
	public override /*simulated event */void PostBeginPlay()
	{
	
	}
	
	public override /*simulated function */void CacheAnimNodes()
	{
	
	}
	
	public virtual /*function */void InitAnimationSettings()
	{
	
	}
	
	public virtual /*function */void InitSyncNodes()
	{
	
	}
	
	public virtual /*simulated function */void InitializeWeaponAnimationSets()
	{
	
	}
	
	public virtual /*function */void SetAnimationController()
	{
	
	}
	
	public virtual /*function */TdAIAnimationController GetAnimationController()
	{
	
		return default;
	}
	
	public virtual /*function */void IgnoreMoveInput(bool bIgnore)
	{
	
	}
	
	// Export UTdBotPawn::execGetIgnoreMoveInput(FFrame&, void* const)
	public virtual /*native function */bool GetIgnoreMoveInput()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execInterpolateSlope(FFrame&, void* const)
	public virtual /*native final function */void InterpolateSlope(float DeltaSeconds)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void AllowStandingTurning(bool bAllowTurning)
	{
	
	}
	
	public virtual /*simulated function */void Turn(float DeltaTime)
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdBotPawn_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdBotPawn_Tick;
	public /*simulated function */void TdBotPawn_Tick(float DeltaTime)
	{
	
	}
	
	// Export UTdBotPawn::execUpdateHitReaction(FFrame&, void* const)
	public virtual /*native function */void UpdateHitReaction(float DeltaTime)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*event */void SpawnedByKismet()
	{
	
	}
	
	public override /*simulated function */Object.Vector GetWeaponStartTraceLocation(/*optional */Weapon CurrentWeapon = default)
	{
	
		return default;
	}
	
	// Export UTdBotPawn::execGetMinCombatDistance(FFrame&, void* const)
	public virtual /*native function */float GetMinCombatDistance()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execGetMaxCombatDistance(FFrame&, void* const)
	public virtual /*native final function */float GetMaxCombatDistance()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execGetMaxCombatDistance_Internal(FFrame&, void* const)
	public virtual /*protected native final function */float GetMaxCombatDistance_Internal()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execGetPreferredCombatDistance(FFrame&, void* const)
	public virtual /*native final function */float GetPreferredCombatDistance()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdBotPawn::execGetPreferredCombatDistance_Internal(FFrame&, void* const)
	public virtual /*protected native final function */float GetPreferredCombatDistance_Internal()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*private final function */void ForcePreferredCombatRange(float Distance)
	{
	
	}
	
	public virtual /*private final function */void ForceMaxCombatRange(float Distance)
	{
	
	}
	
	public virtual /*function */void ResetCombatRange()
	{
	
	}
	
	public virtual /*function */void SetTemporaryCombatRange(float Range)
	{
	
	}
	
	public virtual /*function */void ResetTemporaryCombatRange()
	{
	
	}
	
	public virtual /*function */float GetWeaponRange()
	{
	
		return default;
	}
	
	public override /*event */void OnAnimEnd(AnimNodeSequence SeqNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public virtual /*event */void DoBotJump()
	{
	
	}
	
	public virtual /*event */void DoShortJump()
	{
	
	}
	
	public virtual /*event */void DoMediumJump()
	{
	
	}
	
	public virtual /*event */void DoLongJump()
	{
	
	}
	
	public virtual /*event */void DoVaultOver()
	{
	
	}
	
	public virtual /*event */void DoSpeedVault()
	{
	
	}
	
	public virtual /*event */void DoGrabHeave()
	{
	
	}
	
	public override /*function */void AddDefaultInventory()
	{
	
	}
	
	public virtual /*event */void AddToInventory(Core.ClassT<TdWeapon> WeaponClass)
	{
	
	}
	
	public virtual /*function */void SetEnemyTarget(TdPawn aPawn)
	{
	
	}
	
	// Export UTdBotPawn::execSetAnchor(FFrame&, void* const)
	public override /*native function */void SetAnchor(NavigationPoint NewAnchor)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*function */void DrawDebugInfo(PlayerController Player, Canvas aCanvas)
	{
	
	}
	
	public override /*simulated function */void DrawDebugAnims(HUD HUD, ref float out_YL, ref float out_YPos)
	{
	
	}
	
	public virtual /*function */name GetCurrentProfileName(AnimNodeAimOffset AimNode)
	{
	
		return default;
	}
	
	public virtual /*event */Object.Rotator GetViewpointRotation()
	{
	
		return default;
	}
	
	public virtual /*function */float GetGroundSpeed()
	{
	
		return default;
	}
	
	public override /*function */bool CanAttack(Actor ATarget)
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateAgainstWall()
	{
	
	}
	
	public override /*simulated function */void PlayWeaponDeploy()
	{
	
	}
	
	public virtual /*simulated function */void LookBack()
	{
	
	}
	
	public delegate void StopLookback_del();
	public virtual StopLookback_del StopLookback { get => bfield_StopLookback ?? TdBotPawn_StopLookback; set => bfield_StopLookback = value; } StopLookback_del bfield_StopLookback;
	public virtual StopLookback_del global_StopLookback => TdBotPawn_StopLookback;
	public /*function */void TdBotPawn_StopLookback()
	{
	
	}
	
	public virtual /*simulated function */void PlayVOAnimation(name VOAnimSeqName, /*optional */bool bLooping = default, /*optional */float BlendInTime = default, /*optional */float BlendOutTime = default)
	{
	
	}
	
	public virtual /*simulated event */void StopVOAnimation(name VOAnimSeqName, /*optional */float BlendOutTime = default)
	{
	
	}
	
	// Export UTdBotPawn::execUpdateWalkingState(FFrame&, void* const)
	public override /*native simulated function */void UpdateWalkingState()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*final function */bool IsDead()
	{
	
		return default;
	}
	
	public virtual /*simulated function */void PlayDeathAnim()
	{
	
	}
	
	public virtual /*simulated function */void GetDeathAnim(TdBotPawn.DeathAnimType Type, ref TdBotPawn.DeathAnimData Data)
	{
	
	}
	
	public override /*simulated function */void PlayDying(Core.ClassT<DamageType> DamageType, Object.Vector HitLoc)
	{
	
	}
	
	public virtual /*simulated function */void ImpulseHisAss(Object.Vector Direction)
	{
	
	}
	
	public virtual /*simulated function */void GiveBoneImpulse()
	{
	
	}
	
	public virtual /*simulated function */void TickRagdoll(float DeltaTime)
	{
	
	}
	
	public virtual /*simulated function */void EnableRagdoll()
	{
	
	}
	
	public virtual /*simulated function */void StartBlendOutMotors()
	{
	
	}
	
	public virtual /*simulated function */void TurnOffMotors()
	{
	
	}
	
	public virtual /*simulated function */void FullBodyRagdoll()
	{
	
	}
	
	// Export UTdBotPawn::execOnContentLoaded(FFrame&, void* const)
	public virtual /*private native final function */void OnContentLoaded()
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*simulated event */int SetupTemplate(AITemplate TheTemplate, bool bGiveDefaultInventory)
	{
	
		return default;
	}
	
	// Export UTdBotPawn::execSetArmorDifficultyLevel(FFrame&, void* const)
	public override /*protected native function */void SetArmorDifficultyLevel(int Difficulty)
	{
		#warning NATIVE FUNCTION !
	}
	
	public override /*function */void TossInventory(Inventory Inv, /*optional */Object.Vector ForceVelocity = default, /*optional */Core.ClassT<DamageType> DamageType = default)
	{
	
	}
	
	// Export UTdBotPawn::execSetMainWeaponAmmoDrop(FFrame&, void* const)
	public virtual /*private native final function */void SetMainWeaponAmmoDrop(int Drop_Easy, int Drop_Medium, int Drop_Hard, int Disarm_Easy, int Disarm_Medium, int Disarm_Hard)
	{
		#warning NATIVE FUNCTION !
	}
	
	public virtual /*private final function */int GetDifficultyLevel()
	{
	
		return default;
	}
	
	public virtual /*function */int GetMainWeaponAmmoDropsDisarmed(int Difficulty)
	{
	
		return default;
	}
	
	public virtual /*function */int GetMainWeaponAmmoDropsDropped(int Difficulty)
	{
	
		return default;
	}
	
	public override /*function */void SetDifficultyLevel(int Difficulty)
	{
	
	}
	
	public virtual /*event */void UpdateAnimationBaseSpeed()
	{
	
	}
	
	// Export UTdBotPawn::execCheckForProximityShots(FFrame&, void* const)
	public override /*native function */void CheckForProximityShots(Object.Vector Start, Object.Vector End)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTdBotPawn::execGetViewpointLocation(FFrame&, void* const)
	public override /*native function */Object.Vector GetViewpointLocation(/*optional */bool ForceCrouch = default)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public override Landed_del Landed { get => bfield_Landed ?? TdBotPawn_Landed; set => bfield_Landed = value; } Landed_del bfield_Landed;
	public override Landed_del global_Landed => TdBotPawn_Landed;
	public /*event */void TdBotPawn_Landed(Object.Vector aNormal, Actor anActor)
	{
	
	}
	
	public override /*event */void Falling()
	{
	
	}
	
	public virtual /*function */bool ShouldStumbleOffLedge()
	{
	
		return default;
	}
	
	public virtual /*exec function */void ClimbInitiatedNotify()
	{
	
	}
	
	public virtual /*exec function */void ClimbCompletedNotify()
	{
	
	}
	
	public virtual /*exec function */void HeaveInitiatedNotify()
	{
	
	}
	
	public virtual /*exec function */void HeaveCompletedNotify()
	{
	
	}
	
	public virtual /*exec function */void BotGrabHeave_JumpInitiatedNotify()
	{
	
	}
	
	public virtual /*exec function */void BotGrabHeave_JumpDoneNotify()
	{
	
	}
	
	public virtual /*exec function */void BotGrabHeave_HeaveNotify()
	{
	
	}
	
	public virtual /*exec function */void OnStumbleCompletedNotifier()
	{
	
	}
	
	public virtual /*exec function */void OnExitCoverNotify()
	{
	
	}
	
	public virtual /*exec function */void OnCoverExitedNotify()
	{
	
	}
	
	public virtual /*final function */bool IsForcedToWalk()
	{
	
		return default;
	}
	
	public virtual /*final function */bool WantsToRun()
	{
	
		return default;
	}
	
	public override /*event */void SetWalking(bool bNewIsWalking)
	{
	
	}
	
	public virtual /*function */void ForceWalking(bool flag, name Identifier)
	{
	
	}
	
	public virtual /*event */void SetIsSlowWalking(bool flag)
	{
	
	}
	
	public virtual /*event */bool GetIsSlowWalking()
	{
	
		return default;
	}
	
	public override /*event */float GetRunSpeed()
	{
	
		return default;
	}
	
	public override /*event */float GetWalkSpeed()
	{
	
		return default;
	}
	
	public virtual /*function */void StartDebugFalling()
	{
	
	}
	
	public virtual /*function */void UpdateDebugFalling()
	{
	
	}
	
	// Export UTdBotPawn::execShouldIgnoreAIPawnBlockingVolumes(FFrame&, void* const)
	public virtual /*native function */bool ShouldIgnoreAIPawnBlockingVolumes()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void SetIgnoreAIPawnBlockingVolumes(bool flag)
	{
	
	}
	
	public virtual /*function */bool IsDoingSpecialMove()
	{
	
		return default;
	}
	
	public virtual /*event */void RecycleBot()
	{
	
	}
	
	public virtual /*function */void RemoveRagDoll()
	{
	
	}
	
	public override /*function */void DetachFromController(/*optional */bool bDestroyController = default)
	{
	
	}
	
	public virtual /*function */bool UseWeaponLOI()
	{
	
		return default;
	}
	
	public virtual /*final function */bool IsInMeleeMove()
	{
	
		return default;
	}
	
	public override Touch_del Touch { get => bfield_Touch ?? TdBotPawn_Touch; set => bfield_Touch = value; } Touch_del bfield_Touch;
	public override Touch_del global_Touch => TdBotPawn_Touch;
	public /*event */void TdBotPawn_Touch(Actor Other, PrimitiveComponent OtherComp, Object.Vector HitLocation, Object.Vector HitNormal)
	{
	
	}
	
	public override /*function */void UseRootMotion(bool Use)
	{
	
	}
	
	public override /*function */void UseRootRotation(bool Use)
	{
	
	}
	
	public override /*event */void PhysicsVolumeChange(PhysicsVolume NewVolume)
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Died = null;
		SetMove = null;
		CanFireWeapon = null;
		TakeDamage = null;
		Tick = null;
		StopLookback = null;
		Landed = null;
		Touch = null;
	
	}
	
	protected /*function */void TdBotPawn_LookbackState_PushedState()// state function
	{
	
	}
	
	protected /*function */void TdBotPawn_LookbackState_PoppedState()// state function
	{
	
	}
	
	protected /*function */void TdBotPawn_LookbackState_StopLookback()// state function
	{
	
	}
	
	protected /*function */bool TdBotPawn_LookbackState_CanFireWeapon()// state function
	{
	
		return default;
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) LookbackState()/*state LookbackState*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	
	
	protected /*function */void TdBotPawn_Dying_BeginState(name PreviousStateName)// state function
	{
	
	}
	
	protected /*event */void TdBotPawn_Dying_RigidBodyCollision(PrimitiveComponent HitComponent, PrimitiveComponent OtherComponent, /*const */ref Actor.CollisionImpactData RigidCollisionData, int ContactIndex)// state function
	{
	
	}
	
	protected (System.Action<name>, StateFlow, System.Action<name>) Dying()/*state Dying*/
	{
		throw new System.InvalidOperationException("Stub state");
	}
	protected override (System.Action<name>, StateFlow, System.Action<name>) FindState(name stateName)
	{
		switch(stateName)
		{
			case "LookbackState": return LookbackState();
			case "Dying": return Dying();
			default: return base.FindState(stateName);
		}
	}
	public TdBotPawn()
	{
		// Object Offset:0x0052AEAD
		bAllowStandingTurning = true;
		bDebugOutput = true;
		bUseLegRotation = true;
		bNewBurst = true;
		AudibleFeetRange = 2000.0f;
		CMaxPathDistSq = 1440000.0f;
		EvadedTimeStamp = -99999.0f;
		DamageMultiplier_Head = 1.0f;
		DamageMultiplier_Body = 1.0f;
		bulletFlyby = LoadAsset<SoundCue>("A_Effects_Bullet_Bys.BulletBy.9mm_BulletBy")/*Ref SoundCue'A_Effects_Bullet_Bys.BulletBy.9mm_BulletBy'*/;
		FiringMood = TdBotPawn.AIFiringMood.AFM_None;
		FiringRange = TdBotPawn.AIFiringRange.AFR_None;
		AiInitializeWeaponAnimationState = TdPawn.EWeaponAnimState.WS_Relaxed;
		DeathAnim = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"None",
			PlaybackSpeed = 1.0f,
			bUseRootMotion = false,
			PawnImpulse = 0.0f,
			PawnZImpulse = 0.0f,
			BoneImpulse = 0.0f,
			GravityModifier = 1.0f,
			CollisionScale = 1.0f,
			bUseMotors = false,
			MotorStrength = 0.0f,
			TimeToEnableRagdoll = 0.0f,
			TimeToBlendOutMotors = 0.0f,
			TimeToDisableMotors = 0.0f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.0f,
		};
		DeathAnimRagdoll = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"None",
			PlaybackSpeed = 1.0f,
			bUseRootMotion = false,
			PawnImpulse = 0.0f,
			PawnZImpulse = 0.0f,
			BoneImpulse = 0.0f,
			GravityModifier = 1.0f,
			CollisionScale = 1.0f,
			bUseMotors = false,
			MotorStrength = 0.0f,
			TimeToEnableRagdoll = 0.0f,
			TimeToBlendOutMotors = 0.0f,
			TimeToDisableMotors = 0.0f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.0f,
		};
		DeathAnimRagdollHard = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"HitMeleeInAir_High",
			PlaybackSpeed = 0.80f,
			bUseRootMotion = false,
			PawnImpulse = 500.0f,
			PawnZImpulse = 275.0f,
			BoneImpulse = 0.0f,
			GravityModifier = 0.90f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 2000.0f,
			TimeToEnableRagdoll = 0.10f,
			TimeToBlendOutMotors = 0.20f,
			TimeToDisableMotors = 0.30f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.30f,
		};
		DeathAnimDeathFront = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"HitMeleeOverEdge",
			PlaybackSpeed = 0.750f,
			bUseRootMotion = false,
			PawnImpulse = 325.0f,
			PawnZImpulse = 125.0f,
			BoneImpulse = 150.0f,
			GravityModifier = 0.50f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 2000.0f,
			TimeToEnableRagdoll = 0.250f,
			TimeToBlendOutMotors = 0.30f,
			TimeToDisableMotors = 0.50f,
			TimeToBoneImpulse = 0.260f,
			TimeToFullRagdoll = 0.50f,
		};
		DeathAnimDeathFrontHard = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"DeathByShotgun",
			PlaybackSpeed = 0.90f,
			bUseRootMotion = false,
			PawnImpulse = 500.0f,
			PawnZImpulse = 350.0f,
			BoneImpulse = 500.0f,
			GravityModifier = 0.90f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 1000.0f,
			TimeToEnableRagdoll = 0.20f,
			TimeToBlendOutMotors = 0.450f,
			TimeToDisableMotors = 0.50f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.50f,
		};
		DeathAnimDeathBack = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"DeathByHeadShot",
			PlaybackSpeed = 0.80f,
			bUseRootMotion = true,
			PawnImpulse = 50.0f,
			PawnZImpulse = 1.0f,
			BoneImpulse = 500.0f,
			GravityModifier = 1.0f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 200.0f,
			TimeToEnableRagdoll = 0.20f,
			TimeToBlendOutMotors = 0.250f,
			TimeToDisableMotors = 0.40f,
			TimeToBoneImpulse = 0.210f,
			TimeToFullRagdoll = 0.40f,
		};
		DeathAnimDeathBackHard = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"HitMeleeOverEdge",
			PlaybackSpeed = 0.750f,
			bUseRootMotion = false,
			PawnImpulse = 550.0f,
			PawnZImpulse = 250.0f,
			BoneImpulse = 400.0f,
			GravityModifier = 0.850f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 2000.0f,
			TimeToEnableRagdoll = 0.350f,
			TimeToBlendOutMotors = 0.450f,
			TimeToDisableMotors = 0.50f,
			TimeToBoneImpulse = 0.370f,
			TimeToFullRagdoll = 0.50f,
		};
		DeathAnimDeathRight = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"HitMeleeRight",
			PlaybackSpeed = 0.80f,
			bUseRootMotion = false,
			PawnImpulse = 400.0f,
			PawnZImpulse = 200.0f,
			BoneImpulse = 0.0f,
			GravityModifier = 0.80f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 20000.0f,
			TimeToEnableRagdoll = 0.20f,
			TimeToBlendOutMotors = 0.30f,
			TimeToDisableMotors = 0.60f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.20f,
		};
		DeathAnimDeathRightHard = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"HitMeleeWallrunRight",
			PlaybackSpeed = 1.0f,
			bUseRootMotion = true,
			PawnImpulse = 0.0f,
			PawnZImpulse = 0.0f,
			BoneImpulse = 0.0f,
			GravityModifier = 0.80f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 2000.0f,
			TimeToEnableRagdoll = 0.0f,
			TimeToBlendOutMotors = 0.30f,
			TimeToDisableMotors = 0.750f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.750f,
		};
		DeathAnimDeathLeft = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"HitMeleeLeft",
			PlaybackSpeed = 0.80f,
			bUseRootMotion = false,
			PawnImpulse = 400.0f,
			PawnZImpulse = 200.0f,
			BoneImpulse = 0.0f,
			GravityModifier = 0.80f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 20000.0f,
			TimeToEnableRagdoll = 0.20f,
			TimeToBlendOutMotors = 0.30f,
			TimeToDisableMotors = 0.60f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.20f,
		};
		DeathAnimDeathLeftHard = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"HitMeleeWallrunLeft",
			PlaybackSpeed = 1.0f,
			bUseRootMotion = true,
			PawnImpulse = 0.0f,
			PawnZImpulse = 0.0f,
			BoneImpulse = 0.0f,
			GravityModifier = 0.80f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 2000.0f,
			TimeToEnableRagdoll = 0.0f,
			TimeToBlendOutMotors = 0.30f,
			TimeToDisableMotors = 0.750f,
			TimeToBoneImpulse = 0.0f,
			TimeToFullRagdoll = 0.750f,
		};
		DeathAnimDeathByAuto = new TdBotPawn.DeathAnimData
		{
			AnimName = (name)"DeathByAuto",
			PlaybackSpeed = 0.80f,
			bUseRootMotion = false,
			PawnImpulse = 600.0f,
			PawnZImpulse = 175.0f,
			BoneImpulse = 50.0f,
			GravityModifier = 0.90f,
			CollisionScale = 1.0f,
			bUseMotors = true,
			MotorStrength = 20000.0f,
			TimeToEnableRagdoll = 0.10f,
			TimeToBlendOutMotors = 0.40f,
			TimeToDisableMotors = 0.350f,
			TimeToBoneImpulse = 0.150f,
			TimeToFullRagdoll = 0.360f,
		};
		RagdollBones = new array<name>
		{
			(name)"Spine2",
			(name)"Neck",
			(name)"LeftShoulder",
			(name)"LeftArm",
			(name)"LeftForeArm",
			(name)"LeftHand",
			(name)"RightShoulder",
			(name)"RightArm",
			(name)"RightForeArm",
			(name)"RightHand",
			(name)"LeftUpLeg",
			(name)"LeftLeg",
			(name)"LeftFoot",
			(name)"RightUpLeg",
			(name)"RightLeg",
			(name)"RightFoot",
		};
		BodyFallHard = LoadAsset<SoundCue>("A_Bodyfalls.AI.Long_Med")/*Ref SoundCue'A_Bodyfalls.AI.Long_Med'*/;
		BodyFallMedium = LoadAsset<SoundCue>("A_Bodyfalls.AI.Short_Hard")/*Ref SoundCue'A_Bodyfalls.AI.Short_Hard'*/;
		BodyFallSoft = LoadAsset<SoundCue>("A_Bodyfalls.AI.Short_Med")/*Ref SoundCue'A_Bodyfalls.AI.Short_Med'*/;
		AccelRateNormal = 300;
		AccelRateFast = 1500;
		CertainSightRadius = 3000.0f;
		BurstDelayMin = 1.0f;
		BurstDelayMax = 1.50f;
		CurrentBurstMin = 3;
		CurrentBurstMax = 3;
		MainWeaponAmmo_Dropped = 15;
		MainWeaponAmmo_Disarmed = 30;
		MaxLookAhead = 180;
		DiffForMaxRotationSpeed = 25;
		MaxRotationSpeed = 25000;
		MaxRotationAcceleration = 120000;
		MinRotationAcceleration = 5000;
		RotationSpeedDiffForMaxAcceleration = 15000;
		TurnFrictionTweak = 6;
		RotationSpeedForMaxLean = 10000.0f;
		WalkToRun = 0.20f;
		RunToWalk = 0.50f;
		StandToWalk = 0.350f;
		DamageTime = 0.40f;
		BlockResetTime = 1.80f;
		AiProfileName = (name)"Default";
		AnimationRunSpeed = 500.0f;
		AnimationWalkSpeed = 200.0f;
		ActorCylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn.ActorCollisionCylinder'*/;
		Mesh3p = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0052DA8C
			SkeletalMesh = LoadAsset<SkeletalMesh>("CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer")/*Ref SkeletalMesh'CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn.MyLightEnvironment'*/,
			bOwnerNoSeeWithShadow = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn.TdPawnMesh3p' */;
		MoveManagerClass = ClassT<TdBotMoveManager>()/*Ref Class'TdBotMoveManager'*/;
		MoveClasses = new array< Core.ClassT<TdMove> >
		{
			default,
			ClassT<TdMove_Walking>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_BotMelee>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_180TurnInAir>(),
			ClassT<TdMove_LayOnGroundBot>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_DodgeJump>(),
			ClassT<TdMove_WallrunDodgeJump>(),
			ClassT<TdMove_StumbleBot>(),
			ClassT<TdMove_DisarmedBot>(),
			ClassT<TdMove_StepUp>(),
			ClassT<TdMove_RumpSlide>(),
			ClassT<TdMove_Interact>(),
			ClassT<TdMove_WallRun>(),
			ClassT<TdMove_BotStop>(),
			ClassT<TdMove_BotStartWalking>(),
			ClassT<TdMove_BotStartRunning>(),
			ClassT<TdMove_BotTurnRunning>(),
			ClassT<TdMove_BotTurnStanding>(),
			ClassT<TdMove_ExitCover>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_MeleeSlide>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimb180TurnJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_WallClimbDodgeJump>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_BotRoll>(),
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_MeleeWallrun>(),
			ClassT<TdMove_MeleeCrouch>(),
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			default,
			default,
			default,
			ClassT<TdMove_Disabled>(),
			ClassT<TdMove_FallingUncontrolled>(),
			ClassT<TdMove_SwingJump>(),
			ClassT<TdMove_AnimationPlayback>(),
			ClassT<TdMove_EnterCover>(),
			ClassT<TdMove_Cover>(),
			ClassT<TdMove_BotStumbleFalling>(),
			ClassT<TdMove_SoftLanding>(),
			default,
			default,
			ClassT<TdMove_AutoStepUp>(),
			ClassT<TdMove_MeleeAirAboveBot>(),
			default,
			ClassT<TdMove_BotBlock>(),
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
		SpeedMaxBaseVelocity = 200.0f;
		SpeedStrafeVelocityAccelerationFactor = 5.0f;
		SpeedEnergyDecelerationTime = 1.0f;
		SpeedEnergyDecelerationExponent = 4.0f;
		RegenerateDelay = 5.0f;
		RegenerateHealthPerSecond = 10.0f;
		MinTimeBeforeRemovingDeadBody = 20.0f;
		MaxTimeBeforeRemovingDeadBody = 240.0f;
		MaxJumpHeight = 80.0f;
		WalkableFloorZ = 0.60f;
		bCanCrouch = false;
		bJumpCapable = false;
		bCanFly = false;
		bIsFemale = false;
		bLOSHearing = false;
		HearingThreshold = 5000.0f;
		Alertness = 100.0f;
		SightRadius = 9000.0f;
		PeripheralVision = -0.20f;
		AirControl = 0.0f;
		SceneCapture = LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn.SceneCaptureCharacterComponent0'*/;
		DrawFrustum = LoadAsset<DrawFrustumComponent>("Default__TdBotPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn.DrawFrust0'*/;
		ControllerClass = ClassT<TdAIController>()/*Ref Class'TdAIController'*/;
		Mesh = new TdSkeletalMeshComponent
		{
			// Object Offset:0x0052DA8C
			SkeletalMesh = LoadAsset<SkeletalMesh>("CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer")/*Ref SkeletalMesh'CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer'*/,
			LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn.MyLightEnvironment'*/,
			bOwnerNoSeeWithShadow = false,
		}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn.TdPawnMesh3p' */;
		CylinderComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn.CollisionCylinder'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SceneCaptureCharacterComponent>("Default__TdBotPawn.SceneCaptureCharacterComponent0")/*Ref SceneCaptureCharacterComponent'Default__TdBotPawn.SceneCaptureCharacterComponent0'*/,
			LoadAsset<DrawFrustumComponent>("Default__TdBotPawn.DrawFrust0")/*Ref DrawFrustumComponent'Default__TdBotPawn.DrawFrust0'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn.CollisionCylinder'*/,
			LoadAsset<ArrowComponent>("Default__TdBotPawn.Arrow")/*Ref ArrowComponent'Default__TdBotPawn.Arrow'*/,
			LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn.MyLightEnvironment'*/,
			//Components[5]=
			new TdSkeletalMeshComponent
			{
				// Object Offset:0x0052DA8C
				SkeletalMesh = LoadAsset<SkeletalMesh>("CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer")/*Ref SkeletalMesh'CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer'*/,
				LightEnvironment = LoadAsset<DynamicLightEnvironmentComponent>("Default__TdBotPawn.MyLightEnvironment")/*Ref DynamicLightEnvironmentComponent'Default__TdBotPawn.MyLightEnvironment'*/,
				bOwnerNoSeeWithShadow = false,
			}/* Reference: TdSkeletalMeshComponent'Default__TdBotPawn.TdPawnMesh3p' */,
			LoadAsset<CylinderComponent>("Default__TdBotPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn.CollisionCylinder'*/,
			LoadAsset<CylinderComponent>("Default__TdBotPawn.ActorCollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn.ActorCollisionCylinder'*/,
		};
		CollisionComponent = LoadAsset<CylinderComponent>("Default__TdBotPawn.CollisionCylinder")/*Ref CylinderComponent'Default__TdBotPawn.CollisionCylinder'*/;
		RotationRate = new Rotator
		{
			Pitch=20000,
			Yaw=30000,
			Roll=20000
		};
	}
}
}