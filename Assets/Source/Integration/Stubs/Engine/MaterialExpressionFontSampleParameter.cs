namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionFontSampleParameter : MaterialExpressionFontSample/* within Material*//*
		native
		collapsecategories
		hidecategories(Object,Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public/*()*/ name ParameterName;
	public /*const */Object.Guid ExpressionGUID;
	
	public MaterialExpressionFontSampleParameter()
	{
		// Object Offset:0x003578F5
		bIsParameterExpression = true;
	}
}
}