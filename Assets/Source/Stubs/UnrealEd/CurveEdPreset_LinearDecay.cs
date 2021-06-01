namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurveEdPreset_LinearDecay : CurveEdPresetBase/*
		native
		editinlinenew
		hidecategories(Object)*/{
	public/*()*/ float StartDecay;
	public/*()*/ float StartValue;
	public/*()*/ float EndDecay;
	public/*()*/ float EndValue;
	
	public override /*function */String GetDisplayName()
	{
	
		return default;
	}
	
	public override /*function */bool AreSettingsValid(bool bIsSaving)
	{
	
		return default;
	}
	
	public override /*function */bool GetRequiredKeyInTimes(ref array<float> RequiredKeyInTimes)
	{
	
		return default;
	}
	
	public override /*function */bool GenerateCurve(ref array<float> RequiredKeyInTimes, ref array<CurveEdPresetCurve.PresetGeneratedPoint> GeneratedPoints)
	{
	
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