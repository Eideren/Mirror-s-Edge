namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdCoverController : Actor/*
		native
		config(AI)
		notplaceable
		hidecategories(Navigation)*/{
	public enum ECoverControllerAction 
	{
		ECover_None,
		ECover_Pending,
		ECover_Enter,
		ECover_Exit,
		ECover_Idle,
		ECover_AimFireLeft,
		ECover_AimFireRight,
		ECover_AimFireUp,
		ECover_MAX
	};
	
	public enum ECoverControllerPosition 
	{
		ECoverPosition_None,
		ECoverPosition_Center,
		ECoverPosition_Left,
		ECoverPosition_Right,
		ECoverPosition_MAX
	};
	
	public partial struct /*native */CoverInformation
	{
		public CoverLink.ECoverType CoverType;
		public Object.Vector Location;
		public Object.Vector Direction;
		public Object.Vector CoverLeftLocation;
		public Object.Vector CoverRightLocation;
		public Object.Rotator CoverLeftDirection;
		public Object.Rotator CoverRightDirection;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0053B6B0
	//		CoverType = CoverLink.ECoverType.CT_None;
	//		Location = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		Direction = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		CoverLeftLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		CoverRightLocation = new Vector
	//		{
	//			X=0.0f,
	//			Y=0.0f,
	//			Z=0.0f
	//		};
	//		CoverLeftDirection = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//		CoverRightDirection = new Rotator
	//		{
	//			Pitch=0,
	//			Yaw=0,
	//			Roll=0
	//		};
	//	}
	};
	
	[transient] public/*private*/ TdAIAnimationController AnimationController;
	[transient] public/*private*/ TdCoverController.ECoverControllerAction CurrentCoverAction;
	[transient] public/*private*/ TdCoverController.ECoverControllerPosition CurrentCoverPosition;
	[transient] public/*private*/ TdCoverController.ECoverControllerAction PendingCoverAction;
	[transient] public TdCoverController.ECoverControllerAction DebugCoverAction;
	[transient] public/*private*/ TdAIController AIController;
	[transient] public/*private*/ TdCoverController.CoverInformation Cover;
	[transient] public/*private*/ TdBotPawn AiPawn;
	[transient] public/*private*/ bool bSkipTick;
	[transient] public/*private*/ bool bUpdatePawnLocation;
	[transient] public/*private*/ bool bUpdatePawnRotation;
	[transient] public/*private*/ bool bWait;
	[transient] public/*private*/ bool bCoverExited;
	[transient] public/*private*/ bool bNeverUsed;
	[Category] [config] public bool bDebugCoverController;
	[transient] public/*private*/ Object.Vector PawnLocation;
	[transient] public/*private*/ Object.Rotator PawnRotation;
	[Category] [config] public float OnExitCoverTransitionTime;
	[Category] [config] public float OnCoverExitedTransitionTime;
	
	public virtual /*function */void Initialize(TdBotPawn myPawn)
	{
		// stub
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdCoverController_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdCoverController_Reset;
	public /*function */void TdCoverController_Reset()
	{
		// stub
	}
	
	public virtual /*function */TdAIAnimationController GetAnimationController()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdCoverController.ECoverControllerAction GetCurrentCoverAction()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool IsCoverExited()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void OnEnterCover(TdBotPawn BotPawn, TdCover CurrentCover)
	{
		// stub
	}
	
	public virtual /*function */void OnExitCover()
	{
		// stub
	}
	
	public virtual /*function */void OnCoverExited()
	{
		// stub
	}
	
	public virtual /*function */void SetCoverEntered()
	{
		// stub
	}
	
	public virtual /*function */void ForceExitCover()
	{
		// stub
	}
	
	public virtual /*function */void SetCoverExited()
	{
		// stub
	}
	
	public virtual /*function */TdCoverController.ECoverControllerAction GetCoverControllerAction()
	{
		// stub
		return default;
	}
	
	public virtual /*function */TdCoverController.ECoverControllerPosition GetCoverControllerPosition()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool AllowFocusRotation()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool CanFireWeapon()
	{
		// stub
		return default;
	}
	
	public override Tick_del eventTick { get => bfield_Tick ?? TdCoverController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdCoverController_Tick;
	public /*function */void TdCoverController_Tick(float DeltaTime)
	{
		// stub
	}
	
	public virtual /*function */void PrePerformCoverAction()
	{
		// stub
	}
	
	public virtual /*event */bool PerformCoverAction(TdCoverController.ECoverControllerAction CoverAction)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void CoverIdleAction()
	{
		// stub
	}
	
	public virtual /*function */void AimFireAction()
	{
		// stub
	}
	
	public virtual /*function */void AimFireLeftAction()
	{
		// stub
	}
	
	public virtual /*function */void AimFireRightAction()
	{
		// stub
	}
	
	public virtual /*function */void EnterCoverAction()
	{
		// stub
	}
	
	public virtual /*function */void ExitCoverAction()
	{
		// stub
	}
	
	public virtual /*function */void SetPawnLocation(Object.Vector iPawnLocation)
	{
		// stub
	}
	
	public virtual /*function */void SetPawnRotation(Object.Rotator iPawnRotation)
	{
		// stub
	}
	
	public virtual /*private final function */void SetPawnCoverPosition(TdCoverController.ECoverControllerPosition CoverPosition, /*optional */bool? _bIgnoreInPosition = default)
	{
		// stub
	}
	
	public virtual /*private final function */void SetControllerWaiting(float Time)
	{
		// stub
	}
	
	public virtual /*private final function */void ReleaseControllerWaiting()
	{
		// stub
	}
	
	public virtual /*private final function */bool IsControllerWaiting()
	{
		// stub
		return default;
	}
	
	public virtual /*private final function */int sign(int Value)
	{
		// stub
		return default;
	}
	
	public virtual /*function */void VerifyCoverValidity()
	{
		// stub
	}
	
	public virtual /*function */bool VerifyCoverPosition(Object.Vector CoverPosition)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool VerifyCoverDirection(Object.Rotator CoverDirection)
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool VerifyEnteredCoverValid()
	{
		// stub
		return default;
	}
	
	public virtual /*function */bool VerifyExitedCoverValid()
	{
		// stub
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		eventTick = null;
	
	}
	public TdCoverController()
	{
		// Object Offset:0x0053DBFD
		bCoverExited = true;
		bNeverUsed = true;
		OnExitCoverTransitionTime = 0.30f;
		OnCoverExitedTransitionTime = 0.30f;
	}
}
}