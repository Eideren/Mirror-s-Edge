namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TextureCube : Texture/*
		native
		hidecategories(Object)*/{
	public /*const transient */int SizeX;
	public /*const transient */int SizeY;
	public /*const transient */Texture.EPixelFormat Format;
	public /*const transient */int NumMips;
	public /*const transient */bool bIsCubemapValid;
	public/*()*/ /*const */Texture2D FacePosX;
	public/*()*/ /*const */Texture2D FaceNegX;
	public/*()*/ /*const */Texture2D FacePosY;
	public/*()*/ /*const */Texture2D FaceNegY;
	public/*()*/ /*const */Texture2D FacePosZ;
	public/*()*/ /*const */Texture2D FaceNegZ;
	
}
}