namespace MEdge.TdEditor{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent;

public partial class TdAnimSanityCheckCommandlet : Commandlet/*
		transient
		native*/{
	public String PackagesPath;
	
	// Export UTdAnimSanityCheckCommandlet::execMain(FFrame&, void* const)
	public override /*native event */int Main(String Params)
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public TdAnimSanityCheckCommandlet()
	{
		// Object Offset:0x00002133
		PackagesPath = "../TdGame/Content/Animations/*";
	}
}
}