namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_HingeActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_HingeActor()
	{
		// Object Offset:0x003AE1DB
		ConstraintSetup = LoadAsset<RB_HingeSetup>("Default__RB_HingeActor.MyHingeSetup")/*Ref RB_HingeSetup'Default__RB_HingeActor.MyHingeSetup'*/;
		ConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__RB_HingeActor.MyConstraintInstance")/*Ref RB_ConstraintInstance'Default__RB_HingeActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			//Components[0]=
			new SpriteComponent
			{
				// Object Offset:0x004D02B6
				Sprite = LoadAsset<Texture2D>("EngineResources.S_KHinge")/*Ref Texture2D'EngineResources.S_KHinge'*/,
			}/* Reference: SpriteComponent'Default__RB_HingeActor.Sprite' */,
			LoadAsset<RB_ConstraintDrawComponent>("Default__RB_HingeActor.MyConDrawComponent")/*Ref RB_ConstraintDrawComponent'Default__RB_HingeActor.MyConDrawComponent'*/,
			//Components[2]=
			new ArrowComponent
			{
				// Object Offset:0x00465CCB
				ArrowColor = new Color
				{
					R=255,
					G=64,
					B=64,
					A=255
				},
			}/* Reference: ArrowComponent'Default__RB_HingeActor.ArrowComponent0' */,
		};
	}
}
}