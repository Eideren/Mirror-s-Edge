namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SheetBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	public enum ESheetAxis 
	{
		AX_Horizontal,
		AX_XAxis,
		AX_YAxis,
		AX_MAX
	};
	
	[Category] public int X;
	[Category] public int Y;
	[Category] public int XSegments;
	[Category] public int YSegments;
	[Category] public SheetBuilder.ESheetAxis Axis;
	[Category] public name GroupName;
	
	public override /*event */bool Build()
	{
		// stub
		return default;
	}
	
	public SheetBuilder()
	{
		// Object Offset:0x00013CDA
		X = 256;
		Y = 256;
		XSegments = 1;
		YSegments = 1;
		GroupName = (name)"Sheet";
		BitmapFilename = "Btn_Sheet";
		ToolTip = "Sheet";
	}
}
}