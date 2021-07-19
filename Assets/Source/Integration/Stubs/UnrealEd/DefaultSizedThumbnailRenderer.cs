namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DefaultSizedThumbnailRenderer : ThumbnailRenderer/*
		abstract
		native
		config(Editor)*/{
	[config] public int DefaultSizeX;
	[config] public int DefaultSizeY;
	
	public DefaultSizedThumbnailRenderer()
	{
		// Object Offset:0x000212A1
		DefaultSizeX = 512;
		DefaultSizeY = 512;
	}
}
}