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
	
	[Category("AnimationProperties")] public name AnimationName;
	[Category("AnimationProperties")] public array<TdAnimSet> AdditionalAnimSets;
	[Category("AnimationProperties")] public float PlayRate;
	[Category("AnimationProperties")] public float BlendInTime;
	[Category("AnimationProperties")] public float BlendOutTime;
	[Category("AnimationProperties")] public bool bUseRootMotion;
	[Category("AnimationProperties")] public bool bUseRootRotation;
	[Category("AnimationProperties")] public bool bLoopAnimation;
	[Category("PawnPlacement")] public bool bDisableCollision;
	[Category("PawnPlacement")] public bool bOverridePosition;
	[Category("PawnPlacement")] public bool bOverrideRotation;
	[Category("Misc")] public bool bForcePlay;
	[transient] public bool bStartedAnimation;
	[transient] public bool bStoppedAnimation;
	[deprecated] public bool bScriptActivated;
	[Category("PawnPlacement")] public Object.Vector PawnLocation;
	[Category("PawnPlacement")] public Object.Rotator PawnRotation;
	[Category("Misc")] public SeqAct_TdAIPlayAnimation.EPlayAnimationEndState FinalAnimationState;
	
	public override /*function */void Reset()
	{
		// stub
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