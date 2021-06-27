namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionRotator : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Coordinate;
	public MaterialExpression.ExpressionInput Time;
	public/*()*/ float CenterX;
	public/*()*/ float CenterY;
	public/*()*/ float Speed;
	
	public MaterialExpressionRotator()
	{
		// Object Offset:0x0035889B
		CenterX = 0.50f;
		CenterY = 0.50f;
		Speed = 0.250f;
	}
}
}