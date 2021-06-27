namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawSphereComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	public/*()*/ Object.Color SphereColor;
	public/*()*/ Material SphereMaterial;
	public/*()*/ float SphereRadius;
	public/*()*/ int SphereSides;
	public/*()*/ bool bDrawWireSphere;
	public/*()*/ bool bDrawLitSphere;
	
	public DrawSphereComponent()
	{
		// Object Offset:0x0028F2C2
		SphereColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		SphereRadius = 100.0f;
		SphereSides = 16;
		bDrawWireSphere = true;
		HiddenGame = true;
	}
}
}