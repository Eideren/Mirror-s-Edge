namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpiralStairBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	[Category] public int InnerRadius;
	[Category] public int StepWidth;
	[Category] public int StepHeight;
	[Category] public int StepThickness;
	[Category] public int NumStepsPer360;
	[Category] public int NumSteps;
	[Category] public name GroupName;
	[Category] public bool SlopedCeiling;
	[Category] public bool SlopedFloor;
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
	
	public SpiralStairBuilder()
	{
		// Object Offset:0x00014AC0
		InnerRadius = 64;
		StepWidth = 256;
		StepHeight = 16;
		StepThickness = 32;
		NumStepsPer360 = 8;
		NumSteps = 8;
		GroupName = (name)"Spiral";
		SlopedCeiling = true;
		BitmapFilename = "Btn_SpiralStairs";
		ToolTip = "Spiral Staircase";
	}
}
}