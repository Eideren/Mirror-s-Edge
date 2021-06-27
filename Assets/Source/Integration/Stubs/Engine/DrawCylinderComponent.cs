namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawCylinderComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	public/*()*/ Object.Color CylinderColor;
	public/*()*/ Material CylinderMaterial;
	public/*()*/ float CylinderRadius;
	public/*()*/ float CylinderTopRadius;
	public/*()*/ float CylinderHeight;
	public/*()*/ float CylinderHeightOffset;
	public/*()*/ int CylinderSides;
	public/*()*/ bool bDrawWireCylinder;
	public/*()*/ bool bDrawLitCylinder;
	
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