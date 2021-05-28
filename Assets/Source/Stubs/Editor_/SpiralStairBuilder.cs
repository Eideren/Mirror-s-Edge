namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpiralStairBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	public/*()*/ int InnerRadius;
	public/*()*/ int StepWidth;
	public/*()*/ int StepHeight;
	public/*()*/ int StepThickness;
	public/*()*/ int NumStepsPer360;
	public/*()*/ int NumSteps;
	public/*()*/ name GroupName;
	public/*()*/ bool SlopedCeiling;
	public/*()*/ bool SlopedFloor;
	public/*()*/ bool CounterClockwise;
	
	public virtual /*function */void BuildCurvedStair(int Direction)
	{
	
	}
	
	public override /*event */bool Build()
	{
	
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