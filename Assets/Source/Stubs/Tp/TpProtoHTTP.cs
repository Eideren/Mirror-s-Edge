namespace MEdge.Tp{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TpProtoHTTP : TpSystemHandler/*
		abstract
		transient
		native*/{
	public /*delegate*/TpProtoHTTP.OnGetVersion __OnGetVersion__Delegate;
	
	// Export UTpProtoHTTP::execUpdate(FFrame&, void* const)
	public virtual /*native simulated function */void Update(float DeltaSeconds)
	{
		#warning NATIVE FUNCTION !
	}
	
	// Export UTpProtoHTTP::execGetCurrentVersion(FFrame&, void* const)
	public virtual /*native simulated function */void GetCurrentVersion(/*optional */String? _Param = default)
	{
		#warning NATIVE FUNCTION !
	}
	
	public delegate void OnGetVersion(String Version);
	
}
}