namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpriteComponent : PrimitiveComponent/*
		native
		editinlinenew
		collapsecategories
		noexport
		hidecategories(Object)*/{
	[Category] public Texture2D Sprite;
	[Category] public bool bIsScreenSizeScaled;
	[Category] public float ScreenSize;
	
	public SpriteComponent()
	{
		// Object Offset:0x0025DB55
		Sprite = LoadAsset<Texture2D>("EngineResources.S_Actor")/*Ref Texture2D'EngineResources.S_Actor'*/;
		ScreenSize = 0.10f;
	}
}
}