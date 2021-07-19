namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdPlaySound : SeqAct_PlaySound/*
		native
		hidecategories(Object)*/{
	[Category] public float LowPassMultiplier;
	[Category] public float OcclusionCheckInterval;
	[Category] public float OcclusionVolumeDuckLevel;
	[Category] public float OcclusionFilterDuckLevel;
	[Category] public float OcclusionFadeTime;
	[Category] public bool MuteVoiceOvers;
	[Category] public bool bDebugDraw;
	[Category] public array<Object.Vector> Offset;
	
	public SeqAct_TdPlaySound()
	{
		// Object Offset:0x0049E330
		LowPassMultiplier = 1.0f;
		OcclusionVolumeDuckLevel = 0.30f;
		OcclusionFilterDuckLevel = 0.30f;
		OcclusionFadeTime = 1.0f;
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
				ExpectedType = ClassT<SeqVar_Vector>()/*Ref Class'SeqVar_Vector'*/,
				LinkedVariables = default,
				LinkDesc = "Offset",
				LinkVar = (name)"None",
				PropertyName = (name)"Offset",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Td Play Sound";
	}
}
}