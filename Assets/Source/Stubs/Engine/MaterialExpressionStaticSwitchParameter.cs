namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionStaticSwitchParameter : MaterialExpressionParameter/* within Material*//*
		native
		collapsecategories
		hidecategories(Object,Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public/*()*/ bool DefaultValue;
	public/*()*/ bool ExtendedCaptionDisplay;
	public MaterialExpression.ExpressionInput A;
	public MaterialExpression.ExpressionInput B;
	public /*native const transient */Object.Pointer InstanceOverride;
	
}
}