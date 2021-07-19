namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_CameraLookAt : SequenceAction/*
		native
		hidecategories(Object)*/{
	[Category] public bool bAffectCamera;
	[Category] public bool bAlwaysFocus;
	[deprecated] public bool bAdjustCamera;
	[Category] public bool bTurnInPlace;
	[Category] public bool bIgnoreTrace;
	[Category] public bool bAffectHead;
	[Category] public bool bToggleGodMode;
	[Category] public bool bLeaveCameraRotation;
	[Category] public bool bDisableInput;
	public bool bUsedTimer;
	[Category] public bool bCheckLineOfSight;
	[Category] public Object.Vector2D InterpSpeedRange;
	[Category] public Object.Vector2D InFocusFOV;
	[Category] public name FocusBoneName;
	[Category] public String TextDisplay;
	[Category] public float TotalTime;
	[Category] public float CameraFOV;
	[transient] public float RemainingTime;
	
	public SeqAct_CameraLookAt()
	{
		// Object Offset:0x003B9A93
		bAffectCamera = true;
		bTurnInPlace = true;
		bDisableInput = true;
		InterpSpeedRange = new Vector2D
		{
			X=3.0f,
			Y=3.0f
		};
		InFocusFOV = new Vector2D
		{
			X=1.0f,
			Y=1.0f
		};
		CameraFOV = -1.0f;
		bLatentExecution = true;
		OutputLinks = new array<SequenceOp.SeqOpOutputLink>
		{
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Out",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Finished",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Succeeded",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
			new SequenceOp.SeqOpOutputLink
			{
				Links = default,
				LinkDesc = "Failed",
				bHasImpulse = false,
				bDisabled = false,
				bDisabledPIE = false,
				LinkedOp = default,
				ActivateDelay = 0.0f,
				DrawY = 0,
				bHidden = false,
			},
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
				LinkDesc = "Focus",
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
		ObjClassVersion = 4;
		ObjName = "Look At";
		ObjCategory = "Camera";
	}
}
}