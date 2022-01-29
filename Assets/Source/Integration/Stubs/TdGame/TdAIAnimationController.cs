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
	
	[transient] public/*private*/ TdBotPawn AiPawn;
	[transient] public/*private*/ TdAIController AIController;
	[export, editinline, transient] public/*private*/ TdSkeletalMeshComponent SkeletalComponent;
	[transient] public/*private*/ TdAIAnimationController.EAiAnimationState AnimationState;
	[transient] public/*private*/ TdAIAnimationController.EAimState AimState;
	[transient] public/*private*/ TdAIAnimationController.ECoverState CoverState;
	[transient] public/*private*/ TdAIAnimationController.ECoverState PendingCoverState;
	[transient] public/*private*/ TdAIAnimationController.ECoverDirectionState CoverDirection;
	[transient] public/*private*/ float AimStateBlendValue;
	[transient] public/*private*/ bool bPendingLegRotationState;
	[transient] public/*private*/ bool bIsInCover;
	[transient] public/*private*/ bool bUseLazySpring;
	[transient] public/*private*/ bool bPendingLazySpringState;
	[transient] public/*private*/ float ReloadPlaybackRate;
	[transient] public/*private*/ name CoverAnimationSequenceName;
	
	// Export UTdAIAnimationController::execGetAnimationState(FFrame&, void* const)
	public virtual /*native function */TdAIAnimationController.EAiAnimationState GetAnimationState()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execGetAimState(FFrame&, void* const)
	public virtual /*native function */TdAIAnimationController.EAimState GetAimState()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execGetAimStateBlendValue(FFrame&, void* const)
	public virtual /*native function */float GetAimStateBlendValue()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execIsBusyMelee(FFrame&, void* const)
	public virtual /*native function */bool IsBusyMelee()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execIsBusyCrouching(FFrame&, void* const)
	public virtual /*native function */bool IsBusyCrouching()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execIsInMeleeState(FFrame&, void* const)
	public virtual /*native function */bool IsInMeleeState()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execIsInCrouchState(FFrame&, void* const)
	public virtual /*native function */bool IsInCrouchState()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execUseLazySpring(FFrame&, void* const)
	public virtual /*native function */bool UseLazySpring()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execIsInCover(FFrame&, void* const)
	public virtual /*native function */bool IsInCover()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execGetCoverStateNative(FFrame&, void* const)
	public virtual /*native function */TdAIAnimationController.ECoverState GetCoverStateNative()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdAIAnimationController::execGetCoverDirectionNative(FFrame&, void* const)
	public virtual /*native function */CoverLink.ECoverDirection GetCoverDirectionNative()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */void Init(TdSkeletalMeshComponent Component)
	{
		// stub
	}
	
	public virtual /*function */void AssignController(TdAIController iAiController, TdBotPawn iAiPawn)
	{
		// stub
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdAIAnimationController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdAIAnimationController_Tick;
	public /*function */void TdAIAnimationController_Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*simulated event */bool IsPlayingCoverAnimation()
	{
		// stub
		return default;
	}
	
	public virtual /*simulated event */bool IsPlayingCustomAnimation()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool StopCoverAnimation(/*optional */float? _StopTime = default)
	{
		// stub
		return default;
	}
	
	public virtual /*function */AnimNodeSequence GetCoverAnimation()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PlayCoverAnimation(TdAIAnimationController.ECoverAnimation CoverAnimation, TdAIAnimationController.ECoverDirectionState CoverAnimationDirectionState, CoverLink.ECoverType CoverType, /*optional */bool? _Short = default)
	{
		// stub
	}
	
	public virtual /*function */void SetCoverAnimationSequenceName(name AnimationName)
	{
		// stub
	}
	
	public virtual /*function */name GetCoverAnimationSequenceName()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void CoverAnimationOnCustomAnimEnd(AnimNodeSequence SequenceNode, float PlayedTime, float ExcessTime)
	{
		// stub
	}
	
	public virtual /*function */void CoverAnimationOnCeaseRelevantRootMotion(AnimNodeSequence SequenceNode)
	{
		// stub
	}
	
	public virtual /*function */void SetCoverState(TdAIAnimationController.ECoverState iCoverState)
	{
		// stub
	}
	
	public virtual /*function */TdAIAnimationController.ECoverState GetCoverState()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetPendingCoverState(TdAIAnimationController.ECoverState iPendingCoverState)
	{
		// stub
	}
	
	public virtual /*function */TdAIAnimationController.ECoverState GetPendingCoverState()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void UpdateCoverState()
	{
		// stub
	}
	
	public virtual /*function */void SetCoverDirection(TdAIAnimationController.ECoverDirectionState iCoverDirection)
	{
		// stub
	}
	
	public virtual /*function */TdAIAnimationController.ECoverDirectionState GetCoverDirection()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void StartAimFire(TdAIAnimationController.ECoverDirectionState CoverAnimationDirectionState, CoverLink.ECoverType CoverType)
	{
		// stub
	}
	
	public virtual /*function */void StopAimFire(TdAIAnimationController.ECoverDirectionState CoverAnimationDirectionState, CoverLink.ECoverType CoverType)
	{
		// stub
	}
	
	public virtual /*function */name GetFireAnimationName()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PlayFireAnimation()
	{
		// stub
	}
	
	public virtual /*function */void PlayReloadAnimation()
	{
		// stub
	}
	
	public virtual /*function */float GetReloadPlaybackRate()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void PlayCustomCannedAnimation(name AnimationName)
	{
		// stub
	}
	
	public virtual /*function */void PlayFaceAnimation(name AnimName, /*optional */bool? _bLooping = default)
	{
		// stub
	}
	
	public virtual /*function */void StopFaceAnimation()
	{
		// stub
	}
	
	public virtual /*function */AnimNodeAimOffset GetActiveAimNode()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetAimState(TdAIAnimationController.EAimState iAimState, float BlendTime, bool bInstantRotationUpdate)
	{
		// stub
	}
	
	public virtual /*function */void UpdateLegRotation()
	{
		// stub
	}
	
	public virtual /*function */bool CanFireWeapon()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */bool IsWalking()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void TimerSetUseLazySpring()
	{
		// stub
	}
	
	public virtual /*function */void SetUseLazySpring(bool bUse, /*optional */float? _Time = default)
	{
		// stub
	}
	
	public virtual /*function */void OnCoverEntered()
	{
		// stub
	}
	
	public virtual /*function */void OnCoverExited()
	{
		// stub
	}
	
	public virtual /*function */void ResetAnimationState()
	{
		// stub
	}
	
	public virtual /*function */void ClearAnimationState()
	{
		// stub
	}
	
	public virtual /*function */void SetMeleeState()
	{
		// stub
	}
	
	public virtual /*private final function */void ReleaseMeleeState()
	{
		// stub
	}
	
	public virtual /*private final function */void OnSetMelee()
	{
		// stub
	}
	
	public virtual /*private final function */void OnReleaseMelee()
	{
		// stub
	}
	
	public virtual /*function */void SetCrouchState()
	{
		// stub
	}
	
	public virtual /*private final function */void ReleaseCrouchState()
	{
		// stub
	}
	
	public virtual /*private final function */void OnSetCrouch()
	{
		// stub
	}
	
	public virtual /*private final function */void OnReleaseCrouch()
	{
		// stub
	}
	protected override void RestoreDefaultFunction()
	{
		eventTick = null;
	
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