namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ArrowComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	[Category] public Object.Color ArrowColor;
	[Category] public float ArrowSize;
	
	public ArrowComponent()
	{
		// Object Offset:0x002A1F83
		ArrowColor = new Color
		{
			R=255,
			G=0,
			B=0,
			A=255
		};
		ArrowSize = 1.0f;
		HiddenGame = true;
		AlwaysLoadOnClient = false;
		AlwaysLoadOnServer = false;
	}
}
}