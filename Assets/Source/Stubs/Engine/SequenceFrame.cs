namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SequenceFrame : SequenceObject/*
		native
		hidecategories(Object)*/{
	public/*()*/ int SizeX;
	public/*()*/ int SizeY;
	public/*()*/ int BorderWidth;
	public/*()*/ bool bDrawBox;
	public/*()*/ bool bFilled;
	public/*()*/ bool bTileFill;
	public/*()*/ Object.Color BorderColor;
	public/*()*/ Object.Color FillColor;
	public/*()*/ Texture2D FillTexture;
	public/*()*/ Material FillMaterial;
	
	public SequenceFrame()
	{
		// Object Offset:0x003DF95F
		SizeX = 128;
		SizeY = 64;
		BorderWidth = 1;
		bFilled = true;
		BorderColor = new Color
		{
			R=0,
			G=0,
			B=0,
			A=255
		};
		FillColor = new Color
		{
			R=255,
			G=255,
			B=255,
			A=16
		};
		ObjName = "Sequence Comment";
		ObjComment = "Comment";
		bDrawFirst = true;
	}
}
}