namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurveEdPreset_LinearDecay : CurveEdPresetBase/*
		native
		editinlinenew
		hidecategories(Object)*/{
	[Category] public float StartDecay;
	[Category] public float StartValue;
	[Category] public float EndDecay;
	[Category] public float EndValue;
	
	public override /*function */String GetDisplayName()
	{
		// stub
		return default;
	}
	
	public override /*function */bool AreSettingsValid(bool bIsSaving)
	{
		// stub
		return default;
	}
	
	public override /*function */bool GetRequiredKeyInTimes(ref array<float> RequiredKeyInTimes)
	{
		// stub
		return default;
	}
	
	public override /*function */bool GenerateCurve(ref array<float> RequiredKeyInTimes, ref array<CurveEdPresetCurve.PresetGeneratedPoint> GeneratedPoints)
	{
		// stub
		return default;
	}
	
	public CurveEdPreset_LinearDecay()
	{
		// Object Offset:0x0001DA4B
		StartValue = 1.0f;
		EndDecay = 1.0f;
	}
}
}