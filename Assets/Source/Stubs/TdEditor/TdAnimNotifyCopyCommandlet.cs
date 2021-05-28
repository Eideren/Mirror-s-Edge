namespace MEdge.TdEditor{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent;

public partial class TdAnimNotifyCopyCommandlet : Commandlet/*
		transient
		native*/{
	public string PackagesPath;
	
	// Export UTdAnimNotifyCopyCommandlet::execMain(FFrame&, void* const)
	public override /*native event */int Main(string Params)
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public TdAnimNotifyCopyCommandlet()
	{
		// Object Offset:0x00001FB7
		PackagesPath = "../TdGame/Content/Animations/*";
	}
}
}