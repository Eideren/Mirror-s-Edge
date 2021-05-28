namespace MEdge.TdEditor{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent;

public partial class TdAnimSanityCheckCommandlet : Commandlet/*
		transient
		native*/{
	public string PackagesPath;
	
	// Export UTdAnimSanityCheckCommandlet::execMain(FFrame&, void* const)
	public override /*native event */int Main(string Params)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdAnimSanityCheckCommandlet()
	{
		// Object Offset:0x00002133
		PackagesPath = "../TdGame/Content/Animations/*";
	}
}
}