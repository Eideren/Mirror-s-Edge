namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDrawArcComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[transient] public Object.Color ArcColor;
	[transient] public float ArcRadius;
	[transient] public int ArcRes;
	[transient] public float ArcAngle;
	
	public TdDrawArcComponent()
	{
		// Object Offset:0x00543441
		ArcColor = new Color
		{
			R=255,
			G=128,
			B=0,
			A=255
		};
		ArcRadius = 128.0f;
		ArcRes = 16;
		ArcAngle = 175.0f;
		HiddenGame = true;
	}
}
}