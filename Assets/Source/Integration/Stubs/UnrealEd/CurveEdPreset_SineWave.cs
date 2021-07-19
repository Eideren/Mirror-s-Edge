namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurveEdPreset_SineWave : CurveEdPresetBase/*
		native
		editinlinenew
		hidecategories(Object)*/{
	[Category] public float Frequency;
	[Category] public float Scale;
	[Category] public float Offset;
	
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
	
	public CurveEdPreset_SineWave()
	{
		// Object Offset:0x0001E3F8
		Frequency = 1.0f;
		Scale = 1.0f;
	}
}
}