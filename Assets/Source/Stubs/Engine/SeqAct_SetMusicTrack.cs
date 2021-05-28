namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_SetMusicTrack : SequenceAction/*
		native
		hidecategories(Object)*/{
	public/*()*/ name TrackBankName;
	
	public SeqAct_SetMusicTrack()
	{
		// Object Offset:0x003CE51A
		InputLinks = new array<SequenceOp.SeqOpInputLink>
		{
			new SequenceOp.SeqOpInputLink
			{
				LinkDesc = "Set Music Track",
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
				ExpectedType = ClassT<SeqVar_MusicTrackBank>()/*Ref Class'SeqVar_MusicTrackBank'*/,
				LinkedVariables = default,
				LinkDesc = "MusicTrackBank",
				LinkVar = (name)"None",
				PropertyName = (name)"Targets",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_MusicTrack>()/*Ref Class'SeqVar_MusicTrack'*/,
				LinkedVariables = default,
				LinkDesc = "MusicTrack",
				LinkVar = (name)"None",
				PropertyName = (name)"None",
				bWriteable = false,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "Set Music Track";
		ObjCategory = "Sound";
	}
}
}