namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdLOIRenderingComponent : PrimitiveComponent/*
		native*/{
	public/*()*/ Texture2D Sprite;
	public/*()*/ bool bIsScreenSizeScaled;
	public/*()*/ float ScreenSize;
	public /*transient */StaticMeshActor ActualOwner;
	
	public TdLOIRenderingComponent()
	{
		// Object Offset:0x003EDB00
		Sprite = LoadAsset<Texture2D>("TdEditorResources.LoiIcon")/*Ref Texture2D'TdEditorResources.LoiIcon'*/;
		ScreenSize = 0.10f;
		HiddenGame = true;
	}
}
}