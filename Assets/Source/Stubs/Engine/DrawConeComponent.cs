namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawConeComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ Object.Color ConeColor;
	public/*()*/ float ConeRadius;
	public/*()*/ float ConeAngle;
	public/*()*/ int ConeSides;
	
	public DrawConeComponent()
	{
		// Object Offset:0x00310459
		ConeColor = new Color
		{
			R=150,
			G=200,
			B=255,
			A=255
		};
		ConeRadius = 100.0f;
		ConeAngle = 44.0f;
		ConeSides = 16;
		HiddenGame = true;
	}
}
}