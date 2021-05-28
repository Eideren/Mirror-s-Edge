namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_ConstraintActorSpawnable : RB_ConstraintActor/*
		notplaceable
		hidecategories(Navigation)*/{
	public RB_ConstraintActorSpawnable()
	{
		// Object Offset:0x003ACED7
		ConstraintSetup = LoadAsset<RB_ConstraintSetup>("Default__RB_ConstraintActorSpawnable.MyConstraintSetup")/*Ref RB_ConstraintSetup'Default__RB_ConstraintActorSpawnable.MyConstraintSetup'*/;
		ConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__RB_ConstraintActorSpawnable.MyConstraintInstance")/*Ref RB_ConstraintInstance'Default__RB_ConstraintActorSpawnable.MyConstraintInstance'*/;
		bNoDelete = false;
		Components = new array</*export editinline */ActorComponent>
		{
			LoadAsset<SpriteComponent>("Default__RB_ConstraintActorSpawnable.Sprite")/*Ref SpriteComponent'Default__RB_ConstraintActorSpawnable.Sprite'*/,
			LoadAsset<RB_ConstraintDrawComponent>("Default__RB_ConstraintActorSpawnable.MyConDrawComponent")/*Ref RB_ConstraintDrawComponent'Default__RB_ConstraintActorSpawnable.MyConDrawComponent'*/,
		};
	}
}
}