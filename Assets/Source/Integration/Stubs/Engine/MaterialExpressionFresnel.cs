namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionFresnel : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	[Category] public float Exponent;
	public MaterialExpression.ExpressionInput Normal;
	
	public MaterialExpressionFresnel()
	{
		// Object Offset:0x00357A93
		Exponent = 3.0f;
	}
}
}