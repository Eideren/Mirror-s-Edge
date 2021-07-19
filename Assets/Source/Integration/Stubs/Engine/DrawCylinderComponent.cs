namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawCylinderComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	[Category] public Object.Color CylinderColor;
	[Category] public Material CylinderMaterial;
	[Category] public float CylinderRadius;
	[Category] public float CylinderTopRadius;
	[Category] public float CylinderHeight;
	[Category] public float CylinderHeightOffset;
	[Category] public int CylinderSides;
	[Category] public bool bDrawWireCylinder;
	[Category] public bool bDrawLitCylinder;
	
	public DrawCylinderComponent()
	{
		// Object Offset:0x003106F8
		CylinderColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		CylinderRadius = 100.0f;
		CylinderTopRadius = 100.0f;
		CylinderHeight = 100.0f;
		CylinderSides = 16;
		bDrawWireCylinder = true;
		HiddenGame = true;
	}
}
}