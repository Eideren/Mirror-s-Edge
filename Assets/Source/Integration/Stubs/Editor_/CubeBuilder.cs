namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CubeBuilder : BrushBuilder/*
		native
		hidecategories(Object,BrushBuilder)*/{
	[Category] public float X;
	[Category] public float Y;
	[Category] public float Z;
	[Category] public float WallThickness;
	[Category] public name GroupName;
	[Category] public bool Hollow;
	[Category] public bool Tessellated;
	
	public virtual /*function */void BuildCube(int Direction, float DX, float DY, float dz, bool _tessellated)
	{
		// stub
	}
	
	public override /*event */bool Build()
	{
		// stub
		return default;
	}
	
	public CubeBuilder()
	{
		// Object Offset:0x0000C887
		X = 256.0f;
		Y = 256.0f;
		Z = 256.0f;
		WallThickness = 16.0f;
		GroupName = (name)"Cube";
		BitmapFilename = "Btn_Box";
		ToolTip = "Cube";
	}
}
}