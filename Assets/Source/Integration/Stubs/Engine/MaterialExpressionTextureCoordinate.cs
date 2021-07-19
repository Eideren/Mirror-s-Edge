namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MaterialExpressionTextureCoordinate : MaterialExpression/* within Material*//*
		native
		collapsecategories
		hidecategories(Object)*/{
	public new Material Outer => base.Outer as Material;
	
	[Category] public int CoordinateIndex;
	[deprecated] public float Tiling;
	[Category] public float UTiling;
	[Category] public float VTiling;
	
	public MaterialExpressionTextureCoordinate()
	{
		// Object Offset:0x003592C5
		UTiling = 1.0f;
		VTiling = 1.0f;
	}
}
}