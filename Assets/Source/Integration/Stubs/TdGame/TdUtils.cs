namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdUtils : Object/*
		native*/{
	// Export UTdUtils::execCosineInterp(FFrame&, void* const)
	public /*native final function */static float CosineInterp(float A, float B, float T)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUtils::execFormatTime(FFrame&, void* const)
	public /*native final function */static String FormatTime(String SecondsString)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdUtils::execFormatFloatTime(FFrame&, void* const)
	public /*native final function */static String FormatFloatTime(float Time)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}