namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionTransformPosition : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public enum EMaterialPositionTransform 
	{
		TRANSFORMPOS_World,
		TRANSFORMPOS_MAX
	};
	
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Input;
	[Category] [Const] public MaterialExpressionTransformPosition.EMaterialPositionTransform TransformType;
	
}
}