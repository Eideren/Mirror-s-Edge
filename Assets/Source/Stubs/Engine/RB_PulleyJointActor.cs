namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_PulleyJointActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_PulleyJointActor()
	{
		var Default__RB_PulleyJointActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D03A6
			Sprite = LoadAsset<Texture2D>("EngineResources.S_KBSJoint")/*Ref Texture2D'EngineResources.S_KBSJoint'*/,
		}/* Reference: SpriteComponent'Default__RB_PulleyJointActor.Sprite' */;
		// Object Offset:0x003AE9A7
		ConstraintSetup = LoadAsset<RB_PulleyJointSetup>("Default__RB_PulleyJointActor.MyPulleyJointSetup")/*Ref RB_PulleyJointSetup'Default__RB_PulleyJointActor.MyPulleyJointSetup'*/;
		ConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__RB_PulleyJointActor.MyConstraintInstance")/*Ref RB_ConstraintInstance'Default__RB_PulleyJointActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_PulleyJointActor_Sprite,
			LoadAsset<RB_ConstraintDrawComponent>("Default__RB_PulleyJointActor.MyConDrawComponent")/*Ref RB_ConstraintDrawComponent'Default__RB_PulleyJointActor.MyConDrawComponent'*/,
		};
	}
}
}