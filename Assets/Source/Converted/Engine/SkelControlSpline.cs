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
	
	public/*(Spline)*/ int SplineLength;
	public/*(Spline)*/ Object.EAxis SplineBoneAxis;
	public/*(Spline)*/ SkelControlSpline.ESplineControlRotMode BoneRotMode;
	public/*(Spline)*/ bool bInvertSplineBoneAxis;
	public/*(Spline)*/ float EndSplineTension;
	public/*(Spline)*/ float StartSplineTension;
	
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