namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdDirectionalHazePostProcess : PostProcessEffect/*
		native
		hidecategories(Object)*/{
	public Object.Vector SunVector;
	public/*()*/ Object.Vector HazeColor;
	public/*()*/ float AngleCurve;
	public/*()*/ float AngleStart;
	public/*()*/ float DistanceCurve;
	public/*()*/ float DistanceDivider;
	public/*()*/ float HazeAngleClampHigh;
	public/*()*/ float HazeTotalClampCloseHigh;
	public/*()*/ float HazeTotalClampFarHigh;
	public/*()*/ float HazeTotalClampFarDistance;
	public/*()*/ float HazeMultiplier;
	public/*()*/ float HazeTotalClampLow;
	
	public TdDirectionalHazePostProcess()
	{
		// Object Offset:0x005421CE
		HazeColor = new Vector
		{
			X=1.0f,
			Y=1.0f,
			Z=0.80f
		};
		AngleCurve = 5.0f;
		AngleStart = 0.50f;
		DistanceCurve = 1.50f;
		DistanceDivider = 7500.0f;
		HazeAngleClampHigh = 2.0f;
		HazeTotalClampCloseHigh = 10.0f;
		HazeTotalClampFarHigh = 10.0f;
		HazeTotalClampFarDistance = 1.0f;
		HazeMultiplier = 1.0f;
	}
}
}