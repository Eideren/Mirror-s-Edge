namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_BSJointActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_BSJointActor()
	{
		// Object Offset:0x003ACDEC
		ConstraintSetup = LoadAsset<RB_BSJointSetup>("Default__RB_BSJointActor.MyBSJointSetup")/*Ref RB_BSJointSetup'Default__RB_BSJointActor.MyBSJointSetup'*/;
		ConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__RB_BSJointActor.MyConstraintInstance")/*Ref RB_ConstraintInstance'Default__RB_BSJointActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004D01E2
				Sprite = LoadAsset<Texture2D>("EngineResources.S_KBSJoint")/*Ref Texture2D'EngineResources.S_KBSJoint'*/,
			}/* Reference: SpriteComponent'Default__RB_BSJointActor.Sprite' */,
			LoadAsset<RB_ConstraintDrawComponent>("Default__RB_BSJointActor.MyConDrawComponent")/*Ref RB_ConstraintDrawComponent'Default__RB_BSJointActor.MyConDrawComponent'*/,
		};
	}
}
}