namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureRenderTarget2D : TextureRenderTarget/*
		native
		hidecategories(Object,Texture)*/{
	public/*()*/ /*const */int SizeX;
	public/*()*/ /*const */int SizeY;
	public /*const */Texture.EPixelFormat Format;
	public/*()*/ Texture.TextureAddress AddressX;
	public/*()*/ Texture.TextureAddress AddressY;
	public /*const */Object.LinearColor ClearColor;
	
	// Export UTextureRenderTarget2D::execCreate(FFrame&, void* const)
	public /*native final function */static TextureRenderTarget2D Create(int InSizeX, int InSizeY, /*optional */Texture.EPixelFormat? _InFormat = default, /*optional */Object.LinearColor? _InClearColor = default, /*optional */bool? _bOnlyRenderOnce = default)
	{
		#warning NATIVE FUNCTION !
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