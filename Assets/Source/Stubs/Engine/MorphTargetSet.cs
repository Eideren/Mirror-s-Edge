namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MorphTargetSet : Object/*
		native*/{
	public array<MorphTarget> Targets;
	public SkeletalMesh BaseSkelMesh;
	
	// Export UMorphTargetSet::execFindMorphTarget(FFrame&, void* const)
	public virtual /*native final function */MorphTarget FindMorphTarget(name MorphTargetName)
	{
		#warning NATIVE FUNCTION !
		// stub
		return default;
	}
	
}
}