namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdIntoCutscene : SeqAct_Latent/*
		native
		hidecategories(Object)*/{
	[transient] public TdPlayerPawn PlayerPawn;
	[transient] public Actor DestinationActor;
	
	// Export USeqAct_TdIntoCutscene::execAbortScriptedMove(FFrame&, void* const)
	public virtual /*native function */void AbortScriptedMove()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	// Export USeqAct_TdIntoCutscene::execFinishScriptedMove(FFrame&, void* const)
	public virtual /*native function */void FinishScriptedMove()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
	public override /*event */void Activated()
	{
		// stub
	}
	
	public override /*event */bool Update(float DeltaTime)
	{
		// stub
		return default;
	}
	
	public SeqAct_TdIntoCutscene()
	{
		// Object Offset:0x0049CE4D
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
		ObjName = "Into Cutscene";
		ObjCategory = "Takedown";
	}
}
}