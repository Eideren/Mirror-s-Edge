namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionStaticComponentMaskParameter : MaterialExpressionParameter/* within Material*//*
		native
		collapsecategories
		hidecategories(Object,Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public MaterialExpression.ExpressionInput Input;
	public/*()*/ bool DefaultR;
	public/*()*/ bool DefaultG;
	public/*()*/ bool DefaultB;
	public/*()*/ bool DefaultA;
	public /*native const transient */Object.Pointer InstanceOverride;
	
}
}