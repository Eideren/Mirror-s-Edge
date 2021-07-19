namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DrawQuadComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	[Category] public Texture Texture;
	[Category] public float Width;
	[Category] public float Height;
	
	public DrawQuadComponent()
	{
		// Object Offset:0x00310AD9
		Width = 100.0f;
		Height = 100.0f;
		HiddenGame = true;
	}
}
}