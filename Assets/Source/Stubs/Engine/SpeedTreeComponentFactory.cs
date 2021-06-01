namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTreeComponentFactory : PrimitiveComponentFactory/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	public/*()*/ /*export editinline */SpeedTreeComponent SpeedTreeComponent;
	
	public SpeedTreeComponentFactory()
	{
		// Object Offset:0x003ECDC8
		SpeedTreeComponent = LoadAsset<SpeedTreeComponent>("Default__SpeedTreeComponentFactory.SpeedTreeComponent0")/*Ref SpeedTreeComponent'Default__SpeedTreeComponentFactory.SpeedTreeComponent0'*/;
		CollideActors = true;
		BlockActors = true;
		BlockZeroExtent = true;
		BlockNonZeroExtent = true;
		BlockRigidBody = true;
	}
}
}