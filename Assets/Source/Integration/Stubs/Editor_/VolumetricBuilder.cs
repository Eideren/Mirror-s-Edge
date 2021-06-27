namespace MEdge.Editor{
using Core; using Engine; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class VolumetricBuilder : BrushBuilder/*
		hidecategories(Object,BrushBuilder)*/{
	public/*()*/ float Z;
	public/*()*/ float Radius;
	public/*()*/ int NumSheets;
	public/*()*/ name GroupName;
	
	public virtual /*function */void BuildVolumetric(int Direction, int InNumSheets, float InZ, float InRadius)
	{
		// stub
	}
	
	public override /*event */bool Build()
	{
		// stub
		return default;
	}
	
	public VolumetricBuilder()
	{
		// Object Offset:0x00015A34
		Z = 128.0f;
		Radius = 64.0f;
		NumSheets = 2;
		GroupName = (name)"Volumetric";
		BitmapFilename = "Btn_Volumetric";
		ToolTip = "Volumetric (Torches, Chains, etc)";
	}
}
}