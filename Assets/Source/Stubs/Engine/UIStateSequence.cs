namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class UIStateSequence : UISequence/*
		native
		hidecategories(Object)*/{
	// Export UUIStateSequence::execGetOwnerState(FFrame&, void* const)
	public virtual /*native final function */UIState GetOwnerState()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
}
}