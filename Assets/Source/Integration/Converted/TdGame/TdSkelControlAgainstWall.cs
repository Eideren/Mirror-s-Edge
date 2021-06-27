namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdSkelControlAgainstWall : SkelControlLimb/*
		native
		hidecategories(Object)*/{
	public/*()*/ bool bLeftHand;
	public/*()*/ Object.Vector MinLocation;
	public/*()*/ Object.Vector MaxLocation;
	public/*()*/ Object.Vector TargetLocation;
	public/*()*/ Object.Vector HandOffset;
	
	public TdSkelControlAgainstWall()
	{
		// Object Offset:0x0065671B
		MinLocation = new Vector
		{
			X=5.0f,
			Y=-170.0f,
			Z=10.0f
		};
		MaxLocation = new Vector
		{
			X=35.0f,
			Y=-100.0f,
			Z=30.0f
		};
		HandOffset = new Vector
		{
			X=0.0f,
			Y=0.0f,
			Z=-20.0f
		};
		EffectorLocationSpace = SkelControlBase.EBoneControlSpace.BCS_ComponentSpace;
		JointTargetLocationSpace = SkelControlBase.EBoneControlSpace.BCS_ParentBoneSpace;
	}
}
}