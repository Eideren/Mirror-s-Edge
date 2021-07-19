namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureRenderTarget2D : TextureRenderTarget/*
		native
		hidecategories(Object,Texture)*/{
	[Category] [Const] public int SizeX;
	[Category] [Const] public int SizeY;
	[Const] public Texture.EPixelFormat Format;
	[Category] public Texture.TextureAddress AddressX;
	[Category] public Texture.TextureAddress AddressY;
	[Const] public Object.LinearColor ClearColor;
	
	// Export UTextureRenderTarget2D::execCreate(FFrame&, void* const)
	public /*native final function */static TextureRenderTarget2D Create(int InSizeX, int InSizeY, /*optional */Texture.EPixelFormat? _InFormat = default, /*optional */Object.LinearColor? _InClearColor = default, /*optional */bool? _bOnlyRenderOnce = default)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TextureRenderTarget2D()
	{
		// Object Offset:0x003FEE75
		Format = Texture.EPixelFormat.PF_A8R8G8B8;
		ClearColor = new LinearColor
		{
			R=0.0f,
			G=1.0f,
			B=0.0f,
			A=1.0f
		};
	}
}
}