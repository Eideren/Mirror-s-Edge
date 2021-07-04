namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdEADMPatcherWrapper : Object/*
		native*/{
	// Export UTdEADMPatcherWrapper::execIsLocalVersionNewerThan(FFrame&, void* const)
	public /*native function */static bool IsLocalVersionNewerThan(String RequiredVersion)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdEADMPatcherWrapper::execGetCDKey(FFrame&, void* const)
	public /*native function */static String GetCDKey()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdEADMPatcherWrapper::execGetParamSuffix(FFrame&, void* const)
	public /*native function */static int GetParamSuffix()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdEADMPatcherWrapper::execIsEADMInstalled(FFrame&, void* const)
	public /*native function */static bool IsEADMInstalled()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export UTdEADMPatcherWrapper::execStartPatching(FFrame&, void* const)
	public /*native function */static void StartPatching()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
	}
	
}
}