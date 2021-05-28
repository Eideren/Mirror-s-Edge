namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurveEdPresetBase : Object/*
		abstract
		native*/{
	public virtual /*function */string GetDisplayName()
	{
	
		return default;
	}
	
	public virtual /*function */bool AreSettingsValid(bool bIsSaving)
	{
	
		return default;
	}
	
	public virtual /*function */bool GetRequiredKeyInTimes(ref array<float> RequiredKeyInTimes)
	{
	
		return default;
	}
	
	public virtual /*function */bool GenerateCurve(ref array<float> RequiredKeyInTimes, ref array<CurveEdPresetCurve.PresetGeneratedPoint> GeneratedPoints)
	{
	
		return default;
	}
	
	public virtual /*event */void FetchDisplayName(ref string OutName)
	{
	
	}
	
	public virtual /*event */bool CheckAreSettingsValid(bool bIsSaving)
	{
	
		return default;
	}
	
	public virtual /*event */bool FetchRequiredKeyInTimes(ref array<float> RequiredKeyInTimes)
	{
	
		return default;
	}
	
	public virtual /*event */bool GenerateCurveData(ref array<float> RequiredKeyInTimes, ref array<CurveEdPresetCurve.PresetGeneratedPoint> GeneratedPoints)
	{
	
		return default;
	}
	
}
}