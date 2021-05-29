namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIAnimationController : Actor/*
		native
		notplaceable
		hidecategories(Navigation)*/{
	public enum EBodyPart 
	{
		EBP_Full,
		EBP_Upper,
		EBP_Weapon,
		EBP_MAX
	};
	
	public enum ECoverAnimation 
	{
		ECoverAnimationStartAimFire,
		ECoverAnimationStopAimFire,
		ECoverAnimation_MAX
	};
	
	public enum ECoverDirectionState 
	{
		ECDS_None,
		ECDS_Right,
		ECDS_Left,
		ECDS_Up,
		ECDS_MAX
	};
	
	public enum ECoverState 
	{
		ECS_None,
		ECS_CoverIdle,
		ECS_CoverAimFire,
		ECS_MAX
	};
	
	public enum EAiAnimationState 
	{
		EAAS_None,
		EAAS_Crouch,
		EAAS_Melee,
		EAAS_MAX
	};
	
	public enum EAimState 
	{
		EAimState_None,
		EAimState_Normal,
		EAimState_Cover,
		EAimState_MAX
	};
	
	public /*private transient */TdBotPawn AiPawn;
	public /*private transient */TdAIController AIController;
	public /*private export editinline transient */TdSkeletalMeshComponent SkeletalComponent;
	public /*private transient */TdAIAnimationController.EAiAnimationState AnimationState;
	public /*private transient */TdAIAnimationController.EAimState AimState;
	public /*private transient */TdAIAnimationController.ECoverState CoverState;
	public /*private transient */TdAIAnimationController.ECoverState PendingCoverState;
	public /*private transient */TdAIAnimationController.ECoverDirectionState CoverDirection;
	public /*private transient */float AimStateBlendValue;
	public /*private transient */bool bPendingLegRotationState;
	public /*private transient */bool bIsInCover;
	public /*private transient */bool bUseLazySpring;
	public /*private transient */bool bPendingLazySpringState;
	public /*private transient */float ReloadPlaybackRate;
	public /*private transient */name CoverAnimationSequenceName;
	
	// Export UTdAIAnimationController::execGetAnimationState(FFrame&, void* const)
	public virtual /*native function */TdAIAnimationController.EAiAnimationState GetAnimationState()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execGetAimState(FFrame&, void* const)
	public virtual /*native function */TdAIAnimationController.EAimState GetAimState()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execGetAimStateBlendValue(FFrame&, void* const)
	public virtual /*native function */float GetAimStateBlendValue()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execIsBusyMelee(FFrame&, void* const)
	public virtual /*native function */bool IsBusyMelee()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execIsBusyCrouching(FFrame&, void* const)
	public virtual /*native function */bool IsBusyCrouching()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execIsInMeleeState(FFrame&, void* const)
	public virtual /*native function */bool IsInMeleeState()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execIsInCrouchState(FFrame&, void* const)
	public virtual /*native function */bool IsInCrouchState()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execUseLazySpring(FFrame&, void* const)
	public virtual /*native function */bool UseLazySpring()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execIsInCover(FFrame&, void* const)
	public virtual /*native function */bool IsInCover()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execGetCoverStateNative(FFrame&, void* const)
	public virtual /*native function */TdAIAnimationController.ECoverState GetCoverStateNative()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdAIAnimationController::execGetCoverDirectionNative(FFrame&, void* const)
	public virtual /*native function */CoverLink.ECoverDirection GetCoverDirectionNative()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */void Init(TdSkeletalMeshComponent Component)
	{
	
	}
	
	public virtual /*function */void AssignController(TdAIController iAiController, TdBotPawn iAiPawn)
	{
	
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdAIAnimationController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAIAnimationController_Tick;
	public /*function */void TdAIAnimationController_Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*simulated event */bool IsPlayingCoverAnimation()
	{
	
		return default;
	}
	
	public virtual /*simulated event */bool IsPlayingCustomAnimation()
	{
	
		return default;
	}
	
	public virtual /*function */bool StopCoverAnimation(/*optional */float? _StopTime = default)
	{
	
		return default;
	}
	
	public virtual /*function */AnimNodeSequence GetCoverAnimation()
	{
	
		return default;
	}
	
	public virtual /*function */void PlayCoverAnimation(TdAIAnimationController.ECoverAnimation CoverAnimation, TdAIAnimationController.ECoverDirectionState CoverAnimationDirectionState, CoverLink.ECoverType CoverType, /*optional */bool? _Short = default)
	{
	
	}
	
	public virtual /*function */void SetCoverAnimationSequenceName(name AnimationName)
	{
	
	}
	
	public virtual /*function */name GetCoverAnimationSequenceName()
	{
	
		return default;
	}
	
	public virtual /*event */void CoverAnimationOnCustomAnimEnd(AnimNodeSequence SequenceNode, float PlayedTime, float ExcessTime)
	{
	
	}
	
	public virtual /*function */void CoverAnimationOnCeaseRelevantRootMotion(AnimNodeSequence SequenceNode)
	{
	
	}
	
	public virtual /*function */void SetCoverState(TdAIAnimationController.ECoverState iCoverState)
	{
	
	}
	
	public virtual /*function */TdAIAnimationController.ECoverState GetCoverState()
	{
	
		return default;
	}
	
	public virtual /*function */void SetPendingCoverState(TdAIAnimationController.ECoverState iPendingCoverState)
	{
	
	}
	
	public virtual /*function */TdAIAnimationController.ECoverState GetPendingCoverState()
	{
	
		return default;
	}
	
	public virtual /*function */void UpdateCoverState()
	{
	
	}
	
	public virtual /*function */void SetCoverDirection(TdAIAnimationController.ECoverDirectionState iCoverDirection)
	{
	
	}
	
	public virtual /*function */TdAIAnimationController.ECoverDirectionState GetCoverDirection()
	{
	
		return default;
	}
	
	public virtual /*function */void StartAimFire(TdAIAnimationController.ECoverDirectionState CoverAnimationDirectionState, CoverLink.ECoverType CoverType)
	{
	
	}
	
	public virtual /*function */void StopAimFire(TdAIAnimationController.ECoverDirectionState CoverAnimationDirectionState, CoverLink.ECoverType CoverType)
	{
	
	}
	
	public virtual /*function */name GetFireAnimationName()
	{
	
		return default;
	}
	
	public virtual /*function */void PlayFireAnimation()
	{
	
	}
	
	public virtual /*function */void PlayReloadAnimation()
	{
	
	}
	
	public virtual /*function */float GetReloadPlaybackRate()
	{
	
		return default;
	}
	
	public virtual /*function */void PlayCustomCannedAnimation(name AnimationName)
	{
	
	}
	
	public virtual /*function */void PlayFaceAnimation(name AnimName, /*optional */bool? _bLooping = default)
	{
	
	}
	
	public virtual /*function */void StopFaceAnimation()
	{
	
	}
	
	public virtual /*function */AnimNodeAimOffset GetActiveAimNode()
	{
	
		return default;
	}
	
	public virtual /*function */void SetAimState(TdAIAnimationController.EAimState iAimState, float BlendTime, bool bInstantRotationUpdate)
	{
	
	}
	
	public virtual /*function */void UpdateLegRotation()
	{
	
	}
	
	public virtual /*function */bool CanFireWeapon()
	{
	
		return default;
	}
	
	public virtual /*private final function */bool IsWalking()
	{
	
		return default;
	}
	
	public virtual /*function */void TimerSetUseLazySpring()
	{
	
	}
	
	public virtual /*function */void SetUseLazySpring(bool bUse, /*optional */float? _Time = default)
	{
	
	}
	
	public virtual /*function */void OnCoverEntered()
	{
	
	}
	
	public virtual /*function */void OnCoverExited()
	{
	
	}
	
	public virtual /*function */void ResetAnimationState()
	{
	
	}
	
	public virtual /*function */void ClearAnimationState()
	{
	
	}
	
	public virtual /*function */void SetMeleeState()
	{
	
	}
	
	public virtual /*private final function */void ReleaseMeleeState()
	{
	
	}
	
	public virtual /*private final function */void OnSetMelee()
	{
	
	}
	
	public virtual /*private final function */void OnReleaseMelee()
	{
	
	}
	
	public virtual /*function */void SetCrouchState()
	{
	
	}
	
	public virtual /*private final function */void ReleaseCrouchState()
	{
	
	}
	
	public virtual /*private final function */void OnSetCrouch()
	{
	
	}
	
	public virtual /*private final function */void OnReleaseCrouch()
	{
	
	}
	protected override void RestoreDefaultFunction()
	{
		Tick = null;
	
	}
	public TdAIAnimationController()
	{
		// Object Offset:0x004E7A35
		AimState = TdAIAnimationController.EAimState.EAimState_Normal;
		bUseLazySpring = true;
		ReloadPlaybackRate = 1.0f;
	}
}
}