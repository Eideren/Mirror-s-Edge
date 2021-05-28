namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class MorphNodePose : MorphNodeBase/*
		native
		hidecategories(Object,Object)*/{
	public /*transient */MorphTarget Target;
	public/*()*/ name MorphName;
	public/*()*/ float Weight;
	
	// Export UMorphNodePose::execSetMorphTarget(FFrame&, void* const)
	public virtual /*native final function */void SetMorphTarget(name MorphTargetName)
	{
		#warning NATIVE FUNCTION !
	}
	
	public MorphNodePose()
	{
		// Object Offset:0x0035CF14
		Weight = 1.0f;
	}
}
}