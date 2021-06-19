namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_BSJointActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_BSJointActor()
	{
		var Default__RB_BSJointActor_MyBSJointSetup = new RB_BSJointSetup
		{
		}/* Reference: RB_BSJointSetup'Default__RB_BSJointActor.MyBSJointSetup' */;
		var Default__RB_BSJointActor_MyConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__RB_BSJointActor.MyConstraintInstance' */;
		var Default__RB_BSJointActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D01E2
			Sprite = LoadAsset<Texture2D>("EngineResources.S_KBSJoint")/*Ref Texture2D'EngineResources.S_KBSJoint'*/,
		}/* Reference: SpriteComponent'Default__RB_BSJointActor.Sprite' */;
		var Default__RB_BSJointActor_MyConDrawComponent = new RB_ConstraintDrawComponent
		{
		}/* Reference: RB_ConstraintDrawComponent'Default__RB_BSJointActor.MyConDrawComponent' */;
		// Object Offset:0x003ACDEC
		ConstraintSetup = Default__RB_BSJointActor_MyBSJointSetup/*Ref RB_BSJointSetup'Default__RB_BSJointActor.MyBSJointSetup'*/;
		ConstraintInstance = Default__RB_BSJointActor_MyConstraintInstance/*Ref RB_ConstraintInstance'Default__RB_BSJointActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_BSJointActor_Sprite/*Ref SpriteComponent'Default__RB_BSJointActor.Sprite'*/,
			Default__RB_BSJointActor_MyConDrawComponent/*Ref RB_ConstraintDrawComponent'Default__RB_BSJointActor.MyConDrawComponent'*/,
		};
	}
}
}