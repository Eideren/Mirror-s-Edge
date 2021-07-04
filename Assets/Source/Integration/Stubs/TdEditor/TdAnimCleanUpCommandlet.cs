namespace MEdge.TdEditor{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent;

public partial class TdAnimCleanUpCommandlet : Commandlet/*
		transient
		native*/{
	public String PackagesPath;
	
	// Export UTdAnimCleanUpCommandlet::execMain(FFrame&, void* const)
	public override /*native event */int Main(String Params)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TdAnimCleanUpCommandlet()
	{
		// Object Offset:0x00001C2F
		PackagesPath = "..\\TdGame\\Content\\Animations\\*";
	}
}
}