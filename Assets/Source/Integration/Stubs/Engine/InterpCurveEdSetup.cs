namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class InterpCurveEdSetup : Object/*
		native*/{
	public partial struct /*native */CurveEdEntry
	{
		public Object CurveObject;
		public Object.Color CurveColor;
		public String CurveName;
		public int bHideCurve;
		public int bColorCurve;
		public int bFloatingPointColorCurve;
		public int bClamp;
		public float ClampLow;
		public float ClampHigh;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x003400E3
	//		CurveObject = default;
	//		CurveColor = new Color
	//		{
	//			R=0,
	//			G=0,
	//			B=0,
	//			A=0
	//		};
	//		CurveName = "";
	//		bHideCurve = 0;
	//		bColorCurve = 0;
	//		bFloatingPointColorCurve = 0;
	//		bClamp = 0;
	//		ClampLow = 0.0f;
	//		ClampHigh = 0.0f;
	//	}
	};
	
	public partial struct /*native */CurveEdTab
	{
		public String TabName;
		public array<InterpCurveEdSetup.CurveEdEntry> Curves;
		public float ViewStartInput;
		public float ViewEndInput;
		public float ViewStartOutput;
		public float ViewEndOutput;
	
	//	structdefaultproperties
	//	{
	//		// Object Offset:0x0034035B
	//		TabName = "";
	//		Curves = default;
	//		ViewStartInput = 0.0f;
	//		ViewEndInput = 0.0f;
	//		ViewStartOutput = 0.0f;
	//		ViewEndOutput = 0.0f;
	//	}
	};
	
	public array<InterpCurveEdSetup.CurveEdTab> Tabs;
	public int ActiveTab;
	
	public InterpCurveEdSetup()
	{
		// Object Offset:0x00340497
		Tabs = new array<InterpCurveEdSetup.CurveEdTab>
		{
			new InterpCurveEdSetup.CurveEdTab
			{
				TabName = "Default",
				Curves = default,
				ViewStartInput = 0.0f,
				ViewEndInput = 1.0f,
				ViewStartOutput = -1.0f,
				ViewEndOutput = 1.0f,
			},
		};
	}
}
}