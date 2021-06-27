namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_PulleyJointActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_PulleyJointActor()
	{
		var Default__RB_PulleyJointActor_MyPulleyJointSetup = new RB_PulleyJointSetup
		{
		}/* Reference: RB_PulleyJointSetup'Default__RB_PulleyJointActor.MyPulleyJointSetup' */;
		var Default__RB_PulleyJointActor_MyConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__RB_PulleyJointActor.MyConstraintInstance' */;
		var Default__RB_PulleyJointActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D03A6
			Sprite = LoadAsset<Texture2D>("EngineResources.S_KBSJoint")/*Ref Texture2D'EngineResources.S_KBSJoint'*/,
		}/* Reference: SpriteComponent'Default__RB_PulleyJointActor.Sprite' */;
		var Default__RB_PulleyJointActor_MyConDrawComponent = new RB_ConstraintDrawComponent
		{
		}/* Reference: RB_ConstraintDrawComponent'Default__RB_PulleyJointActor.MyConDrawComponent' */;
		// Object Offset:0x003AE9A7
		ConstraintSetup = Default__RB_PulleyJointActor_MyPulleyJointSetup/*Ref RB_PulleyJointSetup'Default__RB_PulleyJointActor.MyPulleyJointSetup'*/;
		ConstraintInstance = Default__RB_PulleyJointActor_MyConstraintInstance/*Ref RB_ConstraintInstance'Default__RB_PulleyJointActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_PulleyJointActor_Sprite/*Ref SpriteComponent'Default__RB_PulleyJointActor.Sprite'*/,
			Default__RB_PulleyJointActor_MyConDrawComponent/*Ref RB_ConstraintDrawComponent'Default__RB_PulleyJointActor.MyConDrawComponent'*/,
		};
	}
}
}