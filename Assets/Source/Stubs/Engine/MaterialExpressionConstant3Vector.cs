namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionConstant3Vector : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public/*()*/ float R;
	public/*()*/ float G;
	public/*()*/ float B;
	
}
}