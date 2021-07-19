namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class SpeedTreeComponentFactory : PrimitiveComponentFactory/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] [export, editinline] public SpeedTreeComponent SpeedTreeComponent;
	
	public SpeedTreeComponentFactory()
	{
		var Default__SpeedTreeComponentFactory_SpeedTreeComponent0 = new SpeedTreeComponent
		{
		}/* Reference: SpeedTreeComponent'Default__SpeedTreeComponentFactory.SpeedTreeComponent0' */;
		// Object Offset:0x003ECDC8
		SpeedTreeComponent = Default__SpeedTreeComponentFactory_SpeedTreeComponent0/*Ref SpeedTreeComponent'Default__SpeedTreeComponentFactory.SpeedTreeComponent0'*/;
		CollideActors = true;
		BlockActors = true;
		BlockZeroExtent = true;
		BlockNonZeroExtent = true;
		BlockRigidBody = true;
	}
}
}