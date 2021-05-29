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
	
	public /*private transient */TdAIAnimationController AnimationController;
	public /*private transient */TdCoverController.ECoverControllerAction CurrentCoverAction;
	public /*private transient */TdCoverController.ECoverControllerPosition CurrentCoverPosition;
	public /*private transient */TdCoverController.ECoverControllerAction PendingCoverAction;
	public /*transient */TdCoverController.ECoverControllerAction DebugCoverAction;
	public /*private transient */TdAIController AIController;
	public /*private transient */TdCoverController.CoverInformation Cover;
	public /*private transient */TdBotPawn AiPawn;
	public /*private transient */bool bSkipTick;
	public /*private transient */bool bUpdatePawnLocation;
	public /*private transient */bool bUpdatePawnRotation;
	public /*private transient */bool bWait;
	public /*private transient */bool bCoverExited;
	public /*private transient */bool bNeverUsed;
	public/*()*/ /*config */bool bDebugCoverController;
	public /*private transient */Object.Vector PawnLocation;
	public /*private transient */Object.Rotator PawnRotation;
	public/*()*/ /*config */float OnExitCoverTransitionTime;
	public/*()*/ /*config */float OnCoverExitedTransitionTime;
	
	public virtual /*function */void Initialize(TdBotPawn myPawn)
	{
	
	}
	
	public override Reset_del Reset { get => bfield_Reset ?? TdCoverController_Reset; set => bfield_Reset = value; } Reset_del bfield_Reset;
	public override Reset_del global_Reset => TdCoverController_Reset;
	public /*function */void TdCoverController_Reset()
	{
	
	}
	
	public virtual /*function */TdAIAnimationController GetAnimationController()
	{
	
		return default;
	}
	
	public virtual /*function */TdCoverController.ECoverControllerAction GetCurrentCoverAction()
	{
	
		return default;
	}
	
	public virtual /*function */bool IsCoverExited()
	{
	
		return default;
	}
	
	public virtual /*function */void OnEnterCover(TdBotPawn BotPawn, TdCover CurrentCover)
	{
	
	}
	
	public virtual /*function */void OnExitCover()
	{
	
	}
	
	public virtual /*function */void OnCoverExited()
	{
	
	}
	
	public virtual /*function */void SetCoverEntered()
	{
	
	}
	
	public virtual /*function */void ForceExitCover()
	{
	
	}
	
	public virtual /*function */void SetCoverExited()
	{
	
	}
	
	public virtual /*function */TdCoverController.ECoverControllerAction GetCoverControllerAction()
	{
	
		return default;
	}
	
	public virtual /*function */TdCoverController.ECoverControllerPosition GetCoverControllerPosition()
	{
	
		return default;
	}
	
	public virtual /*function */bool AllowFocusRotation()
	{
	
		return default;
	}
	
	public virtual /*function */bool CanFireWeapon()
	{
	
		return default;
	}
	
	public override Tick_del Tick { get => bfield_Tick ?? TdCoverController_Tick; set => bfield_Tick = value; } Tick_del bfield_Tick;
	public override Tick_del global_Tick => TdCoverController_Tick;
	public /*function */void TdCoverController_Tick(float DeltaTime)
	{
	
	}
	
	public virtual /*function */void PrePerformCoverAction()
	{
	
	}
	
	public virtual /*event */bool PerformCoverAction(TdCoverController.ECoverControllerAction CoverAction)
	{
	
		return default;
	}
	
	public virtual /*function */void CoverIdleAction()
	{
	
	}
	
	public virtual /*function */void AimFireAction()
	{
	
	}
	
	public virtual /*function */void AimFireLeftAction()
	{
	
	}
	
	public virtual /*function */void AimFireRightAction()
	{
	
	}
	
	public virtual /*function */void EnterCoverAction()
	{
	
	}
	
	public virtual /*function */void ExitCoverAction()
	{
	
	}
	
	public virtual /*function */void SetPawnLocation(Object.Vector iPawnLocation)
	{
	
	}
	
	public virtual /*function */void SetPawnRotation(Object.Rotator iPawnRotation)
	{
	
	}
	
	public virtual /*private final function */void SetPawnCoverPosition(TdCoverController.ECoverControllerPosition CoverPosition, /*optional */bool? _bIgnoreInPosition = default)
	{
	
	}
	
	public virtual /*private final function */void SetControllerWaiting(float Time)
	{
	
	}
	
	public virtual /*private final function */void ReleaseControllerWaiting()
	{
	
	}
	
	public virtual /*private final function */bool IsControllerWaiting()
	{
	
		return default;
	}
	
	public virtual /*private final function */int sign(int Value)
	{
	
		return default;
	}
	
	public virtual /*function */void VerifyCoverValidity()
	{
	
	}
	
	public virtual /*function */bool VerifyCoverPosition(Object.Vector CoverPosition)
	{
	
		return default;
	}
	
	public virtual /*function */bool VerifyCoverDirection(Object.Rotator CoverDirection)
	{
	
		return default;
	}
	
	public virtual /*function */bool VerifyEnteredCoverValid()
	{
	
		return default;
	}
	
	public virtual /*function */bool VerifyExitedCoverValid()
	{
	
		return default;
	}
	protected override void RestoreDefaultFunction()
	{
		Reset = null;
		Tick = null;
	
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