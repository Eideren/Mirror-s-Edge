namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class Surface : Object/*
		abstract
		native*/{
	// Export USurface::execGetSurfaceWidth(FFrame&, void* const)
	public virtual /*native final function */float GetSurfaceWidth()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	// Export USurface::execGetSurfaceHeight(FFrame&, void* const)
	public virtual /*native final function */float GetSurfaceHeight()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
}
}