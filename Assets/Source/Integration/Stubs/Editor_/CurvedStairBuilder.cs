namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurvedStairBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	[Category] public int InnerRadius;
	[Category] public int StepHeight;
	[Category] public int StepWidth;
	[Category] public int AngleOfCurve;
	[Category] public int NumSteps;
	[Category] public int AddToFirstStep;
	[Category] public name GroupName;
	[Category] public bool CounterClockwise;
	
	public virtual /*function */void BuildCurvedStair(int Direction)
	{
		// stub
	}
	
	public override /*event */bool Build()
	{
		// stub
		return default;
	}
	
	public CurvedStairBuilder()
	{
		// Object Offset:0x0000D4C4
		InnerRadius = 240;
		StepHeight = 16;
		StepWidth = 256;
		AngleOfCurve = 90;
		NumSteps = 4;
		GroupName = (name)"CStair";
		BitmapFilename = "Btn_CurvedStairs";
		ToolTip = "Curved Staircase";
	}
}
}