namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SeqAct_TdGetStatCount : SequenceAction/*
		hidecategories(Object)*/{
	public enum EStatCompType 
	{
		STT_LargerThan,
		STT_SmallerThan,
		STT_EqualTo,
		STT_MAX
	};
	
	public/*()*/ SeqAct_TdRegisterStat.EAchievementStatsID StatId;
	public/*()*/ SeqAct_TdGetStatCount.EStatCompType ComparisonType;
	public/*()*/ int ComparisonValue;
	public int StatCount;
	public /*transient */TdPlayerController PlayerController;
	
	public override /*event */void Activated()
	{
	
	}
	
	public SeqAct_TdGetStatCount()
	{
		// Object Offset:0x0049B0CD
		bAutoActivateOutputLinks = false;
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
				ExpectedType = ClassT<SeqVar_Int>()/*Ref Class'SeqVar_Int'*/,
				LinkedVariables = default,
				LinkDesc = "ActualCount",
				LinkVar = (name)"None",
				PropertyName = (name)"StatCount",
				bWriteable = true,
				bHidden = false,
				MinVars = 1,
				MaxVars = 1,
				DrawX = 0,
				CachedProperty = default,
			},
		};
		ObjName = "GetStatCount";
		ObjCategory = "Td Achievements";
	}
}
}