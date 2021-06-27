namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdFakePostProcessEffect : SequenceAction/*
		hidecategories(Object)*/{
	public enum EFakedPPEffect 
	{
		FPPE_MeleeHit,
		FPPE_FallingToYourDeath,
		FPPE_MotionBlur,
		FPPE_SprintEffect,
		FPPE_MAX
	};
	
	public/*()*/ SeqAct_TdFakePostProcessEffect.EFakedPPEffect Effect;
	public/*()*/ float Amount;
	public/*()*/ Object.Vector Direction;
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public virtual /*function */TdPlayerController GetPlayerController()
	{
		// stub
		return default;
	}
	
	public SeqAct_TdFakePostProcessEffect()
	{
		// Object Offset:0x0049A27E
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Activate",
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
				LinkDesc = "Deactivate",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				DrawY = 0,
				bHidden = false,
				ActivateDelay = 0.0f,
			},
		};
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "PlayerPawn",
				LinkVar = (name)"None",
				PropertyName = (name)"Targets",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Fake post process effect";
		ObjCategory = "Takedown";
	}
}
}