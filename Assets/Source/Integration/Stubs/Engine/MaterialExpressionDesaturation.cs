namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionDesaturation : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Input;
	public MaterialExpression.ExpressionInput Percent;
	[Category] public Object.LinearColor LuminanceFactors;
	
	public MaterialExpressionDesaturation()
	{
		// Object Offset:0x0035732D
		LuminanceFactors = new LinearColor
		{
			R=0.110f,
			G=0.590f,
			B=0.30f,
			A=0.0f
		};
	}
}
}