namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CylinderBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	public/*()*/ float Z;
	public/*()*/ float OuterRadius;
	public/*()*/ float InnerRadius;
	public/*()*/ int Sides;
	public/*()*/ name GroupName;
	public/*()*/ bool AlignToSide;
	public/*()*/ bool Hollow;
	
	public virtual /*function */void BuildCylinder(int Direction, bool InAlignToSide, int InSides, float InZ, float Radius)
	{
		// stub
	}
	
	public override /*event */bool Build()
	{
		// stub
		return default;
	}
	
	public CylinderBuilder()
	{
		// Object Offset:0x0000DE0F
		Z = 256.0f;
		OuterRadius = 512.0f;
		InnerRadius = 384.0f;
		Sides = 8;
		GroupName = (name)"Cylinder";
		AlignToSide = true;
		BitmapFilename = "Btn_Cylinder";
		ToolTip = "Cylinder";
	}
}
}