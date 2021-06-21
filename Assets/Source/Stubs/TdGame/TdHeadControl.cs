namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdHeadControl : Object/*
		native*/{
	public enum EBlinkingState 
	{
		BS_None,
		BS_Closing,
		BS_Closed,
		BS_Opening,
		BS_MAX
	};
	
	public /*private */bool bInitialized;
	public /*private */bool bYawActivated;
	public /*private */bool bShouldUseEyelidControls;
	public /*private */bool bHasEyelids;
	public /*private */TdBotPawn myPawn;
	public /*private */TdSkelControlHeadAim HeadOffsetYawControl;
	public /*private */TdSkelControlHeadAim HeadOffsetPitchControl;
	public /*private */TdSkelControlHeadAim LeftUpEyelidControl;
	public /*private */TdSkelControlHeadAim LeftLowEyelidControl;
	public /*private */TdSkelControlHeadAim RightUpEyelidControl;
	public /*private */TdSkelControlHeadAim RightLowEyelidControl;
	public /*private */TdSkelControlHeadAim LeftUpEyelidControl2;
	public /*private */TdSkelControlHeadAim LeftLowEyelidControl2;
	public /*private */TdSkelControlHeadAim RightUpEyelidControl2;
	public /*private */TdSkelControlHeadAim RightLowEyelidControl2;
	public /*private */TdSkelControlLookAt EyeControl;
	public /*private */TdSkelControlLookAt LeftEyeControl;
	public /*private */TdSkelControlLookAt RightEyeControl;
	public /*private */float EyelidOffsetLower;
	public /*private */float EyelidOffsetUpper;
	public float BlinkTime;
	public /*private */float BlinkStartTime;
	public /*private */float ClosingTimeStamp;
	public /*private */float OpeningTimeStamp;
	public /*private */int ClosedFrames;
	public /*private */TdHeadControl.EBlinkingState BlinkingState;
	
	public virtual /*function */void Initialize(TdBotPawn OwnerPawn)
	{
		// stub
	}
	
	public virtual /*function */void ToggleEyelids()
	{
		// stub
	}
	
	public virtual /*function */void AddSpecialOutput(ref String Text)
	{
		// stub
	}
	
	public TdHeadControl()
	{
		// Object Offset:0x00551072
		bShouldUseEyelidControls = true;
		BlinkTime = 0.050f;
	}
}
}