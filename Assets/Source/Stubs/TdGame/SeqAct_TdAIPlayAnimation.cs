namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdAIPlayAnimation : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public enum EPlayAnimationEndState 
	{
		PAES_None,
		PAES_Idle,
		PAES_Melee,
		PAES_Crouched,
		PAES_MAX
	};
	
	public/*(AnimationProperties)*/ name AnimationName;
	public/*(AnimationProperties)*/ array<TdAnimSet> AdditionalAnimSets;
	public/*(AnimationProperties)*/ float PlayRate;
	public/*(AnimationProperties)*/ float BlendInTime;
	public/*(AnimationProperties)*/ float BlendOutTime;
	public/*(AnimationProperties)*/ bool bUseRootMotion;
	public/*(AnimationProperties)*/ bool bUseRootRotation;
	public/*(AnimationProperties)*/ bool bLoopAnimation;
	public/*(PawnPlacement)*/ bool bDisableCollision;
	public/*(PawnPlacement)*/ bool bOverridePosition;
	public/*(PawnPlacement)*/ bool bOverrideRotation;
	public/*(Misc)*/ bool bForcePlay;
	public /*transient */bool bStartedAnimation;
	public /*transient */bool bStoppedAnimation;
	public /*deprecated */bool bScriptActivated;
	public/*(PawnPlacement)*/ Object.Vector PawnLocation;
	public/*(PawnPlacement)*/ Object.Rotator PawnRotation;
	public/*(Misc)*/ SeqAct_TdAIPlayAnimation.EPlayAnimationEndState FinalAnimationState;
	
	public override /*function */void Reset()
	{
	
	}
	
	public SeqAct_TdAIPlayAnimation()
	{
		// Object Offset:0x0049613B
		PlayRate = 1.0f;
		BlendInTime = 0.10f;
		BlendOutTime = 0.10f;
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Start Animation",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Stop Animation",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		ObjClassVersion = 8;
		ObjName = "Animation Playback";
		ObjCategory = "AI";
	}
}
}