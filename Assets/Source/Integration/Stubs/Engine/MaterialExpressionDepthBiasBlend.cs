namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionDepthBiasBlend : MaterialExpressionTextureSample/* within Material*//*
		native
		collapsecategories
		hidecategories(Object,Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public/*()*/ bool bNormalize;
	public/*()*/ float BiasScale;
	public MaterialExpression.ExpressionInput Bias;
	
	public MaterialExpressionDepthBiasBlend()
	{
		// Object Offset:0x00356F3C
		BiasScale = 1.0f;
	}
}
}