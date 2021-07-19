namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionDepthBiasedBlend : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	[Category] public bool bNormalize;
	[Category] public float BiasScale;
	public MaterialExpression.ExpressionInput RGB;
	public MaterialExpression.ExpressionInput Alpha;
	public MaterialExpression.ExpressionInput Bias;
	
	public MaterialExpressionDepthBiasedBlend()
	{
		// Object Offset:0x0035720A
		BiasScale = 1.0f;
	}
}
}