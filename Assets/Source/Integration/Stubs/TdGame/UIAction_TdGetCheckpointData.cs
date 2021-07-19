namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIAction_TdGetCheckpointData : UIAction/*
		native
		hidecategories(Object)*/{
	public name ResourceDataStoreName;
	[Category] public int CheckpointIndex;
	public String FriendlyName;
	public String Description;
	public String CheckpointName;
	public String ImageMarkup;
	
	public UIAction_TdGetCheckpointData()
	{
		// Object Offset:0x006D3022
		ResourceDataStoreName = (name)"TdGameData";
		bAutoTargetOwner = true;
		VariableLinks = new array<SequenceOp.SeqVarLink>
		{
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "FriendlyName",
				LinkVar = (name)"None",
				PropertyName = (name)"FriendlyName",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "Description",
				LinkVar = (name)"None",
				PropertyName = (name)"Description",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "CheckpointName",
				LinkVar = (name)"None",
				PropertyName = (name)"CheckpointName",
				bWriteable = true,
				bHidden = true,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
			new SequenceOp.SeqVarLink
			{
				ExpectedType = ClassT<SeqVar_String>()/*Ref Class'SeqVar_String'*/,
				LinkedVariables = default,
				LinkDesc = "ImageMarkup",
				LinkVar = (name)"None",
				PropertyName = (name)"ImageMarkup",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 255,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "TdGetCheckpointData";
		ObjCategory = "Takedown";
	}
}
}