namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionTextureSample : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	public/*()*/ Texture Texture;
	public MaterialExpression.ExpressionInput Coordinates;
	
	public MaterialExpressionTextureSample()
	{
		// Object Offset:0x00356E21
		bRealtimePreview = true;
	}
}
}