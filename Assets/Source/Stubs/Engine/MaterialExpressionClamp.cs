namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionClamp : MaterialExpression/* within Material*//*
		native*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Input;
	public MaterialExpression.ExpressionInput Min;
	public MaterialExpression.ExpressionInput Max;
	
}
}