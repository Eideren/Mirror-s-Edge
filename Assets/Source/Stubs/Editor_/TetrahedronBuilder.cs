namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TetrahedronBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	public/*()*/ float Radius;
	public/*()*/ int SphereExtrapolation;
	public/*()*/ name GroupName;
	
	public virtual /*function */void Extrapolate(int A, int B, int C, int Count, float InRadius)
	{
		// stub
	}
	
	public virtual /*function */void BuildTetrahedron(float R, int InSphereExtrapolation)
	{
		// stub
	}
	
	public override /*event */bool Build()
	{
		// stub
		return default;
	}
	
	public TetrahedronBuilder()
	{
		// Object Offset:0x00015371
		Radius = 256.0f;
		SphereExtrapolation = 1;
		GroupName = (name)"Tetrahedron";
		BitmapFilename = "Btn_Sphere";
		ToolTip = "Tetrahedron (Sphere)";
	}
}
}