namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdScriptedMove : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	public /*transient */TdPlayerPawn PlayerPawn;
	public /*transient */Actor DestinationActor;
	public/*(Offset)*/ Object.Vector WorldTranslationOffset;
	public/*(Offset)*/ Object.Rotator WorldRotationOffset;
	
	// Export USeqAct_TdScriptedMove::execAbortScriptedMove(FFrame&, void* const)
	public virtual /*native function */void AbortScriptedMove()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	// Export USeqAct_TdScriptedMove::execFinishScriptedMove(FFrame&, void* const)
	public virtual /*native function */void FinishScriptedMove()
	{
		 // #warning NATIVE FUNCTION !
		// stub
	}
	
	public virtual /*function */int DeltaAngle(int AngleOne, int AngleTwo)
	{
		// stub
		return default;
	}
	
	public override /*event */bool Update(float DeltaTime)
	{
		// stub
		return default;
	}
	
	public SeqAct_TdScriptedMove()
	{
		// Object Offset:0x0049EFFF
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Target",
				LinkVar = (name)"None",
				PropertyName = (name)"Targets",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_Object>()/*Ref Class'SeqVar_Object'*/,
				LinkedVariables = default,
				LinkDesc = "Destination",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Scripted Move";
		ObjCategory = "Takedown";
	}
}
}