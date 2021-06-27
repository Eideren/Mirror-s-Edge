namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionConstantClamp : MaterialExpression/* within Material*//*
		native*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Input;
	public/*()*/ float Min;
	public/*()*/ float Max;
	
	public MaterialExpressionConstantClamp()
	{
		// Object Offset:0x00356B78
		Max = 1.0f;
	}
}
}