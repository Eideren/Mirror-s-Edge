namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class LinearStairBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	[Category] public int StepLength;
	[Category] public int StepHeight;
	[Category] public int StepWidth;
	[Category] public int NumSteps;
	[Category] public int AddToFirstStep;
	[Category] public name GroupName;
	
	public override /*event */bool Build()
	{
		// stub
		return default;
	}
	
	public LinearStairBuilder()
	{
		// Object Offset:0x0001347C
		StepLength = 32;
		StepHeight = 16;
		StepWidth = 256;
		NumSteps = 8;
		GroupName = (name)"LinearStair";
		BitmapFilename = "Btn_Staircase";
		ToolTip = "Linear Staircase";
	}
}
}