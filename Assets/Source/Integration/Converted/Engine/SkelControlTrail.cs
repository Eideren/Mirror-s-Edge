namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlTrail : SkelControlBase/*
		native
		hidecategories(Object)*/{
	[Category("Trail")] public int ChainLength;
	[Category("Trail")] public Object.EAxis ChainBoneAxis;
	[Category("Trail")] public bool bInvertChainBoneAxis;
	[Category("Trail")] public bool bLimitStretch;
	public bool bHadValidStrength;
	[Category("Trail")] public float TrailRelaxation;
	[Category("Trail")] public float StretchLimit;
	public float ThisTimstep;
	[transient] public array<Object.Vector> TrailBoneLocations;
	
	public SkelControlTrail()
	{
		// Object Offset:0x003E3B55
		ChainLength = 2;
		ChainBoneAxis = Object.EAxis.AXIS_X;
		TrailRelaxation = 10.0f;
	}
}
}