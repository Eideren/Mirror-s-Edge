namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionTextureSampleParameter : MaterialExpressionTextureSample/* within Material*//*
		abstract
		native
		collapsecategories
		hidecategories(Object,Object)*/{
	public new Material Outer => base.Outer as Material;
	
	[Category] public name ParameterName;
	[Const] public Object.Guid ExpressionGUID;
	
	public MaterialExpressionTextureSampleParameter()
	{
		// Object Offset:0x003593D0
		bIsParameterExpression = true;
	}
}
}