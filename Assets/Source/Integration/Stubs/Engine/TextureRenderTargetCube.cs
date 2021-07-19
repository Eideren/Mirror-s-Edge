namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureRenderTargetCube : TextureRenderTarget/*
		native
		hidecategories(Object,Texture)*/{
	[Category] public int SizeX;
	[Const] public Texture.EPixelFormat Format;
	
	public TextureRenderTargetCube()
	{
		// Object Offset:0x003FEFAC
		Format = Texture.EPixelFormat.PF_A8R8G8B8;
	}
}
}