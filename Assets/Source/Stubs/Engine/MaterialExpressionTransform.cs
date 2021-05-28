namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionTransform : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public enum EMaterialVectorCoordTransform 
	{
		TRANSFORM_World,
		TRANSFORM_View,
		TRANSFORM_Local,
		TRANSFORM_MAX
	};
	
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Input;
	public/*()*/ /*const */MaterialExpressionTransform.EMaterialVectorCoordTransform TransformType;
	
}
}