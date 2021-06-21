namespace MEdge.TdEditor{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent;

public partial class TdAnimInfoCommandlet : Commandlet/*
		transient
		native*/{
	public int AnimSizeWarning;
	public int AnimSizeFatalWarning;
	public String PackagesPath;
	
	// Export UTdAnimInfoCommandlet::execMain(FFrame&, void* const)
	public override /*native event */int Main(String Params)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
	public TdAnimInfoCommandlet()
	{
		// Object Offset:0x00001E03
		AnimSizeWarning = 80000;
		AnimSizeFatalWarning = 200000;
		PackagesPath = "..\\TdGame\\Content\\Animations\\*";
	}
}
}