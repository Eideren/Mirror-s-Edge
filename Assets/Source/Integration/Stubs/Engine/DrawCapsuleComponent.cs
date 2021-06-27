namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawCapsuleComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	public/*()*/ Object.Color CapsuleColor;
	public/*()*/ Material CapsuleMaterial;
	public/*()*/ float CapsuleHeight;
	public/*()*/ float CapsuleRadius;
	public/*()*/ bool bDrawWireCapsule;
	public/*()*/ bool bDrawLitCapsule;
	
	public DrawCapsuleComponent()
	{
		// Object Offset:0x0031029A
		CapsuleColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		CapsuleHeight = 200.0f;
		CapsuleRadius = 200.0f;
		bDrawWireCapsule = true;
		HiddenGame = true;
	}
}
}