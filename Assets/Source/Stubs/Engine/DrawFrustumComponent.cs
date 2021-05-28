namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawFrustumComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	public/*()*/ Object.Color FrustumColor;
	public/*()*/ float FrustumAngle;
	public/*()*/ float FrustumAspectRatio;
	public/*()*/ float FrustumStartDist;
	public/*()*/ float FrustumEndDist;
	public/*()*/ Texture Texture;
	
	public DrawFrustumComponent()
	{
		// Object Offset:0x002B4462
		FrustumColor = new Color
		{
			R=255,
			G=0,
			B=255,
			A=255
		};
		FrustumAngle = 90.0f;
		FrustumAspectRatio = 1.3330f;
		FrustumStartDist = 100.0f;
		FrustumEndDist = 1000.0f;
		HiddenGame = true;
	}
}
}