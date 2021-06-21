namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MultiFont : Font/*
		native
		hidecategories(Object)*/{
	public/*()*/ /*editinline */array</*editinline */float> ResolutionTestTable;
	
	// Export UMultiFont::execGetResolutionTestTableIndex(FFrame&, void* const)
	public virtual /*native function */int GetResolutionTestTableIndex(float HeightTest)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
}
}