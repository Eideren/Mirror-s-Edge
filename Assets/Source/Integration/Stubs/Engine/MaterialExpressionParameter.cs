namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionParameter : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	[Category] public name ParameterName;
	[Const] public Object.Guid ExpressionGUID;
	
	public MaterialExpressionParameter()
	{
		// Object Offset:0x003584BC
		bIsParameterExpression = true;
	}
}
}