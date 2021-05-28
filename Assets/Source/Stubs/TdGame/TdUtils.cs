namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUtils : Object/*
		native*/{
	// Export UTdUtils::execCosineInterp(FFrame&, void* const)
	public /*native final function */static float CosineInterp(float A, float B, float T)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUtils::execFormatTime(FFrame&, void* const)
	public /*native final function */static string FormatTime(string SecondsString)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	// Export UTdUtils::execFormatFloatTime(FFrame&, void* const)
	public /*native final function */static string FormatFloatTime(float Time)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}