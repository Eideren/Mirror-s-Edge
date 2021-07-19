namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DistributionVectorUniformCurve : DistributionVector/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	[Category] public Object.InterpCurveTwoVectors ConstantCurve;
	public bool bLockAxes1;
	public bool bLockAxes2;
	[Category] public bool bUseExtremes;
	[Category] public StaticArray<DistributionVector.EDistributionVectorLockFlags, DistributionVector.EDistributionVectorLockFlags>/*[2]*/ LockedAxes;
	[Category] public StaticArray<DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags>/*[3]*/ MirrorFlags;
	
	public DistributionVectorUniformCurve()
	{
		// Object Offset:0x0030EBDD
		MirrorFlags = new StaticArray<DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags>/*[3]*/()
		{ 
			[0] = DistributionVector.EDistributionVectorMirrorFlags.EDVMF_Different,
			[1] = DistributionVector.EDistributionVectorMirrorFlags.EDVMF_Different,
			[2] = DistributionVector.EDistributionVectorMirrorFlags.EDVMF_Different,
	 	};
	}
}
}