namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlSpline : SkelControlBase/*
		native
		hidecategories(Object)*/{
	public enum ESplineControlRotMode 
	{
		SCR_NoChange,
		SCR_AlongSpline,
		SCR_Interpolate,
		SCR_MAX
	};
	
	[Category("Spline")] public int SplineLength;
	[Category("Spline")] public Object.EAxis SplineBoneAxis;
	[Category("Spline")] public SkelControlSpline.ESplineControlRotMode BoneRotMode;
	[Category("Spline")] public bool bInvertSplineBoneAxis;
	[Category("Spline")] public float EndSplineTension;
	[Category("Spline")] public float StartSplineTension;
	
	public SkelControlSpline()
	{
		// Object Offset:0x003E38A6
		SplineLength = 2;
		SplineBoneAxis = Object.EAxis.AXIS_X;
		EndSplineTension = 10.0f;
		StartSplineTension = 10.0f;
	}
}
}