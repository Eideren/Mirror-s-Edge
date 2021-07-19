namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureCube : Texture/*
		native
		hidecategories(Object)*/{
	[Const, transient] public int SizeX;
	[Const, transient] public int SizeY;
	[Const, transient] public Texture.EPixelFormat Format;
	[Const, transient] public int NumMips;
	[Const, transient] public bool bIsCubemapValid;
	[Category] [Const] public Texture2D FacePosX;
	[Category] [Const] public Texture2D FaceNegX;
	[Category] [Const] public Texture2D FacePosY;
	[Category] [Const] public Texture2D FaceNegY;
	[Category] [Const] public Texture2D FacePosZ;
	[Category] [Const] public Texture2D FaceNegZ;
	
}
}