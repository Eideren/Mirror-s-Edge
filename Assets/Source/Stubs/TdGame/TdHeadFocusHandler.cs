namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHeadFocusHandler : Object/*
		native*/{
	public /*private */Actor FocusActor;
	public /*private */TdPawn FocusPlayer;
	public /*private */TdBotPawn AiPawn;
	public /*private */TdHeadControl HeadControl;
	public /*private */Object.Vector ActorOffset;
	public /*private */TdBubbleStack HeadFocusEnabledStack;
	public /*private */bool bIsActivated;
	public /*private */bool bHasBeenUpdatedThisFrame;
	public /*private */bool bAllowStateChanges;
	public /*private */Object.Vector PointOfInterest;
	public /*private */Object.Rotator HeadOffset;
	public /*private */int MinYawLimit;
	public /*private */int MaxYawLimit;
	public /*private */int MinPitchLimit;
	public /*private */int MaxPitchLimit;
	
	public virtual /*function */void Initialize(TdAIController Controller)
	{
		// stub
	}
	
	public virtual /*function */void AddSpecialOutput(ref String Text)
	{
		// stub
	}
	
	// Export UTdHeadFocusHandler::execTick(FFrame&, void* const)
	public virtual /*native function */void Tick(float DeltaTime)
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */bool IsActivated()
	{
		// stub
		return default;
	}
	
	public virtual /*event */void FocusOnActor(Actor Focus, Object.Vector Offset, name Identifier)
	{
		// stub
	}
	
	public virtual /*function */bool AllowStateChanges()
	{
		// stub
		return default;
	}
	
	public virtual /*function */void SetAllowStateChanges(bool iAllowStateChanges)
	{
		// stub
	}
	
	public virtual /*function */void PushEnabled(bool bEnable, name Identifier)
	{
		// stub
	}
	
	public virtual /*function */void PopEnabled(name Identifier)
	{
		// stub
	}
	
	public virtual /*private final function */void UpdateFocusState()
	{
		// stub
	}
	
	public virtual /*private final function */void ActivateHeadControl(bool flag)
	{
		// stub
	}
	
	public virtual /*function */void ToggleEyelids()
	{
		// stub
	}
	
	public TdHeadFocusHandler()
	{
		// Object Offset:0x00551BF1
		bAllowStateChanges = true;
	}
}
}