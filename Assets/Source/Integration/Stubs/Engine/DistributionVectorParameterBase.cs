namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DistributionVectorParameterBase : DistributionVectorConstant/*
		abstract
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object,Object)*/{
	[Category] public name ParameterName;
	[Category] public Object.Vector MinInput;
	[Category] public Object.Vector MaxInput;
	[Category] public Object.Vector MinOutput;
	[Category] public Object.Vector MaxOutput;
	[Category] [export] public StaticArray<DistributionFloatParameterBase.DistributionParamMode, DistributionFloatParameterBase.DistributionParamMode, DistributionFloatParameterBase.DistributionParamMode>/*[3]*/ ParamModes;
	
	public DistributionVectorParameterBase()
	{
		// Object Offset:0x0030E764
		MaxInput = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
		MaxOutput = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=1.0f
		};
	}
}
}