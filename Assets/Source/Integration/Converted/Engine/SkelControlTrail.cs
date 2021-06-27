namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SkelControlTrail : SkelControlBase/*
		native
		hidecategories(Object)*/{
	public/*(Trail)*/ int ChainLength;
	public/*(Trail)*/ Object.EAxis ChainBoneAxis;
	public/*(Trail)*/ bool bInvertChainBoneAxis;
	public/*(Trail)*/ bool bLimitStretch;
	public bool bHadValidStrength;
	public/*(Trail)*/ float TrailRelaxation;
	public/*(Trail)*/ float StretchLimit;
	public float ThisTimstep;
	public /*transient */array<Object.Vector> TrailBoneLocations;
	
	public SkelControlTrail()
	{
		// Object Offset:0x003E3B55
		ChainLength = 2;
		ChainBoneAxis = Object.EAxis.AXIS_X;
		TrailRelaxation = 10.0f;
	}
}
}