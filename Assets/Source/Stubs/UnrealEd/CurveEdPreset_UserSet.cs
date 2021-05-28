namespace MEdge.UnrealEd{
using Core; using Engine; using Editor; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class CurveEdPreset_UserSet : CurveEdPresetBase/*
		native
		editinlinenew
		hidecategories(Object)*/{
	public/*()*/ CurveEdPresetCurve UserCurve;
	
	public override /*function */string GetDisplayName()
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
	
	public virtual /*function */bool SetCurve(array<CurveEdPresetCurve.PresetGeneratedPoint> GeneratedPoints)
	{
	
		return default;
	}
	
	public virtual /*function */bool LoadUserSetPointFile()
	{
	
		return default;
	}
	
	public virtual /*function */bool SaveUserSetPointFile()
	{
	
		return default;
	}
	
}
}