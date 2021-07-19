namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurveEdOptions : Object/*
		native
		config(Editor)
		hidecategories(Object)*/{
	[Category("Options")] [config] public float MinViewRange;
	[Category("Options")] [config] public float MaxViewRange;
	[Category("Options")] [config] public Object.LinearColor BackgroundColor;
	[Category("Options")] [config] public Object.LinearColor LabelColor;
	[Category("Options")] [config] public Object.LinearColor SelectedLabelColor;
	[Category("Options")] [config] public Object.LinearColor GridColor;
	[Category("Options")] [config] public Object.LinearColor GridTextColor;
	[Category("Options")] [config] public Object.LinearColor LabelBlockBkgColor;
	[Category("Options")] [config] public Object.LinearColor SelectedKeyColor;
	
	public CurveEdOptions()
	{
		// Object Offset:0x0001C094
		MinViewRange = 0.0010f;
		MaxViewRange = 1000000.0f;
		BackgroundColor = new LinearColor
		{
			R=0.23529410f,
			G=0.23529410f,
			B=0.23529410f,
			A=1.0f
		};
		LabelColor = new LinearColor
		{
			R=0.70588240f,
			G=0.70588240f,
			B=0.70588240f,
			A=1.0f
		};
		SelectedLabelColor = new LinearColor
		{
			R=0.11764710f,
			G=0.50980390f,
			B=1.0f,
			A=1.0f
		};
		GridColor = new LinearColor
		{
			R=0.49019610f,
			G=0.49019610f,
			B=0.49019610f,
			A=1.0f
		};
		GridTextColor = new LinearColor
		{
			R=0.78431370f,
			G=0.78431370f,
			B=0.78431370f,
			A=1.0f
		};
		LabelBlockBkgColor = new LinearColor
		{
			R=0.50980390f,
			G=0.50980390f,
			B=0.50980390f,
			A=1.0f
		};
		SelectedKeyColor = new LinearColor
		{
			R=0.0f,
			G=1.0f,
			B=1.0f,
			A=1.0f
		};
	}
}
}