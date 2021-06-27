namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionDepthBiasedAlpha : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public/*()*/ bool bNormalize;
	public/*()*/ float BiasScale;
	public MaterialExpression.ExpressionInput Alpha;
	public MaterialExpression.ExpressionInput Bias;
	
	public MaterialExpressionDepthBiasedAlpha()
	{
		// Object Offset:0x0035708F
		BiasScale = 1.0f;
	}
}
}