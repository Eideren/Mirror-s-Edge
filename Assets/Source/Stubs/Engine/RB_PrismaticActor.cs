namespace MEdge.Engine{
using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class RB_PrismaticActor : RB_ConstraintActor/*
		placeable
		hidecategories(Navigation)*/{
	public RB_PrismaticActor()
	{
		// Object Offset:0x003AE819
		ConstraintSetup = LoadAsset<RB_PrismaticSetup>("Default__RB_PrismaticActor.MyPrismaticSetup")/*Ref RB_PrismaticSetup'Default__RB_PrismaticActor.MyPrismaticSetup'*/;
		ConstraintInstance = LoadAsset<RB_ConstraintInstance>("Default__RB_PrismaticActor.MyConstraintInstance")/*Ref RB_ConstraintInstance'Default__RB_PrismaticActor.MyConstraintInstance'*/;
		Components = new array</*export editinline */ActorComponent>
		{
			new SpriteComponent
			{
				// Object Offset:0x004D0372
				Sprite = LoadAsset<Texture2D>("EngineResources.S_KPrismatic")/*Ref Texture2D'EngineResources.S_KPrismatic'*/,
			}/* Reference: SpriteComponent'Default__RB_PrismaticActor.Sprite' */,
			LoadAsset<RB_ConstraintDrawComponent>("Default__RB_PrismaticActor.MyConDrawComponent")/*Ref RB_ConstraintDrawComponent'Default__RB_PrismaticActor.MyConDrawComponent'*/,
			new ArrowComponent
			{
				// Object Offset:0x00465D3B
				ArrowColor = new Color
				{
					R=255,
					G=64,
					B=64,
					A=255
				},
			}/* Reference: ArrowComponent'Default__RB_PrismaticActor.ArrowComponent0' */,
		};
	}
}
}