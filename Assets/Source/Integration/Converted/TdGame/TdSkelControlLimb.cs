namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlLimb : SkelControlLimb/*
		native
		hidecategories(Object)*/{
	[Category] public bool bDisableRotationAdjustment;
	[Category] public bool bInterpolateLocation;
	[Category] public bool bClampLocation;
	[Category] public Object.Vector MinLocation;
	[Category] public Object.Vector MaxLocation;
	[Category] public Object.Vector TargetLocation;
	
	public TdSkelControlLimb()
	{
		// Object Offset:0x0065768E
		MinLocation = new Vector
		{
			X=-1000.0f,
			Y=-1000.0f,
			Z=-1000.0f
		};
		MaxLocation = new Vector
		{
			X=1000.0f,
			Y=1000.0f,
			Z=1000.0f
		};
	}
}
}