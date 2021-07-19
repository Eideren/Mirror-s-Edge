namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawBoxComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	[Category] public Object.Color BoxColor;
	[Category] public Material BoxMaterial;
	[Category] public Object.Vector BoxExtent;
	[Category] public bool bDrawWireBox;
	[Category] public bool bDrawLitBox;
	
	public DrawBoxComponent()
	{
		// Object Offset:0x0031008B
		BoxColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		BoxExtent = new Vector
		{
			X=200.0f,
			Y=200.0f,
			Z=200.0f
		};
		bDrawWireBox = true;
		HiddenGame = true;
	}
}
}