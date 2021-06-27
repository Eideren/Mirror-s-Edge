namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetCameraTarget : SequenceAction/*
		native
		hidecategories(Object)*/{
	public /*transient */Actor CameraTarget;
	public/*()*/ /*const */Camera.ViewTargetTransitionParams TransitionParams;
	
	public SeqAct_SetCameraTarget()
	{
		// Object Offset:0x003CC333
		TransitionParams = new Camera.ViewTargetTransitionParams
		{
			BlendTime = 0.0f,
			BlendFunction = Camera.EViewTargetBlendFunction.VTBlend_Cubic,
			BlendExp = 2.0f,
		};
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
				LinkDesc = "Cam Target",
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
		ObjClassVersion = 2;
		ObjName = "Set Camera Target";
		ObjCategory = "Camera";
	}
}
}