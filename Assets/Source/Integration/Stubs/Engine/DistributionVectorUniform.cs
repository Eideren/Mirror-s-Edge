namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DistributionVectorUniform : DistributionVector/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public Object.Vector Max;
	[Category] public Object.Vector Min;
	public bool bLockAxes;
	[Category] public bool bUseExtremes;
	[Category] public DistributionVector.EDistributionVectorLockFlags LockedAxes;
	[Category] public StaticArray<DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags>/*[3]*/ MirrorFlags;
	
	public DistributionVectorUniform()
	{
		// Object Offset:0x0030E9EA
		MirrorFlags = new StaticArray<DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags>/*[3]*/()
		{ 
			[0] = DistributionVector.EDistributionVectorMirrorFlags.EDVMF_Different,
			[1] = DistributionVector.EDistributionVectorMirrorFlags.EDVMF_Different,
			[2] = DistributionVector.EDistributionVectorMirrorFlags.EDVMF_Different,
	 	};
	}
}
}