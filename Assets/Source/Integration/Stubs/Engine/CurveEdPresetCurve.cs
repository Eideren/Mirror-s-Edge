namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurveEdPresetCurve : Object/*
		native
		editinlinenew
		hidecategories(Object)*/{
	public partial struct /*native */PresetGeneratedPoint
	{
		public float KeyIn;
		public float KeyOut;
		public bool TangentsValid;
		public float TangentIn;
		public float TangentOut;
		public Object.EInterpCurveMode IntepMode;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x002F7F4D
	//		KeyIn = 0.0f;
	//		KeyOut = 0.0f;
	//		TangentsValid = false;
	//		TangentIn = 0.0f;
	//		TangentOut = 0.0f;
	//		IntepMode = Object.EInterpCurveMode.CIM_Linear;
	//	}
	};
	
	[Category] [Const, localized] public String CurveName;
	public array<CurveEdPresetCurve.PresetGeneratedPoint> Points;
	
}
}