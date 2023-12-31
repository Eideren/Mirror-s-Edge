namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_HingeActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_HingeActor()
	{
		var Default__RB_HingeActor_MyHingeSetup = new RB_HingeSetup
		{
		}/* Reference: RB_HingeSetup'Default__RB_HingeActor.MyHingeSetup' */;
		var Default__RB_HingeActor_MyConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__RB_HingeActor.MyConstraintInstance' */;
		var Default__RB_HingeActor_Sprite = new SpriteComponent
		{
			// Object Offset:0x004D02B6
			Sprite = LoadAsset<Texture2D>("EngineResources.S_KHinge")/*Ref Texture2D'EngineResources.S_KHinge'*/,
		}/* Reference: SpriteComponent'Default__RB_HingeActor.Sprite' */;
		var Default__RB_HingeActor_MyConDrawComponent = new RB_ConstraintDrawComponent
		{
		}/* Reference: RB_ConstraintDrawComponent'Default__RB_HingeActor.MyConDrawComponent' */;
		var Default__RB_HingeActor_ArrowComponent0 = new ArrowComponent
		{
			// Object Offset:0x00465CCB
			ArrowColor = new Color
			{
				R=255,
				G=64,
				B=64,
				A=255
			},
		}/* Reference: ArrowComponent'Default__RB_HingeActor.ArrowComponent0' */;
		// Object Offset:0x003AE1DB
		ConstraintSetup = Default__RB_HingeActor_MyHingeSetup/*Ref RB_HingeSetup'Default__RB_HingeActor.MyHingeSetup'*/;
		ConstraintInstance = Default__RB_HingeActor_MyConstraintInstance/*Ref RB_ConstraintInstance'Default__RB_HingeActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_HingeActor_Sprite/*Ref SpriteComponent'Default__RB_HingeActor.Sprite'*/,
			Default__RB_HingeActor_MyConDrawComponent/*Ref RB_ConstraintDrawComponent'Default__RB_HingeActor.MyConDrawComponent'*/,
			Default__RB_HingeActor_ArrowComponent0/*Ref ArrowComponent'Default__RB_HingeActor.ArrowComponent0'*/,
		};
	}
}
}