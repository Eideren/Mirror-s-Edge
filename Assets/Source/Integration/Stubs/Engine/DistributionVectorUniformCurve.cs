namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class DistributionVectorUniformCurve : DistributionVector/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object,Object)*/{
	public/*()*/ Object.InterpCurveTwoVectors ConstantCurve;
	public bool bLockAxes1;
	public bool bLockAxes2;
	public/*()*/ bool bUseExtremes;
	public/*()*/ StaticArray<DistributionVector.EDistributionVectorLockFlags, DistributionVector.EDistributionVectorLockFlags>/*[2]*/ LockedAxes;
	public/*()*/ StaticArray<DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags, DistributionVector.EDistributionVectorMirrorFlags>/*[3]*/ MirrorFlags;
	
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