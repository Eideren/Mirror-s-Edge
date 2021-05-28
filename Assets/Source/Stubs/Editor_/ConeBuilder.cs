namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class ConeBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	public/*()*/ float Z;
	public/*()*/ float CapZ;
	public/*()*/ float OuterRadius;
	public/*()*/ float InnerRadius;
	public/*()*/ int Sides;
	public/*()*/ name GroupName;
	public/*()*/ bool AlignToSide;
	public/*()*/ bool Hollow;
	
	public virtual /*function */void BuildCone(int Direction, bool InAlignToSide, int InSides, float InZ, float Radius, name Item)
	{
	
	}
	
	public override /*event */bool Build()
	{
	
		return default;
	}
	
	public ConeBuilder()
	{
		// Object Offset:0x0000BE0A
		Z = 256.0f;
		CapZ = 256.0f;
		OuterRadius = 512.0f;
		InnerRadius = 384.0f;
		Sides = 8;
		GroupName = (name)"Cone";
		AlignToSide = true;
		BitmapFilename = "Btn_Cone";
		ToolTip = "Cone";
	}
}
}