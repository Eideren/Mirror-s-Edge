namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionBumpOffset : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Coordinate;
	public MaterialExpression.ExpressionInput Height;
	public/*()*/ float HeightRatio;
	public/*()*/ float ReferencePlane;
	
	public MaterialExpressionBumpOffset()
	{
		// Object Offset:0x00356048
		HeightRatio = 0.050f;
		ReferencePlane = 0.50f;
	}
}
}