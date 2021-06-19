namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintActorSpawnable : RB_ConstraintActor/*
		notplaceable
		hidecategories(Navigation)*/{
	public RB_ConstraintActorSpawnable()
	{
		var Default__RB_ConstraintActorSpawnable_MyConstraintSetup = new RB_ConstraintSetup
		{
		}/* Reference: RB_ConstraintSetup'Default__RB_ConstraintActorSpawnable.MyConstraintSetup' */;
		var Default__RB_ConstraintActorSpawnable_MyConstraintInstance = new RB_ConstraintInstance
		{
		}/* Reference: RB_ConstraintInstance'Default__RB_ConstraintActorSpawnable.MyConstraintInstance' */;
		var Default__RB_ConstraintActorSpawnable_Sprite = new SpriteComponent
		{
		}/* Reference: SpriteComponent'Default__RB_ConstraintActorSpawnable.Sprite' */;
		var Default__RB_ConstraintActorSpawnable_MyConDrawComponent = new RB_ConstraintDrawComponent
		{
		}/* Reference: RB_ConstraintDrawComponent'Default__RB_ConstraintActorSpawnable.MyConDrawComponent' */;
		// Object Offset:0x003ACED7
		ConstraintSetup = Default__RB_ConstraintActorSpawnable_MyConstraintSetup/*Ref RB_ConstraintSetup'Default__RB_ConstraintActorSpawnable.MyConstraintSetup'*/;
		ConstraintInstance = Default__RB_ConstraintActorSpawnable_MyConstraintInstance/*Ref RB_ConstraintInstance'Default__RB_ConstraintActorSpawnable.MyConstraintInstance'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			Default__RB_ConstraintActorSpawnable_Sprite/*Ref SpriteComponent'Default__RB_ConstraintActorSpawnable.Sprite'*/,
			Default__RB_ConstraintActorSpawnable_MyConDrawComponent/*Ref RB_ConstraintDrawComponent'Default__RB_ConstraintActorSpawnable.MyConDrawComponent'*/,
		};
	}
}
}