namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DistributionFloatParameterBase : DistributionFloatConstant/*
		abstract
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	public enum DistributionParamMode 
	{
		DPM_Normal,
		DPM_Abs,
		DPM_Direct,
		DPM_MAX
	};
	
	[Category] public name ParameterName;
	[Category] public float MinInput;
	[Category] public float MaxInput;
	[Category] public float MinOutput;
	[Category] public float MaxOutput;
	[Category] public DistributionFloatParameterBase.DistributionParamMode ParamMode;
	
	public DistributionFloatParameterBase()
	{
		// Object Offset:0x0030E1A6
		MaxInput = 1.0f;
		MaxOutput = 1.0f;
	}
}
}